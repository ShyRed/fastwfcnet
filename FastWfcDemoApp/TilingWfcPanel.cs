using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using FastWfcDemoApp.Model;
using FastWfcNet;
using FastWfcNet.Utils;

namespace FastWfcDemoApp
{
    /// <summary>
    /// View for overlapping wfc model.
    /// </summary>
    public partial class TilingWfcPanel : UserControl, IWfcPanel
    {
        /// <summary>
        /// Logging.
        /// </summary>
        public ILogger Logger;

        private List<Tile<int>> _Tiles = new List<Tile<int>>();
        private List<Tuple<uint, uint, uint, uint>> _Neighbors = new List<Tuple<uint, uint, uint, uint>>();

        /// <summary>
        /// Creates a new <see cref="TilingWfcPanel"/> instance.
        /// </summary>
        public TilingWfcPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs the WFC algorithm.
        /// </summary>
        /// <returns></returns>
        public async Task RunWfc()
        {
            groupBoxSettings.Enabled = false;

            var stopwatch = new Stopwatch();
            var retries = 0;
            Array2D<int> result = null;

            try
            {
                stopwatch.Start();

                while (retries < numericUpDownRetries.Value && result == null)
                {
                    Logger.LogNeutral($"Attempt #{retries + 1} ...");

                    result = await RunWfcAsync();

                    if (result == null)
                        numericUpDownSeed.Value = MakeRandomSeed();
                    retries++;
                }

                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show(ex.ToString(), "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (result != null)
            {
                var oldImage = pixelartBoxOutput.Image;

                pixelartBoxOutput.Image = await DrawOutputImage(result); 

                if (oldImage != null)
                    oldImage.Dispose();

                Logger.LogSuccess($"Succeeded in {stopwatch.ElapsedMilliseconds}ms after {retries} attempt(s)");
            }
            else
            {
                Logger.LogFailure($"Failed in {stopwatch.ElapsedMilliseconds}ms after {retries} attempt(s)");
            }

            groupBoxSettings.Enabled = true;
        }

        /// <summary>
        /// Creates a new random seed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRandom_Click(object sender, System.EventArgs e)
        {
            numericUpDownSeed.Value = MakeRandomSeed();
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
        /// Loads a tileset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonLoadTileset_Click(object sender, EventArgs e)
        {
            if (openFileDialogTileset.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var document = new XmlDocument();
                document.Load(openFileDialogTileset.FileName);
                var root = document.DocumentElement;

                _Tiles.Clear();
                _Neighbors.Clear();

                var tilemapDirectory = new FileInfo(openFileDialogTileset.FileName).DirectoryName;

                // Load tiles
                uint id = 0;
                var filenameToId = new Dictionary<string, uint>();
                foreach (XmlNode tile in root.SelectNodes("tiles/tile"))
                {
                    var filename = tile.Attributes["name"].Value;
                    var symmetry = SymmetryHelper.Parse(tile.Attributes["symmetry"].Value);

                    double weight = 1.0;
                    if (tile.Attributes["weight"] != null)
                        weight = double.Parse(tile.Attributes["weight"].Value);

                    var nbOfSyms = SymmetryHelper.NumberOfPossibleOrientations(symmetry);

                    if (File.Exists(Path.Combine(tilemapDirectory, filename + " 0.png")))
                    {
                        var data = new Array2D<int>[nbOfSyms];
                        for (uint i = 0; i < data.Length; i++)
                            data[i] = await FetchImageData(Path.Combine(tilemapDirectory, filename + " " + i + ".png"));

                        _Tiles.Add(new Tile<int>(data, symmetry, weight));
                    }
                    else
                    {
                        var imageData = await FetchImageData(Path.Combine(tilemapDirectory, filename + ".png"));
                        _Tiles.Add(new Tile<int>(imageData, symmetry, weight));
                    }

                    filenameToId.Add(filename, id++);
                }

                // Load neighbors
                foreach (XmlNode neighbor in root.SelectNodes("neighbors/neighbor"))
                {
                    var tile1 = neighbor.Attributes["left"].Value;
                    var tile2 = neighbor.Attributes["right"].Value;

                    var sep1 = tile1.LastIndexOf(' ');
                    uint orien1 = 0;
                    if (sep1 > 0 && uint.TryParse(tile1.Substring(sep1 + 1), out orien1))
                        tile1 = tile1.Substring(0, sep1);

                    var sep2 = tile2.LastIndexOf(' ');
                    uint orien2 = 0;
                    if (sep2 > 0 && uint.TryParse(tile2.Substring(sep2 + 1), out orien2))
                        tile2 = tile2.Substring(0, sep2);

                    _Neighbors.Add(new Tuple<uint, uint, uint, uint>(
                        filenameToId[tile1],
                        orien1,
                        filenameToId[tile2],
                        orien2));
                }

                Logger.LogSuccess($"Loaded {_Tiles.Count} tiles and {_Neighbors.Count} neighbors!");
            }
            catch (Exception ex)
            {
                Logger.LogFailure(ex.Message);
                MessageBox.Show(ex.ToString(), "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Runs WFC algorithm async.
        /// </summary>
        /// <returns>The result or <c>null</c>.</returns>
        private Task<Array2D<int>> RunWfcAsync()
        {
            var options = new TilingWfcOptions() { PeriodicOutput = checkBoxPeriodicOutput.Checked };
            var height = (uint)numericUpDownHeight.Value;
            var width = (uint)numericUpDownWidth.Value;
            var seed = (int)numericUpDownSeed.Value;

            return Task.Run(() =>
            {
                var wfc = new TilingWfc<int>(_Tiles.ToArray(), _Neighbors, height, width, options, seed);
                return wfc.Run();
            });
        }

        /// <summary>
        /// Draws the output image.
        /// </summary>
        /// <param name="result">The tile data.</param>
        /// <returns>The generated output image.</returns>
        private Task<Bitmap> DrawOutputImage(Array2D<int> result)
        {
            return Task.Run(() =>
            {
                var outputImage = new Bitmap((int)result.Width, (int)result.Height);

                using (var g = Graphics.FromImage(outputImage))
                {
                    for (uint y = 0; y < result.Height; y++)
                    {
                        for (uint x = 0; x < result.Width; x++)
                        {
                            outputImage.SetPixel((int)x, (int)y, Color.FromArgb(result[y, x]));
                        }
                    }
                }

                return outputImage;
            });
        }

        /// <summary>
        /// Reads pixel data from the specified image.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The image data.</returns>
        private static Task<Array2D<int>> FetchImageData(string filename)
        {
            return Task.Run(() =>
            {
                using (var image = new Bitmap(filename))
                {
                    var result = new Array2D<int>((uint)image.Height, (uint)image.Width);
                    for (uint x = 0; x < image.Width; x++)
                        for (uint y = 0; y < image.Height; y++)
                            result[y, x] = image.GetPixel((int)x, (int)y).ToArgb();
                    return result;
                }
            });
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
    }
}
