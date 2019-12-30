using System;

namespace lp2_project2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;*/



            Menu menu = new Menu();
            menu.IntroMenu();






            //POSSIBLE ADD SCORE LOGIC
            //needs to verify landing

            /*Score score = new Score();
            score.ResetScore();
            while (score.ScoreValue <= 20)
            {
                score.RenderScore();
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    score.AddScore();
                }

                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            }*/
        }
    }
}
