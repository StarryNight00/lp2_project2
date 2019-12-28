using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace lp2_project2
{
    class InputsSystem
    {
        public BlockingCollection<ConsoleKey> input;
        public Jump jump;

        public Player plyr;

        public DoubleBuffer2D<char> doubleBuff;

        public InputsSystem(Player player, DoubleBuffer2D<char> db)
        {
            input = new BlockingCollection<ConsoleKey>();
            jump = new Jump();
            plyr = player;
            plyr.startPos = new Positions(9, 9);
            plyr.newPos = plyr.startPos;
            //doubleBuff = db;
        }

        public Jump ProcessInput()
        {
            ConsoleKey key;
            if(input.TryTake(out key))
            {
                if(key == ConsoleKey.Spacebar)
                    return Jump.Jumping;           
                                       
            }
            return Jump.Idle;
        }
     

        public void ReadKeys()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                input.Add(key);

            }
            while (key != ConsoleKey.Escape);
        }
    }
}
