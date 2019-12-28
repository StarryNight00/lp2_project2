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
            platforms = new Platforms();
            
            db = new DoubleBuffer2D<char>(60, 60);
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

                /// platform test 
                
                Positions platformStart = platforms.platformElements.Last();
               
                platforms.platformElements.Dequeue();

                if (platformStart.X < Console.BufferWidth-1)
                {
                    Positions newPlatformStart = new Positions(platformStart.X
                        + 1, platformStart.Y);

                    platforms.MovePlatforms(newPlatformStart);

                    platforms.PrintPlatforms(db);

                    Thread.Sleep(1000);
                }

                else
                {
                    platforms.platformElements.Dequeue();
                    platformStart.X = 1;
                    Thread.Sleep(100);
                }

                // fix this condition for when it hits hole
                foreach (Positions pos in platforms.platformElements)
                {
                    if (pos.Y == plyr.newPos.Y)
                        Console.Write("Collision");
                }     
                
                // platform test end                
            }
        }
        public void Update(Jump jump)
        {
            plyr.newPos.X = plyr.startPos.X++;

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
            platforms.PrintPlatforms(db);         

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
