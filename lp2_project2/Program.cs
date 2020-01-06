using System;

namespace lp2_project2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets console Window size for windows OS
            OSD.OSCheckerSize();

            // create a new start menu
            Menu menu = new Menu();

            // Set Console Window title to game name
            Console.Title = "Moon Buggy";

            // start the menu
            menu.IntroMenu();
        }
    }
}
