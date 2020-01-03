namespace lp2_project2
{
    /// <summary>
    /// this struct allows us to set gameobjects' positions with an y and x
    /// coordinates
    /// </summary>
    public struct Positions
    {
        // getting an X and Y coordinate
        public int X;
        public int Y;

        /// <summary>
        /// this constructor stores the two coordinates for our position
        /// </summary>
        /// <param name="x">x coordinate (horizontal)</param>
        /// <param name="y">y coordinate (vertical)</param>
        public Positions(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
