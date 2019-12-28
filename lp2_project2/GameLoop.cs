using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            //Console.Clear();
            running = true;
            
            
            while(running)
            {
                foreach (Positions pos in platforms.platformElements)
                {
                    Console.SetCursorPosition(pos.X, pos.Y);
                    Console.Write("#");
                }

                long start = DateTime.Now.Ticks;

                input.ProcessInput();
                input.Update();
                Render();


                plyr.currentPos.X++;
            }
        }

        public void Render()
        {
            db[plyr.currentPos.X, plyr.currentPos.Y] = 'X';
            db[plyr.newPos.X, plyr.newPos.Y] = ' ';

            db.Swap();

            for(int y = 0; y < db.YDim; y++)
            {
                for(int x = 0; x < db.XDim; x++)
                {
                    Console.Write(db[x, y] + " ");
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, 0);
            db.Clear();
        }
    }
}
