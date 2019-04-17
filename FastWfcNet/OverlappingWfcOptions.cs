using System;

namespace FastWfcNet
{
    public sealed class OverlappingWfcOptions
    {
        /// <summary>
        /// <c>true</c> if the input is toric.
        /// </summary>
        public bool PeriodicInput;

        /// <summary>
        /// <c>true</c> if the output is toric.
        /// </summary>
        public bool PeriodicOutput;

        /// <summary>
        /// The height of the output in pixels.
        /// </summary>
        public UInt32 OutputHeight;

        /// <summary>
        /// The width of the output in pixels.
        /// </summary>
        public UInt32 OutputWidth;

        /// <summary>
        /// The number of symmetries (the order is defined in wfc).
        /// </summary>
        public UInt32 Symmetry;

        /// <summary>
        /// <c>true</c> if the ground needs to be set (see init_ground).
        /// </summary>
        public bool Ground;

        /// <summary>
        /// The width and height in pixel of the patterns.
        /// </summary>
        public UInt32 PatternSize;

        /// <summary>
        /// Gets the wave height given these options.
        /// </summary>
        /// <returns>The wave height.</returns>
        public UInt32 GetWaveHeight()
        {
            return PeriodicOutput ? OutputHeight : OutputHeight - PatternSize + 1;
        }

        /// <summary>
        /// Gets the wave width given these options.
        /// </summary>
        /// <returns>The wave width.</returns>
        public UInt32 GetWaveWidth()
        {
            return PeriodicOutput ? OutputWidth : OutputWidth - PatternSize + 1;
        }
    }
}
