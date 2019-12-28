using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Platforms
    {
        public string[] platforms;
        public Positions currentPos;
        public Positions newPos;
        public Queue<Positions> platformElements;

        public char icon;

        public Platforms()// Positions startingPos, char i)
        {

           // currentPos = startingPos;
           // icon = i;

            platformElements = new Queue<Positions>();

            for (int x = 0; x <= 5; x++)
            { 
               platformElements.Enqueue(new Positions(x, 10));
            }

        }

        public void MovePlatforms(Positions headPos)
        {
            //platformElements.Enqueue(headPos);

            for (int x = headPos.X + 1; x <= (headPos.X+5); x++)
            {
                platformElements.Enqueue(new Positions(x, 10));
            }
        }

        public void PrintPlatforms()
        {
            Console.Clear();
            foreach (Positions pos in platformElements)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("#");
            }
        }

        
    }
}
