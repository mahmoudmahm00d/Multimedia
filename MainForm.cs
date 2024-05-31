using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Aspose.Imaging.FileFormats.Dicom;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Reg;
using Emgu.CV.Structure;
using Microsoft.VisualBasic.Devices;
using Multimedia.Helpers;
using Nest;
using System.Resources;
using System.IO;
using System.IO.Compression;
using Spire.Pdf;
using Spire.Pdf.Conversion.Compression;
namespace Multimedia
{
    public partial class MainForm : Form
    {
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

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bitmaps.Count < 1 || _selectionRectangle.Width == 0 || _selectionRectangle.Height == 0)
            {
                return;
            }

            var originalImage = _bitmaps.Peek();
            var croppedImage = originalImage.Clone(_selectionRectangle, originalImage.PixelFormat);
            using (var graphics = Graphics.FromImage(mainPictureBox.Image))
            {
                graphics.FillRectangle(new SolidBrush(Color.White), _selectionRectangle);
            }

            // ÅÚÇÏÉ ÊÚííä ãÓÊØíá ÇáÊÍÏíÏ
            _selectionRectangle = Rectangle.Empty;
            _bitmaps.Push(croppedImage);
            mainPictureBox.Image = _bitmaps.Peek();
            mainPictureBox.Invalidate();
        }

        private void addTesxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Graphics graphics = Graphics.FromImage(mainPictureBox.Image);
            Brush brush = new SolidBrush(Color.Black);
            // Define text font
            Font arial = new Font("Arial", 25, FontStyle.Regular);
            // Define rectangle
            Rectangle rectangle = new Rectangle(0, 0, 0, 0);
            // Draw text on image
            graphics.DrawString(textBox1.Text, arial, brush, rectangle);

            mainPictureBox.Invalidate();

        }
        private void compressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bitmaps.Count < 1)
            {
                return;
            }

            Mat imageMat = new Mat();

            Bitmap bitmap = _bitmaps.Pop();// ÇÓÊÎÑÇÌ ÇáÕæÑÉ ãä ÇáÜ stack
            imageMat = bitmap.ToImage<Bgr, byte>().Mat;
            CvInvoke.CvtColor(imageMat, imageMat, ColorConversion.Bgr2Gray);
            Mat floatImage = new Mat();
            imageMat.ConvertTo(floatImage, DepthType.Cv32F);
            CvInvoke.Dct(floatImage, floatImage, DctType.Forward);
            CvInvoke.Dct(floatImage, floatImage, DctType.Inverse);

            Mat outputMat = new Mat();

            floatImage.ConvertTo(outputMat, DepthType.Cv8U);

            Bitmap bit = outputMat.ToBitmap();

            _bitmaps.Push(bit);
            mainPictureBox.Image = bit;


            using (FileStream originalFileStream = new FileStream("C:\\Users\\USER\\Desktop\\multimedia-project\\Resources\\test1.wav", FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = File.Create("C:\\Users\\USER\\Desktop\\multimedia-project\\Resources\\test3.wav"))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }



            //Load a PDF document while initializing the PdfCompressor object
            PdfCompressor compressor = new PdfCompressor("C:\\Users\\USER\\Desktop\\multimedia-project\\Resources\\Video.pdf");

            //Get text compression options
            TextCompressionOptions textCompression = compressor.Options.TextCompressionOptions;

            //Compress fonts
            textCompression.CompressFonts = true;

            //Unembed fonts
            textCompression.UnembedFonts = true;

            //Get image compression options
            ImageCompressionOptions imageCompression = compressor.Options.ImageCompressionOptions;

            //Set the compressed image quality
            imageCompression.ImageQuality = ImageQuality.High;

            //Resize images
            imageCompression.ResizeImages = true;

            //Compress images
            imageCompression.CompressImage = true;

            //Save the compressed document to file
            compressor.CompressToFile("C:\\Users\\USER\\Desktop\\multimedia-project\\Resources\\pdf2.pdf");
        }


        private void addSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.test1);
            player.Play();

        }

        public void CreateZipFile(string outputFilePath, params string[] inputFiles)
        {

            using (FileStream zipToOpen = new FileStream(outputFilePath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach (var file in inputFiles)
                    {
                        int fileNumber = 0;
                        while (_bitmaps.Count > 0)
                        {
                            Bitmap bitmap = _bitmaps.Pop();
                            string tempFilePath = $"temp{fileNumber}.bmp";
                            bitmap.Save(tempFilePath);
                            archive.CreateEntryFromFile(tempFilePath, Path.GetFileName(tempFilePath));
                            File.Delete(tempFilePath);
                            fileNumber++;
                        }

                    }
                }
            }


        }
    }
}
