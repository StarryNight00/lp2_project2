using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    public class Menu
    {
        private MenuPrints menuPrnts;


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
            Console.WriteLine("\n\tMain Menu is printing");
            Console.ReadLine();
        }

    }
}
