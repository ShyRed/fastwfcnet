using System;

namespace FastWfcNet.Utils
{
    /// <summary>
    /// Represent a 3D array.
    /// <para>The 3D array is stored in a signle array to improve cache usage.</para>
    /// </summary>
    public sealed class Array3D<T> : IEquatable<Array3D<T>>
    {
        /// <summary>
        /// The height of the 3D array.
        /// </summary>
        public UInt32 Height;

        /// <summary>
        /// The width of the 3D array.
        /// </summary>
        public UInt32 Width;

        /// <summary>
        /// The depth of the 3D array.
        /// </summary>
        public UInt32 Depth;

        /// <summary>
        /// The array containing the data of the 3D array.
        /// </summary>
        public T[] Data;

        /// <summary>
        /// Gets / Sets the element at the specified position.
        /// </summary>
        /// <param name="i">i must be lower than height.</param>
        /// <param name="j">j must be lower than width.</param>
        /// <param name="k">k must be lower than depth.</param>
        /// <returns></returns>
        public T this[UInt32 i, UInt32 j, UInt32 k]
        {
            get
            {
                return Data[i * Width * Depth + j * Depth + k];
            }
            set
            {
                Data[i * Width * Depth + j * Depth + k] = value;
            }
        }

        /// <summary>
        /// Build a 3D array given its height, width and depth.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="depth">The depth.</param>
        public Array3D(UInt32 height, UInt32 width, UInt32 depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
            Data = new T[height * width * depth];
        }

        /// <summary>
        /// Build a 3D array given its height, width and depth.
        /// <para>The array elements are initialized to <c>value</c>.</para>
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="value">The initial value.</param>
        public Array3D(UInt32 height, UInt32 width, UInt32 depth, T value)
            : this(height, width, depth)
        {
            for (UInt32 i = 0; i < Data.Length; i++)
                Data[i] = value;
        }

        public bool Equals(Array3D<T> other)
        {
            if (Width != other.Width || Height != other.Height || Depth != other.Depth)
                return false;

            for (UInt32 i = 0; i < Data.Length; i++)
                if (!Data[i].Equals(other.Data[i]))
                    return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Array3D<T>);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Width.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Height.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Depth.GetHashCode();
                foreach (var data in Data)
                    hash = (hash * HashingMultiplier) ^ data.GetHashCode();
                return hash;
            }
        }
    }
}
