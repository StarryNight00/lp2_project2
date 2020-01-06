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
        /// <summary>
        /// to get help messages inspired by original game
        /// </summary>
        public string message;

        /// <summary>
        /// initiates our doublebuffer for smooth rendering
        /// </summary>
        public DoubleBuffer2D<char> db;

        /// <summary>
        /// initiates our inputsystem to handle player's inputs during thread
        /// </summary>
        public InputsSystem input;

        /// <summary>
        /// to properly render with milliseconds
        /// </summary>
        private int msPerFrame = 80;

        /// <summary>
        /// to get the highscore list
        /// </summary>
        public HighScore HS;

        /// <summary>
        /// to get the score after each successful jump 
        /// </summary>
        public int score = 0;

        /// <summary>
        /// to print the background of our game
        /// </summary>
        private Map background;

        /// <summary>
        /// initiates the platforms that will be displayed along the loop
        /// </summary>
        private Platforms platforms;

        /// <summary>
        /// initiates our player 
        /// </summary>
        private Player plyr;

        /// <summary>
        /// to check if the game is currently running
        /// </summary>
        private bool running;

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

            // creates a new doublebuffer for our map with 60x60 dimensions
            db = new DoubleBuffer2D<char>(60, 20);

            // creates a new background with the size of the buffer's array
            background = new Map(db);

            // gets a help message to display in the background
            message = "wait until you get up the platform to jump!";

            // creates our platforms and assigns the current buffer
            platforms = new Platforms(db);

            // creates our player and assigns the current buffer
            plyr = new Player(db);

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
                input.jump = input.ProcessInput(); ;

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
                    CheckCollision();
                    // changing player position to go down
                    if (plyr.Position.Y < db.YDim - 3)
                        plyr.Position.Y += 1;
                    else
                        plyr.Position.Y += 0;
                    // changing jump status to idle for new checks
                    input.jump = Jump.Idle;

                    // adding jump to the score
                    score += 1;

                    // changes displayed help message
                    message = background.ResetHelpMessages();
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
                        if (plyr.Position.Y == db.YDim - 4)
                        {
                            plyr.Position.Y -= 1;
                            input.jump = Jump.Falling;
                            Console.WriteLine("               ");
                        }

                        else
                        {
                            input.jump = Jump.Idle;
                            Console.WriteLine("Can't jump now!");
                        }

                        break;

                    // checks if user has chosen to leave the game
                    case Jump.Leave:
                        // stop running loop
                        GameOver();
                        break;          
                }
            }
        }

        /// <summary>
        /// Function to stop running and render the losing screen
        /// and add the score to the list
        /// </summary>
        public void GameOver()
        {
            // stop running game
            running = false;

            // render the losing screen
            background.RenderLosingScreen();
            Render();
            
            // On Collision make losing sound
            Console.Beep(600, 500);

            // print game over menu and save scores
            MenuPrints.PrintGameOver(score, HS);
        }

        /// <summary>
        /// this method allows us to check for collisions based on player
        /// and platforms' positions during the update
        /// </summary>
        public void CheckCollision()
        {
            // check if the player position is inside the lower platforms
            if (plyr.Position.Y > db.YDim - 3)
            {
                GameOver();
                
            }

            // check if player is on "check" (for collisions) or falling
            if (input.jump == Jump.Check || input.jump == Jump.Falling)
            {
                // if player is located on the hole row and not at the start
                if (plyr.Position.Y == db.YDim - 3)
                {
                    // show game over and leave the gameloop
                    GameOver();
                    

                }
            }

            // check if the player's movement is set to Idle
            if (input.jump == Jump.Idle)
            {
                // if player is about to hit a hole
                if (db[plyr.Position.X, plyr.Position.Y + 1] ==
                    (char)Characters.holes)
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
            background.WriteHelpMessages(message);

            // check if player lost and render game over screen
            if (running == false)
            {
                // write losing message and hide the one in the background
                background.WriteHelpMessages("              You lost!" +
                    "                ");
                background.RenderLosingScreen();
            }

            // swap between the doublebuffer's arrays to render each frame
            db.Swap();

            // print the doublebuffer's array on the console
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    // make the background blue
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                    // make the foreground red for help and game over
                    Console.ForegroundColor = ConsoleColor.White;

                    // check if the character is a hole to change colour
                    if (db[x, y] == (char)Characters.holes)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // check if the character is part of the tank
                    if (db[x, y] == (char)Characters.tankHead ||
                        db[x, y] == (char)Characters.tankmiddle ||
                        db[x, y] == (char)Characters.tankWheels ||
                        db[x, y] == (char)Characters.tankWheels1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // check if the character is a platform to change colour
                    if (db[x, y] == (char)Characters.platforms)
                    {
                        // default to white for platforms
                        Console.ForegroundColor = ConsoleColor.Yellow;
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
