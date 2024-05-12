using System.Drawing.Imaging;
using Multimedia.Helpers;

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
    }
}
