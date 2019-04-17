using FastWfcNet;
using FastWfcNet.Utils;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWfcDemoApp
{
    public partial class MainForm : Form
    {
        private bool _IsRunning = false;

        public MainForm()
        {
            InitializeComponent();
        }


        private void pixelartBoxInput_Click(object sender, EventArgs e)
        {
            if (_IsRunning || openFileDialogInput.ShowDialog() != DialogResult.OK)
                return;

            var image = new Bitmap(openFileDialogInput.FileName);
            var oldImage = pixelartBoxInput.Image;
            pixelartBoxInput.Image = image;

            if (oldImage != null)
                oldImage.Dispose();

            buttonStart.Enabled = true;

            numericUpDownWidth.Value = Math.Max(image.Width, numericUpDownWidth.Minimum);
            numericUpDownHeight.Value = Math.Max(image.Height, numericUpDownHeight.Minimum);
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            var inputBitmap = pixelartBoxInput.Image as Bitmap;
            var options = new OverlappingWfcOptions()
            {
                Ground = checkBoxGround.Checked,
                OutputHeight = (UInt32)numericUpDownHeight.Value,
                OutputWidth = (UInt32)numericUpDownWidth.Value,
                PatternSize = (UInt32)numericUpDownPatternSize.Value,
                PeriodicInput = checkBoxPeriodicInput.Checked,
                PeriodicOutput = checkBoxPeriodicOutput.Checked,
                Symmetry = (UInt32)numericUpDownSymmetry.Value
            };

            var seed = (int)numericUpDownSeed.Value;

            _IsRunning = true;
            buttonStart.Enabled = false;
            groupBoxSettings.Enabled = false;

            var outputBitmap = await Task.Run<Bitmap>(() => {
                var inputColors = new Array2D<Color>((UInt32)inputBitmap.Height, (UInt32)inputBitmap.Width);
                for (UInt32 x = 0; x < inputColors.Width; x++)
                    for (UInt32 y = 0; y < inputColors.Height; y++)
                        inputColors[y, x] = inputBitmap.GetPixel((int)x,(int)y);

                var wfc = new OverlappingWfc<Color>(inputColors, options, seed);
                var result = wfc.Run();
                if (result == null)
                    return null;
                var resultBitmap = new Bitmap((int)result.Width, (int)result.Height);
                for (UInt32 x = 0; x < result.Width; x++)
                    for (UInt32 y = 0; y < result.Height; y++)
                        resultBitmap.SetPixel((int)x, (int)y, result[y, x]);
                return resultBitmap;
            });

            if (outputBitmap != null)
            {
                var oldImage = pixelartBoxOutput.Image;
                pixelartBoxOutput.Image = outputBitmap;

                if (oldImage != null)
                    oldImage.Dispose();
            }

            groupBoxSettings.Enabled = true;
            buttonStart.Enabled = true;
            _IsRunning = false;
        }

        private void pixelartBoxOutput_Click(object sender, EventArgs e)
        {
            if (pixelartBoxOutput.Image == null || saveFileDialogOutput.ShowDialog() != DialogResult.OK)
                return;

            pixelartBoxOutput.Image.Save(saveFileDialogOutput.FileName);
        }
    }
}
