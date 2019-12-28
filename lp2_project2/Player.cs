using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Player
    {
        public Positions currentPos;
        public Positions newPos;

        public Player()
        {
            currentPos = new Positions(0,0);
        }
    }
}
