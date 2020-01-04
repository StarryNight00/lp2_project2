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
        private HighScore hs;

        public Map background;


        string[] helpMssgs = new string[]
                {
                "      press space to jump!    ",
                "platforms have different sizes"
                    // add more

                };

        private string ChosenMessage;

        int score = 0;

        private int msPerFrame = 80;
        // gets the current objects in the game inside a list
      
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
        public GameLoop(HighScore hs)
        {
            this.hs = hs;

            // sets the cursor's visibility to false so it won't render
            Console.CursorVisible = false;

            Random rnd = new Random();

            int rand = rnd.Next(0, helpMssgs.Length);

            int counter = 20;

            ChosenMessage = helpMssgs[rand];

            // creates a new doublebuffer for our map with 60x60 dimensions
            db = new DoubleBuffer2D<char>(60, 20);

            background = new Map(db);

            // creates our platforms and assigns the current buffer
            platforms = new Platforms(db);

            // creates our player and assigns the current buffer
            plyr = new Player(db);

            platforms.keyPlatform = new Positions(plyr.Position.X, 
                plyr.Position.Y);
          
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

                Console.WriteLine(start);
                // call the update method to move things on the screen
                Update();       

                // render our current game window 
                Render();


                if (input.jump == Jump.Leave)
                {

                    running = false;

                    Console.WriteLine(score);
                    MenuPrints.PrintGameOver(score, hs);
                }

                if (input.jump == Jump.Check)
                {
                    Thread.Sleep(60);
                    CheckCollision();
                    

                }

                if (input.jump == Jump.Falling)
                {
                    Thread.Sleep(60);
                    plyr.Position.Y += 2;
              
                    input.jump = Jump.Idle;
                    score += 1;
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
            // check if there's been a collision and act accordingly
            CheckCollision();

            // add later
            //platforms.PlatformUpdate();

            // check if there's any input happening and act accordingly
            if (input.jump != Jump.Idle)
            {
                // get player input
                switch (input.jump)
                {
                    // this will move the player up by one on the Y axis
                    case Jump.Jumping:
                        Thread.Sleep(60);
                        plyr.Position.Y -= 1; 
                        input.jump = Jump.Falling;
                        break;
                    
                    /// LEAVE THIS HERE FOR FUTURE SHOWING OF HS ETC
                    case Jump.Leave:
                        Thread.Sleep(60);
                        RenderLosingScreen();
                        Render();
                        Console.WriteLine("bye!");
                        break;
                }                         
            }
        }     
        public void CheckCollision()
        {
            if (plyr.Position.Y > db.YDim - 2)
            {
                plyr.Position.Y = db.YDim - 4;
            }
            
            if (input.jump == Jump.Check || input.jump == Jump.Falling)
            {
                if (plyr.Position.Y == db.YDim - 3)
                {
                    Console.WriteLine("ouch");
                    Console.Clear();
                    running = false;

                    MenuPrints.PrintGameOver(score, hs);
                    // On Collison make losing sound
                    Console.Beep(600, 500);
                    MenuPrints.PrintGameOver(score, hs);

                }
            }
          
            if (input.jump == Jump.Idle)
            {

                if (db[plyr.Position.X, plyr.Position.Y + 1] == platforms.hole)
                {

                    plyr.Position.Y += 1;
                    input.jump = Jump.Check;

                }

                if (db[plyr.Position.X, plyr.Position.Y]
                      == platforms.platform)
                {
                    // increase player position so it doesn't disappear
                    plyr.Position.Y -= 1;
                }

            }
        }

        public void WriteHelpMessages()
        {
            string[] helpMssgs = new string[]
                {
                "      press space to jump!    ",
                "platforms have different sizes"

                };

            Random rnd = new Random();

            int rand = rnd.Next(0, helpMssgs.Length);

            int counter = 20;

            foreach (char mssg in ChosenMessage)
            { 
                db[counter, 16] = mssg;
                counter++;
            }
                         
        }

        /// <summary>
        /// FUNCTIONAL BUT LOOKING FOR BEST WAY TO PRINT WHILE INGAME SO NOT 
        /// BEING USED //YET//
        /// </summary>
        public void RenderLosingScreen()
        {
        
            string GameOverRender = 
             @"________p" +
             @"/  _____/_____    _____   ____   _______  __ ___________p" +
            @"/   \  ___\__  \  /     \_/ __ \ /  _ \  \/ // __ \_  _ \p" +
            @"\    \_\  \/ __ \|  Y Y  \  ___/(  <_> )   /\  ___/| | \/p" +
              @"\______  (____  /__|_|  /\___  >\____/ \_/  \___  >_|p" +
                    @"\/     \/      \/     \/                   \/p" +
                          @"You crashed!!";
            
            string[] GameOverSplit = GameOverRender.Split('p');

            string deadBuggy = ".   º    . O  _ X 0  .";

            int y = 0;
            foreach (string line in GameOverSplit)
            {
                printLine(line, 0, y);
                y++;
            }

            printLine(deadBuggy, plyr.Position.X-20, plyr.Position.Y);
        }

        public void printLine(string lineToPrint, int lineStartX, int lineY)
        {

            int x = lineStartX;
            foreach (char character in lineToPrint)
            {
                db[x, lineY] = character;
                x++;
            }

        }

        /// <summary>
        /// this method allows us to set the characters in the doublebuffer and
        /// print them on the console according to each position change
        /// </summary>
        public void Render()
        {
            // set cursor at start of screen for proper printing
            Console.SetCursorPosition(0, 0);

            // print the background
            background.Print();

            plyr.RenderPlayer();

            // set platforms to their corresponding characters
            platforms.PrintPlatforms();

            WriteHelpMessages();

           

            // swap between the doublebuffer's arrays to render each frame
            db.Swap();

            // print the doublebuffer's array on the console
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                  
                    if (db[x, y] == (char)Characters.holes)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (db[x, y] == (char)Characters.tankHead)
                    {
                        Console.ForegroundColor = ConsoleColor.White;            
                    }

                    if (db[x, y] == (char)Characters.platforms)
                    {
                        if (db[x, y] == db[platforms.keyPlatform.X, 
                            platforms.keyPlatform.Y])
                            Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(db[x, y]);
                    Console.ResetColor(); 

                }
                Console.WriteLine();
            }

            // CHANGE THIS TO JUMPS
            Console.Write($"Distance: {score}\n");
            Console.WriteLine("[ESC] to quit   [SPACE] to jump");
        }
    }
}
