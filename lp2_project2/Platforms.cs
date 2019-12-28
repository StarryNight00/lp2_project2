using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Platforms
    {
        public char[] platforms;
        
        public Positions startPos;
        public Positions newPos;

        public DoubleBuffer2D<char> db;

        public List<Positions> platformArea;

        public Platforms(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;
            startPos = new Positions(11,10);

            platforms = new char[]
            {
                '#', '.', '#', '#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#','#', '.', '#',
            };

            platformArea = new List<Positions>();
            
            for(int x = 0; x<60; x++)
            {
                for (int y = 0; y < 60; y++)
                {
                    platformArea.Add(new Positions(x, 0));    
                }
            }
        }

        public void MovePlatforms()
        {
            // new logic later
        }

        public void PrintPlatforms()
        {
            
            foreach(Positions pos in platformArea)
                db[pos.X, pos.Y] = platforms[pos.X];
                       
        }
       
    }
}
