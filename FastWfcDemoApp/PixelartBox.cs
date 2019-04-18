using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastWfcDemoApp
{
    /// <summary>
    /// Displays and zooms the assigned <see cref="Image"/> in a pixel perfect way.
    /// </summary>
    public partial class PixelartBox : Control
    {
        private Image _Image;
        /// <summary>
        /// The image to display.
        /// </summary>
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                Refresh();
            }
        }

        /// <summary>
        /// Creates a new <see cref="PictureBox"/>.
        /// </summary>
        public PixelartBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Draws and zooms the assigned <see cref="Image"/> in a pixel perfect way.
        /// </summary>
        /// <param name="pe">The event parameters.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            pe.Graphics.Clear(BackColor);

            if (_Image == null)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    var textSize = pe.Graphics.MeasureString(Text, Font);
                    using (var brush = new SolidBrush(ForeColor))
                        pe.Graphics.DrawString(Text, Font, brush, Size.Width / 2 - textSize.Width / 2, Size.Height / 2 - textSize.Height / 2);
                }
                return;
            }

            var scale = Math.Min(Size.Width / (float)_Image.Width, Size.Height / (float)_Image.Height);
            var srcRect = new Rectangle(0, 0, _Image.Width, _Image.Height);
            var destRect = new Rectangle(0, 0, (int)(_Image.Width * scale), (int)(_Image.Height * scale));

            // Center
            destRect.X = Size.Width / 2 - destRect.Width / 2;
            destRect.Y = Size.Height / 2 - destRect.Height / 2;

            pe.Graphics.DrawImage(_Image, destRect, srcRect, GraphicsUnit.Pixel);
        }
    }
}
