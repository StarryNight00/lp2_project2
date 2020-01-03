using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    public class Menu
    {
        private MenuPrints menuPrnts;
        private HighScore hScore;

        private int input;

        private GameLoop loop;
        private void ManySpaces()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }
        public void IntroMenu()
        {
            VarsInit();
            menuPrnts.PrintIntroMenu();
            Console.ReadLine();
            MainMenu();
        }
        private void VarsInit()
        {
            menuPrnts = new MenuPrints();
            hScore = new HighScore();
            hScore.InitList();
            hScore.OpenHighScores();
        }

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

        private void Instructions()
        {
            menuPrnts.PrintInstructions();
            Console.ReadKey();
        }

        private void HighScores()
        {
            hScore.HighScoreRender();
            Console.ReadKey();
        }

        private void Credits()
        {
            menuPrnts.PrintCredits();
            Console.ReadKey();
        }

        private void Exit()
        {
            hScore.SaveHighscores();
            Environment.Exit(0);
        }

    }
}
