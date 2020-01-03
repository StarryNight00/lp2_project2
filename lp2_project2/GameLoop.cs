using System;
using System.Threading;
using System.Collections.Generic;

namespace lp2_project2
{
    /// <summary>
    /// this class allows us to create the main loop to run our game using
    /// threads and a doublebuffer to rend everything smoothly
    /// </summary>
    class GameLoop
    {
        int frame = 0;
        private int msPerFrame = 60;
        // gets the current objects in the game inside a list
        // NOT USED YET!
        public List<GameObject> objectsInGame = new List<GameObject>();

        // initiates the platforms that will be displayed along the loop
        public Platforms platforms;

        // initiates our player 
        public Player plyr;

        // initiates our doublebuffer for smooth rendering
        public DoubleBuffer2D<char> db;

        // initiates our inputsystem to handle player's inputs during thread
        public InputsSystem input;

        // to check if the game is currently running
        public bool running;
        
        /// <summary>
        /// this constructor allows us to set our initial values for the game
        /// and prepare the console for optimised running
        /// </summary>
        public GameLoop()
        {
            // sets the cursor's visibility to false so it won't render
            Console.CursorVisible = false;
               
            // creates a new doublebuffer for our map with 60x60 dimensions
            db = new DoubleBuffer2D<char>(60, 20);

            // creates our platforms and assigns the current buffer
            platforms = new Platforms(db);

            // creates our player and assigns the current buffer
            plyr = new Player(db);
            plyr.newPos = new Positions(10, 8);

            // prepares to read input and process it
            input = new InputsSystem();

            // starts our thread according to user input
            Thread KeyReader = new Thread(input.ReadKeys);
            KeyReader.Start();
   
        }

        /// <summary>
        /// this method serves as the main loop to call our major functions
        /// until the game stops
        /// </summary>
        public void Loop()
        {
            // set running to true to begin loop
            running = true;

            input.jump = Jump.Idle;

            // while losing conditions haven't been met
            while (running)
            {
                long start = DateTime.Now.Ticks;
                // check if the player has jumped
                input.jump = input.ProcessInput();

                // call the update method to move things on the screen
                Update();

                platforms.PlatformUpdate();

              

                // render our current game window 
                Render();
                //Thread.Sleep(100);

                CheckCollision();

                if (input.jump == Jump.Hovering)
                {
                    plyr.newPos.Y -= 1;
                    input.jump = Jump.Falling;
                }

                if (input.jump == Jump.Falling)
                {
                    plyr.newPos.Y += 3;
                    input.jump = Jump.Idle;
                }

                Thread.Sleep(
                   (int)(start / TimeSpan.TicksPerSecond)
                   + msPerFrame
                   - (int)(DateTime.Now.Ticks / TimeSpan.TicksPerSecond));
            }
        }

        /// <summary>
        /// this method will be used to update onscreen positions and displays
        /// </summary>
        public void Update()
        {
           // check if there's any input happening and act accordingly
            if (input.jump != Jump.Idle)
            {
                // if player has hit spacebar
                switch (input.jump)
                {
                    // this will move the player up by one on the Y axis
                    case Jump.Jumping:
                        plyr.newPos.Y = Math.Max(0, plyr.newPos.Y - 1); ;
                        input.jump = Jump.Hovering;
                        break;
                }    
                
            }
        }
        
        public void CheckCollision()
        {
            // temporary collision check with platforms
            foreach (Positions pos in platforms.platformElements)
            {
                // check if player position equals hole after jump
                if (pos.X == plyr.newPos.X && db[pos.X, pos.Y] == '.')
                {
                    // check if player isn't jumping or is falling
                    if(input.jump != Jump.Hovering && input.jump!= Jump.Jumping)
                    { 
                        // increase player position so it doesn't disappear
                        plyr.newPos.Y += 1;

                        // On Collison make loosing sound
                        Console.Beep(600, 500);

                        // debug
                        //Console.WriteLine("Collision");

                        //running = false;
                    }             
                }

                // check if player position equals platform after jump
                else if (pos.Y == plyr.newPos.Y && pos.X == plyr.newPos.X
                    && db[pos.X, pos.Y] == '#')
                {
                    // doesn't let player fall
                    plyr.newPos.Y -= 1;
                }
            }
        }

        

        /// <summary>
        /// this method allows us to set the characters in the doublebuffer and
        /// print them on the console according to each position change
        /// </summary>
        public void Render()
        {
  

            // TBH IDK WHY THIS ONE WORKS FOR RENDERING
            Console.SetCursorPosition(0, 0);

            // set each character in the buffer to the default
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    db[x,y] = ' ';
                }
           
            }

            // set player to it's character
            plyr.RenderPlayer();

            // set platforms to their corresponding characters
            platforms.PrintPlatforms();

            //
            db.Swap();

            // print the doublebuffer's array on the console
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    Console.Write(db[x, y]);
                }
                Console.WriteLine();
            }

            // Render frame number (just for debugging purposes)
            Console.Write($"Frame: {frame++}\n");
                    
        }
    }
}
