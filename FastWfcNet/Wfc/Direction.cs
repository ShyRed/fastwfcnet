namespace FastWfcNet.Wfc
{
    public static class Direction
    {
        public static readonly int[] DirectionsX = new[] {  0, -1, 1, 0 };
        public static readonly int[] DirectionsY = new[] { -1,  0, 0, 1 };

        /// <summary>
        /// Return the opposite direction of <c>direction</c>.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The opposite direction.</returns>
        public static int GetOppositeDirection(int direction)
        {
            return 3 - direction;
        }
    }
}
