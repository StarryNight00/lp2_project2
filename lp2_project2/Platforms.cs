using System;

namespace lp2_project2
{
    /// <summary>
    /// this class let's us set the platforms and print them on the screen
    /// </summary>
    class Platforms
    {
        /// <summary>
        /// the doublebuffer will allow smooth printing
        /// </summary>
        public DoubleBuffer2D<char> db;

        /// <summary>
        /// this class sets moving platforms 
        /// in a specified area on the console with different properties for
        /// platforms and holes
        /// </summary>
        public Platforms(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;
        }

        /// <summary>
        /// this method allows us to set the lower platforms
        /// </summary>
        private void SetLowerPlatforms()
        {
            // checks two lowest rows and prints platforms across it
            for (int y = db.YDim - 2; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                    db[x, y] = (char)Characters.platforms;
            }
        }

        /// <summary>
        /// this method prints the platforms in their area according to their
        /// position and using the doublebuffer
        /// </summary>
        public void RenderPlatforms()
        {
            // creates new random to set different platforms and holes
            Random rnd = new Random();

            // sets a platform
            if (rnd.Next(1, 10) > 1)
            {
                db[0, db.YDim - 3] = (char)Characters.platforms;
            }

            // set a hole
            else
            {
                db[0, db.YDim - 3] = (char)Characters.holes;
            }

            // moves the holes and platforms according to last
            for (int x = 2; x < db.XDim - 1; x++)
            {
                if (db[x - 1, db.YDim - 3] == (char)Characters.holes &&
                    db[x - 2, db.YDim - 3]
                    == (char)Characters.holes)
                    db[x - 2, db.YDim - 3] = (char)Characters.platforms;
                db[x, db.YDim - 3] = db[x - 2, db.YDim - 3];
            }

            // sets the platforms on the two lower "floors"
            SetLowerPlatforms();
        }
    }
}