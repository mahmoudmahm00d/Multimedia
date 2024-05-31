using System.Drawing.Imaging;
using AForge.Imaging;

namespace Multimedia.Helpers;

internal static class ImageProccessing
{
    public static Bitmap MergeTwoImages(Bitmap one, Bitmap two)
    {
        Bitmap bitmap = new (one.Width, one.Height);
        return bitmap;
    }

    public static Bitmap ApplyColorMapOnSelection(
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
}
