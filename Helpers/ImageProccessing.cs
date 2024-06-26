﻿using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Multimedia.Helpers;

internal static class ImageProccessing
{
    public static Bitmap ApplyColorMapOnRectangleSelection(
        this Bitmap bitmap,
        Rectangle selectionRectangle,
        Color[] colorMap
    )
    {
        ArgumentNullException.ThrowIfNull(bitmap);
        ArgumentNullException.ThrowIfNull(colorMap);

        if (colorMap.Length != 256)
        {
            throw new ArgumentException("Color map must consists of 256 color", nameof(colorMap));
        }

        var coloredImage = new Bitmap(bitmap.Width, bitmap.Height);

        BitmapData imageData = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite,
            bitmap.PixelFormat
        );

        var unmanagedImage = new UnmanagedImage(imageData);

        for (int y = 0; y < unmanagedImage.Height; y++)
        {
            for (int x = 0; x < unmanagedImage.Width; x++)
            {
                Color grayscalePixel = unmanagedImage.GetPixel(x, y);
                int grayscaleValue = grayscalePixel.R; // Assuming all channels are equal (Grey scale)
                if (
                    (
                        x < selectionRectangle.X
                        || selectionRectangle.X + selectionRectangle.Width < x
                    )
                    || (
                        y < selectionRectangle.Y
                        || selectionRectangle.Y + selectionRectangle.Height < y
                    )
                )
                {
                    coloredImage.SetPixel(x, y, grayscalePixel);
                }
                else
                {
                    coloredImage.SetPixel(x, y, colorMap[grayscaleValue]);
                }
            }
        }

        bitmap.UnlockBits(imageData);

        return coloredImage;
    }

    public static Bitmap ApplyColorMapOnEllipseSelection(
        this Bitmap bitmap,
        Rectangle rectangle,
        Color[] colorMap
    )
    {
        ArgumentNullException.ThrowIfNull(bitmap);
        ArgumentNullException.ThrowIfNull(colorMap);

        if (colorMap.Length != 256)
        {
            throw new ArgumentException("Color map must consist of 256 colors.", nameof(colorMap));
        }

        var coloredImage = new Bitmap(bitmap.Width, bitmap.Height);

        BitmapData imageData = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite,
            bitmap.PixelFormat
        );

        var unmanagedImage = new UnmanagedImage(imageData);

        for (int y = 0; y < unmanagedImage.Height; y++)
        {
            for (int x = 0; x < unmanagedImage.Width; x++)
            {
                Color grayscalePixel = unmanagedImage.GetPixel(x, y);
                int grayscaleValue = grayscalePixel.R; // Assuming all channels are equal (Gray scale)

                // Calculate the distance from the center of the ellipse to the current pixel
                double p =
                    (
                        Math.Pow(x - (rectangle.Location.X + rectangle.Width / 2), 2)
                        / Math.Pow(rectangle.Width / 2, 2)
                    )
                    + (
                        Math.Pow(y - (rectangle.Location.Y + rectangle.Height / 2), 2)
                        / Math.Pow(rectangle.Height / 2, 2)
                    );

                // Check if the pixel is within the elliptical selection area
                bool isInEllipse = p < 1;

                if (!isInEllipse)
                {
                    coloredImage.SetPixel(x, y, grayscalePixel);
                }
                else
                {
                    coloredImage.SetPixel(x, y, colorMap[grayscaleValue]);
                }
            }
        }

        bitmap.UnlockBits(imageData);

        return coloredImage;
    }

    public static Bitmap ApplyColorMapOnPolygonSelection(
        this Bitmap bitmap,
        Point[] polygonPoints,
        Color[] colorMap
    )
    {
        ArgumentNullException.ThrowIfNull(bitmap);
        ArgumentNullException.ThrowIfNull(colorMap);

        if (colorMap.Length != 256)
        {
            throw new ArgumentException("Color map must consists of 256 colors", nameof(colorMap));
        }

        var coloredImage = new Bitmap(bitmap);

        BitmapData imageData = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite,
            bitmap.PixelFormat
        );

        var unmanagedImage = new UnmanagedImage(imageData);

        // Determine polygon bounding box
        int minX = polygonPoints.Min(p => p.X);
        int minY = polygonPoints.Min(p => p.Y);
        int maxX = polygonPoints.Max(p => p.X);
        int maxY = polygonPoints.Max(p => p.Y);

        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                // Check if pixel is inside polygon
                if (IsPointInsidePolygon(x, y, polygonPoints))
                {
                    Color grayscalePixel = unmanagedImage.GetPixel(x, y);
                    int grayscaleValue = grayscalePixel.R; // Assuming all channels are equal (Greyscale)
                    coloredImage.SetPixel(x, y, colorMap[grayscaleValue]);
                }
                else
                {
                    coloredImage.SetPixel(x, y, unmanagedImage.GetPixel(x, y));
                }
            }
        }

        bitmap.UnlockBits(imageData);

        return coloredImage;
    }

    // Helper function to check if a point is inside a polygon
    private static bool IsPointInsidePolygon(int x, int y, Point[] polygon)
    {
        bool inside = false;
        for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
        {
            if (
                (polygon[i].Y > y) != (polygon[j].Y > y)
                && x
                    < (polygon[j].X - polygon[i].X)
                        * (y - polygon[i].Y)
                        / (polygon[j].Y - polygon[i].Y)
                        + polygon[i].X
            )
            {
                inside = !inside;
            }
        }
        return inside;
    }

    public static Bitmap MergeImages(Bitmap bottomImage, Bitmap topImage)
    {
        // If one of the images is larger than the other, resize the larger one to match the size of the smaller one
        if (bottomImage.Width != topImage.Width || bottomImage.Height != topImage.Height)
        {
            int minWidth = Math.Min(bottomImage.Width, topImage.Width);
            int minHeight = Math.Min(bottomImage.Height, topImage.Height);

            // Resize the larger image to match the size of the smaller one
            bottomImage = new ResizeBilinear(minWidth, minHeight).Apply(bottomImage);
            topImage = new ResizeBilinear(minWidth, minHeight).Apply(topImage);
        }

        BitmapData bottomImageData = bottomImage.LockBits(
            new Rectangle(0, 0, bottomImage.Width, bottomImage.Height),
            ImageLockMode.ReadWrite,
            bottomImage.PixelFormat
        );

        var unmanagedBottomImage = new UnmanagedImage(bottomImageData);

        var filter = new Merge(unmanagedBottomImage);

        BitmapData topImageData = topImage.LockBits(
            new Rectangle(0, 0, topImage.Width, topImage.Height),
            ImageLockMode.ReadWrite,
            topImage.PixelFormat
        );

        var unmanagedTopImage = new UnmanagedImage(topImageData);

        var result = filter.Apply(unmanagedTopImage);
        bottomImage.UnlockBits(bottomImageData);
        topImage.UnlockBits(topImageData);

        return result.ToManagedImage();
    }
    // تمت إضافة الطلبات ( قص الصورة - إضافة تعليق نصي - ضغط الصورة )
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

    // إعادة تعيين مستطيل التحديد
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

    Bitmap bitmap = _bitmaps.Pop();// استخراج الصورة من الـ stack
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

}

private void addSoundToolStripMenuItem_Click(object sender, EventArgs e)
{
       
}
}
