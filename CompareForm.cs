using Emgu.CV.UI;
using Multimedia.Helpers;

namespace Multimedia
{
    public partial class CompareForm : Form
    {
        private readonly Bitmap _originalImage;
        private Bitmap? _imageToCompare;
        public string Progress
        {
            get => progressComboBox.Text;
        }

        public CompareForm(Bitmap bitmap)
        {
            InitializeComponent();
            _originalImage = bitmap;
            originalPictureBox.Image = _originalImage;
        }

        private void SelectImageButtonClick(object sender, EventArgs e)
        {
            var openImageDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "JPEG|*.jpg|PNG|*.png"
            };

            DialogResult result = openImageDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _imageToCompare = new Bitmap(openImageDialog.FileName);
                secondPictureBox.Image = _imageToCompare;

                progressComboBox.Visible = true;
                progressLabel.Visible = true;
            }
        }

        private void MergeImagesButtonClick(object sender, EventArgs e)
        {
            if (_imageToCompare is null)
            {
                return;
            }

            var resultImage = ImageProccessing.MergeImages(_originalImage, _imageToCompare);
            var form = new Form { Width = resultImage.Width, Height = resultImage.Height };
            var pictureBox = new PanAndZoomPictureBox
            {
                Image = resultImage,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Normal
            };

            form.Controls.Add(pictureBox);
            form.ShowDialog();
        }
    }
}
