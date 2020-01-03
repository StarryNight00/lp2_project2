using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace lp2_project2
{
    public class MenuPrints
    {

        public void PrintIntroMenu()
        {
            
            // Print out color of title
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string welcome = @"
__        __   _                            _        
\ \      / /__| | ___ ___  _ __ ___   ___  | |_ ___  
 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \ 
  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) |
   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/  ";

            
            string title = @"                       
                .___  ___.   ______     ______   .__   __. 
                |   \/   |  /  __  \   /  __  \  |  \ |  | 
                |  \  /  | |  |  |  | |  |  |  | |   \|  | 
                |  |\/|  | |  |  |  | |  |  |  | |  . `  | 
                |  |  |  | |  `--'  | |  `--'  | |  |\   | 
                |__|  |__|  \______/   \______/  |__| \__| 
                                           
            .______    __    __    _______   ___________    ____ 
            |   _  \  |  |  |  |  /  _____| /  _____\   \  /   / 
            |  |_)  | |  |  |  | |  |  __  |  |  __  \   \/   /  
            |   _  <  |  |  |  | |  | |_ | |  | |_ |  \_    _/   
            |  |_)  | |  `--'  | |  |__| | |  |__| |    |  |     
            |______/   \______/   \______|  \______|    |__|";

            Console.WriteLine("\n" + welcome + "\n\n\n" + title);
            Sound();
        }
        

        public void PrintMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\tMAIN MENU");
            Console.WriteLine("\n\t\t   1 - Start Game");
            Console.WriteLine("\n\t\t   2 - Instructions");
            Console.WriteLine("\n\t\t   3 - Highscores");
            Console.WriteLine("\n\t\t   4 - Credits");
            Console.WriteLine("\n\t\t   0 - Exit");
            Console.Write("\n\n\n\t\t   >> ");
        }

        public void PrintInstructions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string key = "KEY";
            Console.WriteLine("\t\t\tINSTRUCTIONS");
            Console.WriteLine("\t\tReady to explore the Moon?!");
            Console.WriteLine("\n\tAs you explore, you will find how irre" +
                              "gular\n\tthe Moon can be!\n");
            Console.WriteLine("\tBut fear not the craters and mounts, you can" +
                              "\n\tjump over them. Per successful jump you " +
                              "will\n\tadd 1 point to your Score!\n");
            Console.WriteLine($"\tTo play, all you have to do is press {key}.");
            Console.WriteLine("\n\tTry to explore as much as you can before " +
                              "you\n\tneed to go back to Earth.");
            Console.WriteLine("\n\tCheck out the Highscores to see if you " +
                              "were the\n\tmost traveled astronaut, or just a" +
                              " passerby!");
            Console.WriteLine("\n\tTo go back, press ANY KEY");
            Console.Write("\n\n\t\t   >> ");
        }

        public void PrintCredits()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t     CREDITS\n");

            Console.WriteLine("\t\tThis project was developed by these " +
                              "\n\t\tstudents as the 2nd project for the" +
                              "\n\n\t\t\tCurricular Unit of" +
                              "\n\t\t   Linguagens de Programacao II");
            Console.WriteLine("\n\t\t      Professor Nuno Fachada");

            Console.WriteLine("\n\n\t\t     Universidade Lusofona de " +
                                "\n\t\t     Humanidades e Tecnologias\n");
            Console.WriteLine("\t\t  2nd Year/ 1st Semester  2019/2020\n\n");

            Console.WriteLine("\t\t\t     Students:\n");
            Console.WriteLine("\t\t  Ana Dos Santos\t- a21900297");
            Console.WriteLine("\t\t  Diana Levay\t\t- a21801515");
            Console.WriteLine("\t\t  Catarina Matias\t- a21801693\n");

            Console.WriteLine("\n\t\t  To go back, press ANY KEY");
            Console.Write("\n\n\t\t   >> ");
        }

        /// <summary>
        /// Method to add sound to intro menu
        /// </summary>
        public void Sound() 
        {
            // Variable to set duration of each sound
            int duration = 1000;

            // To set frequency of the tone
            int frenquency;

            // To set random frenquecy
            Random rnd = new Random();
            
            for (int i = 0; i < 3; i++) 
            {  
                frenquency = rnd.Next(500, 1500);
                Console.Beep(frenquency, duration);
            }
        }
    }
}

