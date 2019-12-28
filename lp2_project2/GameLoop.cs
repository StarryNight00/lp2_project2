using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Linq;

namespace lp2_project2
{
    class GameLoop
    {
        public Platforms platforms;
        public Player plyr;
        public DoubleBuffer2D<char> db;
        public InputsSystem input;
        public bool running;
        public GameLoop()
        {          
            platforms = new Platforms();
            plyr = new Player();
            db = new DoubleBuffer2D<char>(60, 60);
            input = new InputsSystem(plyr, db);
            Thread KeyReader = new Thread(input.ReadKeys);
            KeyReader.Start();
            Console.CursorVisible = false;
        }

        public void Loop()
        {
            Console.Clear();
            running = true;

            Console.SetCursorPosition(plyr.startPos.X, plyr.startPos.Y);
            Console.Write("X");

            plyr.currentPos = plyr.startPos;

            while (running)
            {
                long start = DateTime.Now.Ticks;

                input.ProcessInput();
                input.Update();
                Render();
                Thread.Sleep(1000);

                /// platform test 
                platforms.PrintPlatforms();
                
                Positions platformStart = platforms.platformElements.Last();
               
                platforms.platformElements.Dequeue();

                if (platformStart.X < Console.BufferWidth-1)
                {
                    Positions newPlatformStart = new Positions(platformStart.X
                        + 1, platformStart.Y);

                    platforms.MovePlatforms(newPlatformStart);

                    platforms.PrintPlatforms();

                   // Thread.Sleep(100);
                }

                else
                {
                    platforms.platformElements.Dequeue();
                    platformStart.X = 1;
                    Thread.Sleep(100);
                }

                // add condition for when it hits hole
                // platform test end             

                plyr.currentPos.Y++;
            
            }
        }

        public void Render()
        {
            plyr.RenderPlayer(db);


        }
    }
}
