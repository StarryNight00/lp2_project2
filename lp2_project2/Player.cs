using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Player
    {
        public Positions startPos;
        public Positions newPos;

        public DoubleBuffer2D<char> db;
        public Player(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;
        }

        public void RenderPlayer()
        {
            
            db[newPos.X, newPos.Y] = 'X';
  
        }
    }
}
