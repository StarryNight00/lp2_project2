using System;
using System.Collections.Generic;

namespace lp2_project2
{
    /// <summary>
    /// this class let's us set the platforms and print them on the screen
    /// </summary>
    class Platforms : GameObject
    {

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

            SetPlatforms();

            Character = ' ';

            ID = 1;
        }

        /// <summary>
        /// this method allows us to reset the platforms when they reach the
        /// end of the console
        /// </summary>
        public void SetPlatforms()
        {


        }

        /// <summary>
        /// this method allows us to move the platforms on the console
        /// </summary>
        /// <param name="headPos">last known position</param>
        public void MovePlatforms(Positions headPos)
        {

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
        /// BUG : PRINTS RANDOMLY EVERY TIME, THIS HAS TO BE MOVED ELSEWHERE
        /// </summary>
        public void PrintPlatforms()
        {
            Random rnd = new Random();

            int rand = rnd.Next(1, 2);

            if (rnd.Next(1, 10) > 1)
            {
                db[0, db.YDim - 2] = platform;
            }

            else
            {
                db[0, db.YDim - 2] = hole;
            }

            for (int x = 1; x < db.XDim - 1; x++)
                db[x, db.YDim - 2] = db[x - 1, db.YDim - 2];

            for (int x = 0; x < db.XDim - 1; x++)
                db[x, db.YDim - 1] = platform;
        }
    }
}