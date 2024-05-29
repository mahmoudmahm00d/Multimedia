using System.Drawing.Imaging;
using Multimedia.Helpers;

namespace Multimedia
{
    public partial class MainForm : Form
    {
        private string _progress = "None";

        private SelectionMode _selectionMode = SelectionMode.Rectangle;

        // Represent the history of modification
        // The first bitmap is the original image
        private readonly Stack<Bitmap> _bitmaps = [];

        private readonly List<Color[]> _colorMaps = [];

        Color? _color;
        private bool _isMouseDown;

        //private Point _startPoint = Point.Empty;
        private readonly List<Point> _points = [];
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
            var openImageDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif"
            };
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
                if (
                    _selectionMode == SelectionMode.Rectangle
                    || _selectionMode == SelectionMode.Ellipse
                )
                {
                    if (_points.Count == 0)
                    {
                        _points.Add(e.Location);
                    }
                    else
                    {
                        _points[0] = e.Location;
                    }

                    _selectionRectangle = Rectangle.Empty;
                }
                else if (_selectionMode == SelectionMode.Polygon)
                {
                    _points.Add(e.Location);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_points.Count != 0)
                {
                    _points.RemoveAt(_points.Count - 1);
                }
            }
            mainPictureBox.Invalidate();
        }

        private void MainPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                var originalImage = _bitmaps.Peek();
                var startPoint = _points[0];
                var startX = Math.Min(startPoint.X, e.X);
                var startY = Math.Min(startPoint.Y, e.Y);
                var width = Math.Abs(startPoint.X - e.X);
                var height = Math.Abs(startPoint.Y - e.Y);
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
            Bitmap? modifiedImage;
            if (_selectionMode == SelectionMode.Rectangle)
            {
                if (_selectionRectangle.Width < 5 || _selectionRectangle.Height < 5)
                {
                    return;
                }

                modifiedImage = originalImage.ApplyColorMapOnRectangleSelection(
                    _selectionRectangle,
                    colorMap
                );
            }
            else if (_selectionMode == SelectionMode.Polygon && _points.Count > 2)
            {
                modifiedImage = originalImage.ApplyColorMapOnPolygonSelection(
                    [.. _points],
                    colorMap
                );
            }
            else
            {
                modifiedImage = originalImage.ApplyColorMapOnEllipseSelection(
                    _selectionRectangle,
                    colorMap
                );
            }
            // Add item to the history
            if (modifiedImage != null)
                _bitmaps.Push(modifiedImage);
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
            if (_selectionMode == SelectionMode.Rectangle)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Red, 1.5F), rectangle);
            }
            else if (_selectionMode == SelectionMode.Polygon)
            {
                foreach (var point in _points)
                {
                    e.Graphics.FillEllipse(
                        new SolidBrush(Color.DarkRed),
                        new Rectangle
                        {
                            X = point.X - 2,
                            Y = point.Y - 2,
                            Width = 4,
                            Height = 4
                        }
                    );
                }

                if (_points.Count > 1)
                {
                    e.Graphics.DrawPolygon(new Pen(Color.Red, 1.5F), _points.ToArray());
                }
            }
            else if (_selectionMode == SelectionMode.Ellipse)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red, 1.5F), _selectionRectangle);
            }
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
