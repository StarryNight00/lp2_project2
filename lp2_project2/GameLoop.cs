using System;
using System.Threading;

namespace lp2_project2
{
    /// <summary>
    /// this class allows us to create the main loop to run our game using
    /// threads and a doublebuffer to render everything smoothly
    /// </summary>
    class GameLoop
    {
        // initiates our doublebuffer for smooth rendering
        public DoubleBuffer2D<char> db;

        // initiates our inputsystem to handle player's inputs during thread
        public InputsSystem input;

        // to properly render with milliseconds
        private int msPerFrame = 80;

        // to get the highscore list
        private HighScore HS;

        // to get the score after each successful jump 
        private int score = 0;

        // to print the background of our game
        private Map background;

        // initiates the platforms that will be displayed along the loop
        private Platforms platforms;

        // initiates our player 
        private Player plyr;

        // to check if the game is currently running
        private bool running;

        // different help messages to show the player
        string[] helpMssgs = new string[]
                {
                "      press space to jump!    ",
                "platforms have different sizes"
                    // add more
                };

        // to select one random message to display each loop
        private string ChosenMessage;

        /// <summary>
        /// this constructor allows us to set our initial values for the game
        /// and prepare the console for optimised running
        /// </summary>
        public GameLoop(HighScore hs)
        {
            // set the highscore list
            HS = hs;

            // sets the cursor's visibility to false so it won't render
            Console.CursorVisible = false;

            ResetHelpMessages();

            // creates a new doublebuffer for our map with 60x60 dimensions
            db = new DoubleBuffer2D<char>(60, 20);

            // creates a new background with the size of the buffer's array
            background = new Map(db);

            // creates our platforms and assigns the current buffer
            platforms = new Platforms(db);

            // creates our player and assigns the current buffer
            plyr = new Player(db);

            /////////////////////////////////////////////////////////////////////
            platforms.keyPlatform = new Positions(plyr.Position.X,
                plyr.Position.Y+1);

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

            // set the player's jumping state to Idle to start
            input.jump = Jump.Idle;

            // while losing conditions haven't been met or ESC pressed
            while (running)
            {
                // get the current time for sleep later
                long start = DateTime.Now.Ticks;

                // check if the player has jumped or given any input
                input.jump = input.ProcessInput();

                // call the update method to move things on the screen
                Update();

                // render our current game window 
                Render();

                // checking if the jump is happening so it's whole motion 
                // is updated once per frame
                if (input.jump == Jump.Check)
                {
                    // check for collisions
                    CheckCollision();
                }

                // checking if the jump is happening so it's whole motion 
                // is updated once per frame
                if (input.jump == Jump.Falling)
                {
                    // changing player position to go down
                    plyr.Position.Y += 2;

                    // changing jump status to idle for new checks
                    input.jump = Jump.Idle;

                    // adding jump to the score
                    score += 1;

                    // changes displayed help message
                    ResetHelpMessages();
                }
               

                // sleep so the rendering looks smooth and "real time"
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

            // check if there's any input happening and act accordingly
            if (input.jump != Jump.Idle)
            {
                // get player input
                switch (input.jump)
                {
                    // this will move the player up by one on the Y axis
                    case Jump.Jumping:
                        // increase player position onscreen
                        plyr.Position.Y -= 1;
                        // change status to falling for new position check
                        input.jump = Jump.Falling;
                        break;

                    // checks if user has chosen to leave the game
                    case Jump.Leave:
                        // stop running loop
                        running = false;
                        //////////////////////////////////////////////////////////////
                        RenderLosingScreen();
                        Render();
                        break;                       
                }
            }
        }

        /// <summary>
        /// this method allows us to check for collisions based on player
        /// and platforms' positions during the update
        /// </summary>
        public void CheckCollision()
        {
            // check if the player position is inside the lower platforms
            if (plyr.Position.Y > db.YDim - 2)
            {
                // reset player position
                plyr.Position.Y = db.YDim - 4;
            }

            // check if player is on "check" (for collisions) or falling
            if (input.jump == Jump.Check || input.jump == Jump.Falling)
            {
                // if player is located on the hole row and not at the start
                if (plyr.Position.Y == db.YDim - 3)
                {
                    // show game over and leave the gameloop
                   /////////////////////////////////////////////////////////////////
                    running = false;
                    Render();
                    RenderLosingScreen();

                    // On Collison make losing sound
                    Console.Beep(600, 500);
                    MenuPrints.PrintGameOver(score, HS);

                }
            }

            // check if the player's movement is set to Idle
            if (input.jump == Jump.Idle)
            {
                // if player is about to hit a hole
                if (db[plyr.Position.X, plyr.Position.Y + 1] == (char)Characters.holes)
                {
                    // fall down
                    plyr.Position.Y += 1;

                    // check for input
                    input.jump = Jump.Check;

                }

                // if player's position is the same as a platform
                if (db[plyr.Position.X, plyr.Position.Y]
                      == (char)Characters.platforms)
                {
                    // increase player position so it doesn't disappear
                    plyr.Position.Y -= 1;
                }

            }
        }

        /// <summary>
        /// this method lets us print the mini messages for the player
        /// present in the original Moon Buggy for linux
        /// </summary>
        public void WriteHelpMessages()
        {
            // go through the chars and add them to the doubleBuffer
            printLine(ChosenMessage, 6, 12);

        }

        /// <summary>
        /// this method let's us reset the help message currently being
        /// displayed to a different one
        /// </summary>
        public void ResetHelpMessages()
        {
            // creates a new random so the help message displayed is different
            Random rnd = new Random();

            // getting one of the messages within the array
            int rand = rnd.Next(0, helpMssgs.Length);

            // sets the chosen message for display
            ChosenMessage = helpMssgs[rand];
        }

        /// <summary>
        /// this method allows us to render a game over message on the
        /// screen when the player loses the game
        /// </summary>
        public void RenderLosingScreen()
        {
            // string to render the message
            string GameOverRender =
             @"________p" +
             @"/  _____/_____    _____   ____   _______  __ ___________p" +
            @"/   \  ___\__  \  /     \_/ __ \ /  _ \  \/ // __ \_  _ \p" +
            @"\    \_\  \/ __ \|  Y Y  \  ___/(  <_> )   /\  ___/| | \/p" +
              @"\______  (____  /__|_|  /\___  >\____/ \_/  \___  >_|p" +
                    @"\/     \/      \/     \/                   \/p" +
                          @"You crashed!!";

           
            // splitting the string so each row can be printed
            string[] GameOverSplit = GameOverRender.Split('p');

            // showing the destroyed buggy onscreen
            string deadBuggy = ".   º    . O  _ X 0  .";

            // go through the lines in the array and print them
            int y = 0;
            foreach (string line in GameOverSplit)
            {
                printLine(line, 0, y);
                y++;
            }

            // print the deadbuggy
            printLine(deadBuggy, plyr.Position.X - 20, plyr.Position.Y);
        }

        /// <summary>
        /// this method lets us print strings with a given start index and
        /// on a chosen row
        /// </summary>
        /// <param name="lineToPrint">string to be printed</param>
        /// <param name="lineStartX">start point in x axis</param>
        /// <param name="lineY">point in y axis where it's printed</param>
        public void printLine(string lineToPrint, int lineStartX, int lineY)
        {
            // to know where on the x axis to start printing
            int x = lineStartX;

            // going through the string
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
            background.RenderBackground();

            // render the player onto the screen
            plyr.RenderPlayer();

            // set platforms to their corresponding characters
            platforms.RenderPlatforms();

            // write the help message for the player
            WriteHelpMessages();

            // check if player lost and render game over screen
            if(running == false)
                RenderLosingScreen();

            // swap between the doublebuffer's arrays to render each frame
            db.Swap();

            // print the doublebuffer's array on the console
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    // make the background blue
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                    // check if the character is a hole to change colour
                    if (db[x, y] == (char)Characters.holes)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // check if the character is part of the tank
                    if (db[x, y] == (char)Characters.tankHead   ||
                        db[x, y] == (char)Characters.tankmiddle ||
                        db[x, y] == (char)Characters.tankWheels ||
                        db[x, y] == (char)Characters.tankWheels1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    // check if the character is a platform to change colour
                    if (db[x, y] == (char)Characters.platforms)
                    {
                        // check if the platform is the one currently on
                        //////////////////////////////////////////////////////////////////
                        if (db[x, y] == db[platforms.keyPlatform.X,
                            platforms.keyPlatform.Y])
                            Console.ForegroundColor = ConsoleColor.Yellow;

                        // default to white for platforms
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    // write the character from the buffer with correct colour
                    Console.Write(db[x, y]);

                    // reset colour so rest of the console is clean
                    Console.ResetColor();

                }
                // change to the next line in the buffer array
                Console.WriteLine();
            }

            // Show player their jump count and possible actions
            Console.Write($"Successful jumps: {score}\n");
            Console.WriteLine("[ESC] to quit   [SPACE] to jump");
        }
    }
}
