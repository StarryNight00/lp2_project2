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
            

            db[startPos.X, startPos.Y] = ' ';
            db[newPos.X, newPos.Y] = 'X';
           
            /*
            Console.SetCursorPosition(startPos.X, startPos.Y);
            Console.Write(" ");
            Console.SetCursorPosition(newPos.X, newPos.Y);
            Console.Write("X");  
           */
        }
    }
}
