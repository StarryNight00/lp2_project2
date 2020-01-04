using System;

namespace lp2_project2
{
    class Program
    {
        static void Main(string[] args)
        {

            // set the console size
            Console.WindowHeight = 35;
            Console.WindowWidth = 65;

            // match console buffer size to console size
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            
            // create a new start menu

            // Set Console Window title to game name
            Console.Title = "Moon Buggy";

            Menu menu = new Menu();

            // start the menu
            menu.IntroMenu();         

        }
    }
}
