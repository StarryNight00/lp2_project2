using System;

namespace lp2_project2
{
    class Program
    {
        public static void OSChecker()
        {
            OperatingSystem checkOS = Environment.OSVersion;
            //Version oSVersion = checkOS.Version;

            //checkOS.Platform == checkOS.Platform;

            if (checkOS.Platform == PlatformID.Win32NT) 
            {
                MenuPrints.Sound();
            }
        }

        static void Main(string[] args)
        {

            // set the console size
            Console.WindowHeight = 35;
            Console.WindowWidth = 65;

            // match console buffer size to console size
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            // create a new start menu
            Menu menu = new Menu();

            // Set Console Window title to game name
            Console.Title = "Moon Buggy";

            // start the menu
            menu.IntroMenu();

        }
    }
}
