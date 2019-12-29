using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    public class Menu
    {
        private MenuPrints menuPrnts;

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
            menuPrnts.PrintIntroMenu();
            Console.ReadLine();
            MainMenu();
        }
        private void VarsInit()
        {
            menuPrnts = new MenuPrints();
        }

        private void MainMenu()
        {
            menuPrnts.PrintMainMenu();

            input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    //Game
                    ManySpaces();
                    // start the loop
                    loop = new GameLoop();
                    loop.Loop();
                    break;
                case 2:
                    //Instructions
                    ManySpaces();
                    Console.WriteLine("Instructions");
                    break;
                case 3:
                    //Credits
                    ManySpaces();
                    Console.WriteLine("Credits");
                    break;
                case 4:
                    //Exit
                    Exit();
                    break;
                default:
                    ManySpaces();
                    Console.WriteLine("\t\t   Invalid Input\n");
                    MainMenu();
                    break;
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

    }
}
