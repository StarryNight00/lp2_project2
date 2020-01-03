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
        public void Update()
        {
            Random rnd = new Random();

            int rand = rnd.Next(1,2);

            if (rnd.Next(1, 10) > 1)
            {
                db[0, maxY - 1] = '#';
            }

            else
            {
                db[0, maxY - 1] = '.';
            }
            
            for (int x = 1; x < maxX - 1; x++)
                db[x, maxY - 1] = db[x - 1, maxY - 1];
        }
        private void RenderMap()
        {

        }
    }
}
