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
            doubleBuff = db;
        }

        public void ProcessInput()
        {
            ConsoleKey key;
            if(input.TryTake(out key))
            {
                switch(key)
                {
                    case ConsoleKey.Spacebar:
                        jump = Jump.Jumping;
                        break;
                    // add escape
                    default:
                        jump = Jump.Idle;
                        break;
                }
            }
        }

        public void Update()
        {
            plyr.currentPos.X = plyr.newPos.X++;

            if (jump != Jump.Idle)
            {
                plyr.currentPos = plyr.newPos;

                switch (jump)
                {
                    case Jump.Jumping:
                        plyr.newPos.Y = Math.Max(0, plyr.currentPos.Y+1);
                        // add condition to make it go back down
                        break;
                }
            }
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
