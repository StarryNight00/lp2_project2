using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    /// <summary>
    /// Public class that handles all Menu related structures.
    /// </summary>
    public class Menu
    {

        /// <summary>
        /// Private variable of HighScore class, to call on this class.
        /// </summary>
        private HighScore hScore;

        /// <summary>
        /// Private variable of GameLoop class, to call on this class.
        /// </summary>
        private GameLoop loop;

        /// <summary>
        /// A private int variable, to handle the menu input and travel.
        /// </summary>
        private int input;


        /// <summary>
        /// Calls on the Introduction Menu, which then leads to all the 
        /// in-program menu logic.
        /// </summary>
        public void IntroMenu()
        {
            VarsInit();
            MenuPrints.PrintIntroMenu();
            Console.ReadLine();
            MainMenu();
        }

        /// <summary>
        /// Calls on the Intruduction Menu, without re-initializing the 
        /// variables. By receiving the HighScore variable, it allows for the 
        /// information to be passed through loops and go straight to the Main 
        /// Menu.
        /// </summary>
        /// <param name="score">Represents a 32-bit signed integer.</param>
        /// <param name="hScore">Represents the Gameloop's HighScore 
        /// current variable.</param>
        public void IntroSansInit(int score, HighScore hScore)
        {
            this.hScore = hScore;
            hScore.AddHighScore(score);

            Console.Clear();
            MenuPrints.PrintIntroMenu();
            Console.ReadLine();
            MainMenu();
        }

        /// <summary>
        /// Initializes all classes needed to start the program and the menu.
        /// </summary>
        private void VarsInit()
        {
            hScore = new HighScore();
            hScore.InitList();
            hScore.OpenHighScores();
        }

        /// <summary>
        /// Calls on a print to the Main Menu and handles the menu travel. 
        /// Also starts the Gameloop if option 1 is called.
        /// </summary>
        private void MainMenu()
        {
            MenuPrints.PrintMainMenu();

            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t   >> Invalid Input <<\n");
                MainMenu();
            }

            switch (input)
            {
                case 1:
                    //Game
                    Console.Clear();
                    // start the loop
                    Console.Clear();

                    loop = new GameLoop(hScore);
                    loop.Loop();
                    break;
                case 2:
                    //Instructions
                    Console.Clear();
                    Instructions();
                    Console.Clear();
                    MainMenu();
                    break;
                case 3:
                    //Highscores
                    Console.Clear();
                    HighScores();
                    Console.Clear();
                    MainMenu();
                    break;
                case 4:
                    //Credits
                    Console.Clear();
                    Credits();
                    Console.Clear();
                    MainMenu();
                    break;
                case 0:
                    //Exit
                    Exit();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t   >> Invalid Input <<\n");
                    MainMenu();
                    break;
            }
        }

        /// <summary>
        /// Calls on a print to the Instructions screen. Also handles the screen
        /// exit.
        /// </summary>
        private void Instructions()
        {
            MenuPrints.PrintInstructions();
            Console.ReadKey();
        }

        /// <summary>
        /// Calls on a print to the High Scores screen. Also handles the screen
        /// exit.
        /// </summary>
        private void HighScores()
        {
            hScore.HighScoreRender();
            Console.ReadKey();
        }

        /// <summary>
        /// Calls on a print to the Credits screen. Also handles the screen
        /// exit.
        /// </summary>
        private void Credits()
        {
            MenuPrints.PrintCredits();
            Console.ReadKey();
        }

        /// <summary>
        /// Calls on to save the highscores and exits the program.
        /// </summary>
        private void Exit()
        {
            hScore.SaveHighscores();
            Environment.Exit(0);
        }

    }
}
