using FastWfcNet.Utils;
using FastWfcNet.Wfc;
using System;
using System.Collections.Generic;

namespace FastWfcNet
{
    /// <summary>
    /// Class generating a new image with the overlapping WFC algorithm.
    /// </summary>
    public sealed class OverlappingWfc<T>
    {
        /// <summary>
        /// The input image. T is usually a color.
        /// </summary>
        private Array2D<T> _Input;

        /// <summary>
        /// The options needed by the algorithm.
        /// </summary>
        private OverlappingWfcOptions _Options;

        /// <summary>
        /// The array of the different patterns extracted from the input.
        /// </summary>
        private Array2D<T>[] _Patterns;

        /// <summary>
        /// The underlying generic WFC algorithm.
        /// </summary>
        private GenericWfc _Wfc;


        /// <summary>
        /// Constructor initializing the WFC.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="options"></param>
        /// <param name="seed"></param>
        public OverlappingWfc(Array2D<T> input, OverlappingWfcOptions options, int seed)
        {
            _Input = input;
            _Options = options;

            var patternsAndProbabilities = GetPatterns(input, options);
            _Patterns = patternsAndProbabilities.Item1;

            var propagator = GenerateCompatible(_Patterns);
            _Wfc = new GenericWfc(options.PeriodicOutput, seed, patternsAndProbabilities.Item2, propagator, options.GetWaveHeight(), options.GetWaveWidth());

            // If necessary, the ground is set
            if (options.Ground)
                InitGround(_Wfc, input, _Patterns, options);
        }

        /// <summary>
        /// Run the Wfc algorithm and return the result if the algorithm succeeded.
        /// </summary>
        /// <returns></returns>
        public Array2D<T> Run()
        {
            var result = _Wfc.Run();
            return result != null ? ToImage(result) : null;
        }


        /// <summary>
        /// Init the ground of the output image.
        /// <para>The lowest middle pattern is used as a floor(and ceiling when the input is
        /// toric) and is placed at the lowest possible pattern position in the output
        /// image, on all its width.The pattern cannot be used at any other place in
        /// the output image.</para>
        /// </summary>
        /// <param name="wfc"></param>
        /// <param name="input"></param>
        /// <param name="patterns"></param>
        /// <param name="options"></param>
        private static void InitGround(GenericWfc wfc, Array2D<T> input, Array2D<T>[] patterns, OverlappingWfcOptions options)
        {
            var groundPatternId = GetGroundPattenId(input, patterns, options);

            // Place the pattern in the ground
            for (UInt32 j = 0; j < options.GetWaveWidth(); j++)
                for (UInt32 p = 0; p < patterns.Length; p++)
                    if (groundPatternId != p)
                        wfc.RemoveWavePattern(options.GetWaveHeight() - 1, j, p);

            // Remove the pattern from the other positions
            for (UInt32 i = 0; i < options.GetWaveHeight() - 1; i++)
                for (UInt32 j = 0; j < options.GetWaveWidth(); j++)
                    wfc.RemoveWavePattern(i, j, groundPatternId);

            // Propagate the information with wfc
            wfc.Propagate();
        }

        /// <summary>
        /// Return the id of the lowest middle pattern.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="patterns"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static UInt32 GetGroundPattenId(Array2D<T> input, Array2D<T>[] patterns, OverlappingWfcOptions options)
        {
            // Get the pattern
            var groundPattern = input.GetSubArray(input.Height - 1, input.Width / 2, options.PatternSize, options.PatternSize);

            // Retrieve the id of the pattern
            for (UInt32 i = 0; i < patterns.Length; i++)
                if (groundPattern == patterns[i])
                    return i;

            // The pattern exists
            // assert(false) 
            return 0;
        }

        /// <summary>
        /// Return the list of patterns as well as their probabilities of apparition.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static Tuple<Array2D<T>[], double[]> GetPatterns(Array2D<T> input, OverlappingWfcOptions options)
        {
            var patternsId = new Dictionary<Array2D<T>, int>();
            var patterns = new List<Array2D<T>>();

            // The number of time a pattern is seen in the input image
            var patternsWeight = new List<double>();

            var symmetries = new Array2D<T>[8];
            UInt32 maxI = options.PeriodicInput ? input.Height : input.Height - options.PatternSize + 1;
            UInt32 maxJ = options.PeriodicInput ? input.Width : input.Width - options.PatternSize + 1;

            for (UInt32 i = 0; i < maxI; i++)
            {
                for (UInt32 j = 0; j < maxJ; j++)
                {
                    for (int s = 0; s < symmetries.Length; s++)
                        symmetries[s] = new Array2D<T>(options.PatternSize, options.PatternSize);

                    // Compute the symmetries of every pattern in the image
                    symmetries[0].Data = input.GetSubArray(i, j, options.PatternSize, options.PatternSize).Data;

                    symmetries[1].Data = symmetries[0].Reflected().Data;
                    symmetries[2].Data = symmetries[0].Rotated().Data;
                    symmetries[3].Data = symmetries[2].Reflected().Data;
                    symmetries[4].Data = symmetries[2].Rotated().Data;
                    symmetries[5].Data = symmetries[4].Reflected().Data;
                    symmetries[6].Data = symmetries[4].Rotated().Data;
                    symmetries[7].Data = symmetries[6].Reflected().Data;

                    // The number of symmetries in the option class define which symetries
                    // will be used
                    for (UInt32 k = 0; k < options.Symmetry; k++)
                    {
                        var index = 0;

                        // If the pattern already exist, we just have to increase its number
                        // of appearance
                        if (patternsId.TryGetValue(symmetries[k], out index))
                        {
                            patternsWeight[index] += 1;
                        }
                        else
                        {
                            patternsId.Add(symmetries[k], patterns.Count);

                            patterns.Add(symmetries[k]);
                            patternsWeight.Add(1);
                        }
                    }
                }
            }

            return new Tuple<Array2D<T>[], double[]>(patterns.ToArray(), patternsWeight.ToArray());
        }
        
        /// <summary>
        /// Return <c>true</c> if the pattern1 is compatible with pattern2
        /// when pattern2 is at a distance (dy, dx) from pattern1.
        /// </summary>
        /// <param name="pattern1">The first pattern.</param>
        /// <param name="pattern2">The second pattern.</param>
        /// <param name="dy">Y distance.</param>
        /// <param name="dx">X distance.</param>
        /// <returns></returns>
        private static bool Agrees(Array2D<T> pattern1, Array2D<T> pattern2, int dy, int dx)
        {
            UInt32 xmin = (UInt32)(dx < 0 ? 0 : dx);
            UInt32 xmax = (UInt32)(dx < 0 ? dx + pattern2.Width : pattern1.Width);
            UInt32 ymin = (UInt32)(dy < 0 ? 0 : dy);
            UInt32 ymax = (UInt32)(dy < 0 ? dy + pattern2.Height : pattern1.Height);

            // Iterate on every pixel contained in the intersection of the two pattern.
            for (UInt32 y = ymin; y < ymax; y++)
                for (UInt32 x = xmin; x < xmax; x++)
                    // Check if the color is the same in the two patterns in that pixel.
                    if (!pattern1[y, x].Equals(pattern2[y - (UInt32)dy, x - (UInt32)dx]))
                        return false;
            return true;
        }

        /// <summary>
        /// Precompute the function agrees(pattern1, pattern2, dy, dx).
        /// If agrees(pattern1, pattern2, dy, dx), then compatible[pattern1][direction]
        /// contains pattern2, where direction is the direction defined by(dy, dx).
        /// </summary>
        /// <param name="patterns">The patterns.</param>
        /// <returns>Compatible.</returns>
        private static List<UInt32>[][] GenerateCompatible(Array2D<T>[] patterns)
        {
            var compatible = new List<UInt32>[patterns.Length][];

            for (UInt32 pattern1 = 0; pattern1 < patterns.Length; pattern1++)
            {
                compatible[pattern1] = new List<uint>[4];
                for (int direction = 0; direction < 4; direction++)
                {
                    compatible[pattern1][direction] = new List<UInt32>();
                    for (UInt32 pattern2 = 0; pattern2 < patterns.Length; pattern2++)
                        if (Agrees(patterns[pattern1], patterns[pattern2], Direction.DirectionsY[direction], Direction.DirectionsX[direction]))
                            compatible[pattern1][direction].Add(pattern2);
                }
            }
            return compatible;
        }

        /// <summary>
        /// Transform a 2D array containing the patterns id to a 2D array containing
        /// the pixels.
        /// </summary>
        /// <param name="outputPatterns">The 2D array containing the patterns.</param>
        /// <returns>2D array containing the pixels.</returns>
        private Array2D<T> ToImage(Array2D<UInt32> outputPatterns)
        {
            var output = new Array2D<T>(_Options.OutputHeight, _Options.OutputWidth);

            if (_Options.PeriodicOutput)
            {
                for (UInt32 y = 0; y < _Options.GetWaveHeight(); y++)
                    for (UInt32 x = 0; x < _Options.GetWaveWidth(); x++)
                        output[y, x] = _Patterns[outputPatterns[y, x]][0, 0];
            }
            else
            {
                for (UInt32 y = 0; y < _Options.GetWaveHeight(); y++)
                    for (UInt32 x = 0; x < _Options.GetWaveWidth(); x++)
                        output[y, x] = _Patterns[outputPatterns[y, x]][0, 0];

                for (UInt32 y = 0; y < _Options.GetWaveHeight(); y++)
                {
                    var patternX = _Patterns[outputPatterns[y, _Options.GetWaveWidth() - 1]];
                    for (UInt32 dx = 1; dx < _Options.PatternSize; dx++)
                        output[y, _Options.GetWaveWidth() - 1 + dx] = patternX[0, dx];
                }

                for (UInt32 x = 0; x < _Options.GetWaveWidth(); x++)
                {
                    var patternY = _Patterns[outputPatterns[_Options.GetWaveHeight() - 1, x]];
                    for (UInt32 dy = 1; dy < _Options.PatternSize; dy++)
                        output[_Options.GetWaveHeight() - 1 + dy, x] = patternY[dy, 0];
                }

                var pattern = _Patterns[outputPatterns[_Options.GetWaveHeight() - 1, _Options.GetWaveWidth() - 1]];
                for (UInt32 dy = 1; dy < _Options.PatternSize; dy++)
                    for (UInt32 dx = 1; dx < _Options.PatternSize; dx++)
                        output[_Options.GetWaveHeight() - 1 + dy, _Options.GetWaveWidth() - 1 + dx] = pattern[dy, dx];
            }

            return output;
        }
    }
}
