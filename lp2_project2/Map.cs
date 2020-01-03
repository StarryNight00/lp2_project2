using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Map
    {
        private int maxX = 60;

        private int maxY = 20;

        private DoubleBuffer2D<char> db;

        public Map(DoubleBuffer2D<char> doubleBuffer)
        {
            db = doubleBuffer;
        }
        public void Print()
        {

            // set each character in the buffer to the default
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    Random rnd = new Random(); 

                    
                     if(rnd.Next(0,200) < 2)
                         db[x, y] = '*';

                     else
                         db[x, y] = ' ';
                         
                }
            }
        }

    }
}
