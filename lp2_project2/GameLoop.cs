using System;
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
            Console.CursorVisible = false;
            
            
            db = new DoubleBuffer2D<char>(60, 60);
            platforms = new Platforms(db);
            plyr = new Player(db);
            input = new InputsSystem(plyr, db);

            for(int x = 0; x < db.XDim; x++)
            {
                for (int y = 0; y < db.YDim; y++)
                {
                    db[y, x] = ' ';
                }
            }


            Thread KeyReader = new Thread(input.ReadKeys);
            KeyReader.Start();
            Console.CursorVisible = false;
        }

        public void Loop()
        {

            Console.Clear();
            running = true;

            while (running)
            {

                Update(input.ProcessInput());

                Render();
                Thread.Sleep(50);

                if (plyr.startPos.Y >= db.YDim)
                {
                    running = false;
                }

                if (plyr.startPos.X >= db.XDim)
                {
                    running = false;
                }

                Thread.Sleep(1000);
            }
        }
        public void Update(Jump jump)
        {
            plyr.newPos.X = plyr.startPos.X++;
            platforms.newPos.X = platforms.startPos.X++;

            if (jump != Jump.Idle)
            {
                switch (jump)
                {
                    case Jump.Jumping:
                        plyr.newPos.Y = Math.Max(0, plyr.newPos.Y - 1);
                        jump = Jump.Hovering;
                        break;

                    case Jump.Hovering:
                        jump = Jump.Falling;
                        break;

                    case Jump.Falling:
                        plyr.newPos.Y = Math.Max(0, plyr.newPos.Y + 1);
                        jump = Jump.Falling;
                        break;
                }      
            }
        }

        public void Render()
        {
            Console.Clear();
            plyr.RenderPlayer();
            platforms.PrintPlatforms();     

            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    Console.Write(db[x, y]);
                }
                Console.WriteLine();
            }
            db.Swap();

            db.Clear();
                    
        }
    }
}
