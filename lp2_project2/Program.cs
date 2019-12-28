using System;

namespace lp2_project2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 30);
            Console.SetBufferSize(70, 30);
            Menu menu = new Menu();

            menu.IntroMenu();         
        }
    }
}
