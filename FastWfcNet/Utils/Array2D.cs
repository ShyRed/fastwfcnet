using System;

namespace FastWfcNet.Utils
{
    /// <summary>
    /// Represent a 2D array.
    /// <para>The 2D array is stored in a single array to improve cache usage.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Array2D<T> : IEquatable<Array2D<T>>
    {
        /// <summary>
        /// The height of the 2D array.
        /// </summary>
        public UInt32 Height;

        /// <summary>
        /// The width of the 2D array.
        /// </summary>
        public UInt32 Width;

        /// <summary>
        /// The array containing the data of the 2D array.
        /// </summary>
        public T[] Data;

        /// <summary>
        /// Gets / Sets the value at the given position in the 2D array.
        /// </summary>
        /// <param name="i">Must be lower than height.</param>
        /// <param name="j">Must be lower than width.</param>
        /// <returns>The value at the specified position in the 2D array.</returns>
        public T this[UInt32 i, UInt32 j]
        {
            get
            {
                return Data[j + i * Width];
            }
            set
            {
                Data[j + i * Width] = value;
            }
        }

        /// <summary>
        /// Builds are 2D array given its height and width.
        /// </summary>
        /// <param name="height">The 2D array height.</param>
        /// <param name="width">The 2D array width.</param>
        public Array2D(UInt32 height, UInt32 width)
        {
            Height = height;
            Width = width;
            Data = new T[width * height];
        }

        /// <summary>
        /// Builds are 2D array given its height and width.
        /// <para>All the array elements are initialized to <c>value</c>.</para>
        /// </summary>
        /// <param name="height">The 2D array height.</param>
        /// <param name="width">The 2D array width.</param>
        /// <param name="value">The initial value.</param>
        public Array2D(UInt32 height, UInt32 width, T value)
            : this(height, width)
        {
            for (UInt32 i = 0; i < width * height; i++)
                Data[i] = value;
        }

        /// <summary>
        /// Returns the current 2D array reflected along the x axis.
        /// </summary>
        /// <returns>A copy of the current 2D array reflected along the x axis.</returns>
        public Array2D<T> Reflected()
        {
            var result = new Array2D<T>(Height, Width);
            for (UInt32 y = 0; y < Height; y++)
            {
                for (UInt32 x = 0; x < Width; x++)
                {
                    result[y, x] = this[y, Width - 1 - x];
                }
            }
            return result;
        }

        /// <summary>
        /// Return the current 2D array rotated 90 degress anticlockwise.
        /// </summary>
        /// <returns>A copy of the current 2D array rotated 90 degress anticlockwise.</returns>
        public Array2D<T> Rotated()
        {
            var result = new Array2D<T>(Width, Height);
            for (UInt32 y = 0; y < Width; y++)
            {
                for (UInt32 x = 0; x < Height; x++)
                {
                    result[y, x] = this[x, Width - 1 - y];
                }
            }
            return result;
        }

        /// <summary>
        /// Return the sub 2D array starting from (x, y) and with size (sub_width, sub_height).
        /// The current 2D array is considered toric for this operation.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="sub_width"></param>
        /// <param name="sub_height"></param>
        /// <returns></returns>
        public Array2D<T> GetSubArray(UInt32 y, UInt32 x, UInt32 sub_width, UInt32 sub_height)
        {
            var subArray = new Array2D<T>(sub_height, sub_width);
            for (UInt32 ki = 0; ki < sub_height; ki++)
            {
                for (UInt32 kj = 0; kj < sub_width; kj++)
                {
                    subArray[ki, kj] = this[(y + ki) % Height, (x + kj) % Width];
                }
            }
            return subArray;
        }

        /// <summary>
        /// Assigns the current matrix the specified matrix. Data-values are
        /// taken by reference.
        /// </summary>
        /// <param name="source">The source matrix.</param>
        public void AssignFrom(Array2D<T> source)
        {
            this.Height = source.Height;
            this.Width = source.Width;
            this.Data = source.Data;
        }

        public static bool operator==(Array2D<T> a, Array2D<T> b)
        {
            return object.ReferenceEquals(a, b) || a.Equals(b);
        }

        public static bool operator !=(Array2D<T> a, Array2D<T> b)
        {
            return !(object.ReferenceEquals(a, b) || a.Equals(b));
        }

        public bool Equals(Array2D<T> other)
        {
            if (object.ReferenceEquals(other, null) || Width != other.Width || Height != other.Height)
                return false;

            for (UInt32 i = 0; i < Data.Length; i++)
                if (!Data[i].Equals(other.Data[i]))
                    return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Array2D<T>);
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
                foreach (var data in Data)
                    hash = (hash * HashingMultiplier) ^ data.GetHashCode();
                return hash;
            }
        }
    }
}
