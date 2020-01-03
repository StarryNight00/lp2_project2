using System;

namespace lp2_project2
{
    public class Menu
    {
        private MenuPrints menuPrnts;
        private HighScore hScore;

        private int input;

        // to start a gameloop
        private GameLoop loop;
        private void ManySpaces()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }
        public void IntroMenu()
        {
            VarsInit();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                    // start the loop
                    Console.Clear();
                    loop = new GameLoop();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
            Console.WriteLine("Thank you for playing");
            hScore.SaveHighscores();
            Environment.Exit(0);
        }

    }
}
