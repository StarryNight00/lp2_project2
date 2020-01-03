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
        /// Private variable of MenuPrints class, to call on this class.
        /// </summary>
        private MenuPrints menuPrnts;

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
        /// Method that adds many spaces and helps seperate screens on the 
        /// console.
        /// </summary>
        private void ManySpaces()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");      //CHECK CONSOLE.CLEAR
        }

        /// <summary>
        /// Calls on the Introduction Menu, which then leads to all the 
        /// in-program menu logic.
        /// </summary>
        public void IntroMenu()
        {
            VarsInit();
            menuPrnts.PrintIntroMenu();
            Console.ReadLine();
            MainMenu();
        }

        /// <summary>
        /// Initializes all classes needed to start the program and the menu.
        /// </summary>
        private void VarsInit()
        {
            menuPrnts = new MenuPrints();
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
            menuPrnts.PrintMainMenu();

            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                ManySpaces();
                Console.WriteLine("\t\t   >> Invalid Input <<\n");
                MainMenu();
            }

            switch (input)
            {
                case 1:
                    //Game
                    ManySpaces();
                    // start the loop
                    Console.Clear();

                    loop = new GameLoop();
                    loop.Loop();
                    break;
                case 2:
                    //Instructions
                    ManySpaces();
                    Instructions();
                    ManySpaces();
                    MainMenu();
                    break;
                case 3:
                    //Highscores
                    ManySpaces();
                    HighScores();
                    ManySpaces();
                    MainMenu();
                    break;
                case 4:
                    //Credits
                    ManySpaces();
                    Credits();
                    ManySpaces();
                    MainMenu();
                    break;
                case 0:
                    //Exit
                    Exit();
                    break;
                default:
                    ManySpaces();
                    Console.WriteLine("\t\t   >> Invalid Input <<\n");
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
            menuPrnts.PrintInstructions();
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
            menuPrnts.PrintCredits();
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
