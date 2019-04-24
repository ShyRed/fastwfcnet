using FastWfcNet.Utils;
using System;
using System.Drawing;

namespace FastWfcDemoApp
{
    /// <summary>
    /// Utility functions for dealing with <see cref="Bitmap"/>s.
    /// </summary>
    public static class BitmapUtil
    {
        /// <summary>
        /// Fetch the pixels from the input <see cref="Bitmap" /> (convert Colors to ARGB for speed) and store them
        /// in an <see cref="Array2D{int}" />.
        /// </summary>
        /// <param name="bitmap">The input image.</param>
        /// <returns>Array holding the ARGB-Color values of the image.</returns>
        public static Array2D<int> FetchColorsAsArgb(Bitmap bitmap)
        {
            if (bitmap == null) throw new ArgumentNullException(nameof(bitmap));

            var colors = new Array2D<int>((uint)bitmap.Height, (uint)bitmap.Width);

            for (uint x = 0; x < colors.Width; x++)
                for (uint y = 0; y < colors.Height; y++)
                    colors[y, x] = bitmap.GetPixel((int)x, (int)y).ToArgb();

            return colors;
        }

        /// <summary>
        /// Creates a <see cref="Bitmap"/> from the specified ARGB color values.
        /// </summary>
        /// <param name="colors">Array holding the ARGB color values.</param>
        /// <returns>The created bitmap.</returns>
        public static Bitmap CreateFromArgbColors(Array2D<int> colors)
        {
            if (colors == null) throw new ArgumentNullException(nameof(colors));

            var bitmap = new Bitmap((int)colors.Width, (int)colors.Height);

            for (uint x = 0; x < colors.Width; x++)
                for (uint y = 0; y < colors.Height; y++)
                    bitmap.SetPixel((int)x, (int)y, Color.FromArgb(colors[y, x]));

            return bitmap;
        }
    }
}
