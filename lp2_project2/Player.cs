using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Player
    {
        public Positions startPos = new Positions(20, 10);
        public Positions currentPos;
        public Positions newPos;

        public Player()
        {
            currentPos = startPos;
        }

        public void RenderPlayer(DoubleBuffer2D<char> db)
        {
            Console.SetCursorPosition(currentPos.X, currentPos.Y);
            Console.Write(" ");
            Console.SetCursorPosition(newPos.X, newPos.Y);
            Console.Write("X");  
            db.Swap();

           // Console.SetCursorPosition(0, 0);

            db.Clear();
        }
    }
}
