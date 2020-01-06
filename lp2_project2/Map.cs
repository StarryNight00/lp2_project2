using System;

namespace lp2_project2
{
    /// <summary>
    /// this class lets us set the background for our map
    /// </summary>
    class Map
    {
        private DoubleBuffer2D<char> db;

        // different help messages to show the player
        public string[] helpMssgs;

        public Map(DoubleBuffer2D<char> doubleBuffer)
        {
            db = doubleBuffer;
            helpMssgs = new string[]
                {
                "      press space to jump!    ",
                "platforms have different sizes"
                    // add more
                };
        }

        /// <summary>
        /// this method lets us print the mini messages for the player
        /// present in the original Moon Buggy for linux
        /// </summary>
        public void WriteHelpMessages(string mssg)
        {
            // go through the chars and add them to the doubleBuffer
            printLine(mssg, 6, 12);
        }

        /// <summary>
        /// this method let's us reset the help message currently being
        /// displayed to a different one
        /// </summary>
        public string ResetHelpMessages()
        {
            // creates a new random so the help message displayed is different
            Random rnd = new Random();

            // getting one of the messages within the array
            int rand = rnd.Next(0, helpMssgs.Length);

            // sets the chosen message for display
            string ChosenMessage = helpMssgs[rand];

            return ChosenMessage;
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
            printLine(deadBuggy, 32, db.YDim - 4);

            // print the platforms below player
            printLine("###########################" +
                "###############################", 0, db.YDim - 3);
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

        public void RenderBackground()
        {

            // set each character in the buffer to the default
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    Random rnd = new Random(); 

                    
                     if(rnd.Next(0,200) < 2)
                         db[x, y] = '*';

                     else
                         db[x, y] = ' ';
                         
                }
            }
           
                for (int x = 0; x < db.XDim; x++)
                {          
                        db[x, db.YDim-3] = '#';
                }
            
        }

    }
}
