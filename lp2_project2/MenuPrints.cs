using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    public class MenuPrints
    {

        public void PrintIntroMenu()
        {
            Console.WriteLine("\t Welcome Space Voyager!!");
        }

        public void PrintMainMenu()
        {
            Console.WriteLine("\t\t\tMAIN MENU");
            Console.WriteLine("\t\t\t\n   1 - Start Game");
            Console.WriteLine("\t\t\t\n   2 - Instructions");
            Console.WriteLine("\t\t\t\n   3 - Credits");
            Console.WriteLine("\t\t\t\n   4 - Exit");
            Console.Write("\n\n\n\t\t   >> ");
        }
    }
}
