using System;
using System.Collections.Generic;

namespace lp2_project2
{
    /// <summary>
    /// this class let's us set the platforms and print them on the screen
    /// </summary>
    class Platforms : GameObject
    {

        public Positions keyPlatform;

        public char platform = '#';
        public char hole = '_';

        /// <summary>
        /// the doublebuffer will allow smooth printing
        /// </summary>
        public DoubleBuffer2D<char> db;

        /// <summary>
        /// this class sets moving platforms 
        /// in a specified area on the console with different properties for
        /// platforms and holes
        /// </summary>
        /// <param name="doubleb"></param>
        public Platforms(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;

            Character = ' ';

            ID = 1;
        }

        /// <summary>
        /// this method allows us to set the lower platforms
        /// </summary>
        private void SetLowerPlatforms()
        {
            for (int y = db.YDim - 2; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                    db[x, y] = platform;
            }        

        }

        /// <summary>
        /// this method is to be called on the update method of the game loop
        /// it updates the platforms' positions and allows them to move
        /// </summary>
        public void PlatformUpdate()
        {

        }

        /// <summary>
        /// this method prints the platforms in their area according to their
        /// position and using the doublebuffer
        /// </summary>
        public void PrintPlatforms()
        {
            Random rnd = new Random();

            int rand = rnd.Next(1, 2);    

            if (rnd.Next(1, 10) > 1)
            {
                db[0, db.YDim - 3] = platform;
            }

            else
            {
                db[0, db.YDim - 3] = hole;
            }

            for (int x = 2; x < db.XDim - 1; x++)
            { 
                if(db[x-1, db.YDim - 3] == hole && db[x - 2, db.YDim - 3]
                    == hole)
                    db[x-2, db.YDim - 3] = platform;
                db[x, db.YDim - 3] = db[x - 2, db.YDim - 3];
            }

            SetLowerPlatforms();
        }
    }
}