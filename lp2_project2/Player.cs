using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Player
    {
        public Positions startPos;
        public Positions currentPos;
        public Positions newPos;

        public Player()
        {
        }

        public void RenderPlayer()
        {
            Console.SetCursorPosition(currentPos.X, currentPos.Y);
            Console.Write(" ");
            Console.SetCursorPosition(newPos.X, newPos.Y);
            Console.Write("X");  
           
        }
    }
}
