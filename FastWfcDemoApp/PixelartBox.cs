using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastWfcDemoApp
{
    public partial class PixelartBox : Control
    {
        private Image _Image;

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

        public PixelartBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pe.Graphics.Clear(Color.Transparent);

            if (_Image == null)
                return;

            var scale = Math.Min(Size.Width / (float)_Image.Width, Size.Height / (float)_Image.Height);
            pe.Graphics.DrawImage(_Image, 0, 0, _Image.Width * scale, _Image.Height * scale);
        }
    }
}
