using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Windows.Forms;
using Multimedia.Helpers;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing;
using System.Xml.Linq;

namespace Multimedia
{

    public partial class MainForm : Form
    {

        // يستخدم هذا المتحول ليرد التقرير النصي لتمريره الى تابع الضغط
        public PdfDocument reportPdf = new PdfDocument();

        // Represent the history of modification
        // The first bitmap is the original image
        private readonly Stack<Bitmap> _bitmaps = [];

        private readonly List<Color[]> _colorMaps = [];

        Color? _color;
        private bool _isMouseDown;
        private Point _startPoint;
        private Rectangle _selectionRectangle;

        public MainForm()
        {
            InitializeComponent();
            ColorMaps.AddColorMaps(_colorMaps);
        }

        private void SelectColorButtonClick(object sender, EventArgs e)
        {
            if (_bitmaps.Count < 1)
            {
                return;
            }

            var colorDialog = new ColorDialog();

            var result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _color = colorDialog.Color;
                selectedColorLabel.BackColor = (Color)_color;
            }
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            var openImageDialog = new OpenFileDialog { CheckFileExists = true };
            DialogResult result = openImageDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _bitmaps.Clear();
                _bitmaps.Push(new Bitmap(openImageDialog.FileName));
                mainPictureBox.Image = _bitmaps.Peek();
            }
        }

        private void MainPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (_bitmaps.Count < 1)
            {
                return;
            }

            var originalImage = _bitmaps.Peek();
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > originalImage.Width)
                {
                    return;
                }

                if (e.Y > originalImage.Height)
                {
                    return;
                }

                _isMouseDown = true;
                _startPoint = e.Location;
                _selectionRectangle = Rectangle.Empty;
            }
        }

        private void MainPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                var originalImage = _bitmaps.Peek();

                var startX = Math.Min(_startPoint.X, e.X);
                var startY = Math.Min(_startPoint.Y, e.Y);
                var width = Math.Abs(_startPoint.X - e.X);
                var height = Math.Abs(_startPoint.Y - e.Y);
                width = Math.Min(width, originalImage.Width);
                height = Math.Min(height, originalImage.Height);

                if (e.X < 0)
                {
                    startX = 0;
                }

                if (e.Y < 0)
                {
                    startY = 0;
                }

                if (e.X > originalImage.Width)
                {
                    width = Math.Abs(originalImage.Width - startX);
                }

                if (e.Y > originalImage.Height)
                {
                    height = Math.Abs(originalImage.Height - startY);
                }

                _selectionRectangle = new Rectangle(startX, startY, width, height);
                mainPictureBox.Invalidate(); // Trigger redrawing with selection
            }
        }

        private void MainPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _isMouseDown = false;
            }
        }

        private void ApplyBlendingButtonClick(object sender, EventArgs e)
        {
            if (_bitmaps.Count < 1)
            {
                return;
            }

            if (_selectionRectangle.Width == 0 || _selectionRectangle.Height == 0)
            {
                return;
            }

            Color[] colorMap;
            if (colorMapComboBox.SelectedIndex == 5)
            {
                if (_color is null)
                {
                    return;
                }

                colorMap = ColorMaps.GetColorMap((Color)_color);
            }
            else
            {
                colorMap = _colorMaps[colorMapComboBox.SelectedIndex];
            }

            var originalImage = _bitmaps.Peek();
            var modifedImage = originalImage.ApplyColorMapOnSelection(
                _selectionRectangle,
                colorMap
            );
            // Add item to the history
            _bitmaps.Push(modifedImage);
            // Show the modified image
            mainPictureBox.Image = _bitmaps.Peek();
        }

        private void MainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (_bitmaps.Count < 1)
            {
                return;
            }

            Rectangle rectangle = _selectionRectangle;
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1.5F), rectangle);
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_bitmaps.Count < 1)
            {
                return;
            }

            SaveFileDialog saveFileDialog =
                new()
                {
                    CheckPathExists = true,
                    ValidateNames = true,
                    AddExtension = true,
                    Filter = "JPEG|*.jpg|PNG|*.png"
                };

            var result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK || string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                return;
            }

            mainPictureBox.Image.Save(
                saveFileDialog.FileName,
                saveFileDialog.FilterIndex == 0 ? ImageFormat.Jpeg : ImageFormat.Png
            );
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_bitmaps.Count == 0)
            {
                return;
            }

            if (1 < _bitmaps.Count)
            {
                _bitmaps.Pop();
                mainPictureBox.Image = _bitmaps.Peek();
            }
        }

        private void ColorMapComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            selectedColorLabel.Visible = colorMapComboBox.SelectedIndex == 5;
            selectColorButton.Visible = colorMapComboBox.SelectedIndex == 5;
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void report_Click(object sender, EventArgs e)
        {
            // إنشاء فورم جديد 
            Form2 form2 = new Form2();
            form2.Size = new Size(400, 380);
            form2.Show();
            // هذا الحدث لتمرير ملف التقرير 
            form2.PdfSaved += form2_PdfSaved;
        }


        private void form2_PdfSaved(string filePath)
        {
            // هنا المتحول العام ياخذ مسار التقرير الذي تم حفظه 
            reportPdf = new PdfDocument(filePath);
        }

        private void forrier_Click(object sender, EventArgs e)
        {

            // Resize the image
            int newWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log(mainPictureBox.Image.Width) / Math.Log(2)));
            int newHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log(mainPictureBox.Image.Height) / Math.Log(2)));
            ResizeBilinear resizeFilter = new ResizeBilinear(newWidth, newHeight);
            Bitmap resizedImage = resizeFilter.Apply((Bitmap)mainPictureBox.Image);
            // Make the Image grey 
            Grayscale filter1 = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter1.Apply(resizedImage);
            // Apply FFT to the grayscale image
            ComplexImage complexImage = ComplexImage.FromBitmap(grayImage);
            complexImage.ForwardFourierTransform();
            complexImage.BackwardFourierTransform();

            // تحويل الصورة الناتجة إلى Bitmap
            Bitmap resultImage = complexImage.ToBitmap();
            mainPictureBox.Image = resultImage;

        }
    }

    public class Form2 : Form
    {
        private TextBox textBox;
        private Button btnSaveAsPdf;
        private Button okButton;
        private PdfDocument document = new PdfDocument();
        public delegate void PdfSavedEventHandler(string filePath);
        public event PdfSavedEventHandler PdfSaved;

        public Form2()
        {
            textBox = new TextBox
            {
                Multiline = true,
                Size = new Size(400, 280)
            };
            Controls.Add(textBox);

            btnSaveAsPdf = new Button
            {
                Text = "Save as PDF",
                Location = new System.Drawing.Point(230, 280),
                Size = new System.Drawing.Size(120, 30)
            };
            btnSaveAsPdf.Click += new EventHandler(btnSaveAsPdf_Click);
            Controls.Add(btnSaveAsPdf);
            okButton = new Button
            {
                Location = new System.Drawing.Point(30, 280),
                Size = new System.Drawing.Size(40, 30),
                Text = "OK"
            };
            okButton.Click += new EventHandler(OkButton_Click);
            Controls.Add(okButton);
            
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnSaveAsPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "حفظ كملف PDF"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Verdana", 20);

                gfx.DrawString(textBox.Text, font, XBrushes.Black,
                    new XRect(0, 0, page.Width, page.Height),
                    XStringFormats.TopLeft);

                document.Save(saveFileDialog.FileName);
                //document.Save("report.pdf");
                PdfSaved?.Invoke("report.pdf");
                document.Close();

                

            }
        }


    }

}
