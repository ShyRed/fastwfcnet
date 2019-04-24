using FastWfcDemoApp.Model;
using FastWfcNet;
using FastWfcNet.Utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWfcDemoApp.Views
{
    /// <summary>
    /// View for overlapping wfc model.
    /// </summary>
    public partial class OverlappingWfcView : UserControl, IWfcPanel
    {
        /// <summary>
        /// Specifies if WFC is running.
        /// </summary>
        private bool _IsRunning = false;

        /// <summary>
        /// The logger.
        /// </summary>
        public ILogger Logger;

        /// <summary>
        /// Creates a new <see cref="OverlappingWfcView"/> instance.
        /// </summary>
        public OverlappingWfcView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs the WFC algo
        /// </summary>
        /// <returns></returns>
        public async Task RunWfc()
        {
            var inputBitmap = pixelartBoxInput.Image as Bitmap;
            if (inputBitmap == null)
                return;

            var options = new OverlappingWfcOptions()
            {
                HasGround = checkBoxGround.Checked,
                OutputHeight = (uint)numericUpDownHeight.Value,
                OutputWidth = (uint)numericUpDownWidth.Value,
                PatternSize = (uint)numericUpDownPatternSize.Value,
                IsPeriodicInput = checkBoxPeriodicInput.Checked,
                IsPeriodicOutput = checkBoxPeriodicOutput.Checked,
                Symmetry = (uint)numericUpDownSymmetry.Value
            };

            var seed = (int)numericUpDownSeed.Value;

            _IsRunning = true;
            groupBoxSettings.Enabled = false;

            Bitmap outputBitmap = null;
            var stopwatch = new Stopwatch();
            var retries = 0;
            try
            {
                stopwatch.Start();

                while (retries < numericUpDownRetries.Value && outputBitmap == null)
                {
                    Logger.LogNeutral($"Attempt #{retries + 1} ...");

                    outputBitmap = await RunWfcAsync(inputBitmap, options, seed);

                    if (outputBitmap == null)
                        seed = MakeRandomSeed();
                    retries++;
                }

                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show(ex.ToString(), "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (outputBitmap != null)
            {
                var oldImage = pixelartBoxOutput.Image;
                pixelartBoxOutput.Image = outputBitmap;

                if (oldImage != null)
                    oldImage.Dispose();

                Logger.LogSuccess($"Succeeded in {stopwatch.ElapsedMilliseconds}ms after {retries} attempt(s)");
            }
            else
            {
                Logger.LogFailure($"Failed in {stopwatch.ElapsedMilliseconds}ms after {retries} attempt(s)");
            }

            groupBoxSettings.Enabled = true;
            _IsRunning = false;
        }

        /// <summary>
        /// Presents an "open file" dialog to the user for choosing the input image file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pixelartBoxInput_Click(object sender, EventArgs e)
        {
            if (_IsRunning || openFileDialogInput.ShowDialog() != DialogResult.OK)
                return;

            var image = new Bitmap(openFileDialogInput.FileName);
            var oldImage = pixelartBoxInput.Image;
            pixelartBoxInput.Image = image;

            if (oldImage != null)
                oldImage.Dispose();

            numericUpDownWidth.Value = Math.Max(image.Width, numericUpDownWidth.Minimum);
            numericUpDownHeight.Value = Math.Max(image.Height, numericUpDownHeight.Minimum);
        }

        /// <summary>
        /// Presents the user with a "save file" dialog for saving the output image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pixelartBoxOutput_Click(object sender, EventArgs e)
        {
            if (pixelartBoxOutput.Image == null || saveFileDialogOutput.ShowDialog() != DialogResult.OK)
                return;

            pixelartBoxOutput.Image.Save(saveFileDialogOutput.FileName);
        }

        /// <summary>
        /// Assigns a random value to the seed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            MakeRandomSeed();
        }

        /// <summary>
        /// Creates a new random seed.
        /// </summary>
        /// <returns>The new seed.</returns>
        private int MakeRandomSeed()
        {
            var seed = (int)(new Random().NextDouble() * (double)numericUpDownSeed.Maximum);
            numericUpDownSeed.Value = seed;
            return seed;
        }

        /// <summary>
        /// Runs WFC with overlapping model in a thread creating a <see cref="Bitmap"/> that is based
        /// on the specified input.
        /// </summary>
        /// <param name="inputBitmap">The input image.</param>
        /// <param name="options">The overlapping model options.</param>
        /// <param name="seed">The seed for the random number generator.</param>
        /// <returns>The resulting image or <c>null</c>.</returns>
        private static Task<Bitmap> RunWfcAsync(Bitmap inputBitmap, OverlappingWfcOptions options, int seed)
        {
            return Task.Run(() =>
            {
                var inputColors = BitmapUtil.FetchColorsAsArgb(inputBitmap);

                // Create WFC overlapping model instance with the created array, the options and the seed
                // for the random number generator.
                var wfc = new OverlappingWfc<int>(inputColors, options, seed);

                // Run the WFC algorithm. The result is an Array2D with the result pixels/colors. Return value
                // is null, if the WFC failed to create a solution without contradictions. In this case one
                // should change the settings or try again with a different seed for the random number generator.
                var result = wfc.Run();

                // Failed...
                if (result == null)
                    return null;

                // Success: extract pixels/colors and put them into an image.
                var resultBitmap = BitmapUtil.CreateFromArgbColors(result);

                return resultBitmap;
            });
        }
    }
}
