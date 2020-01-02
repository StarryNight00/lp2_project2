using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    /// <summary>
    /// STILL WORKING ON THIS LOGIC, ISN'T THAT RELEVANT FOR THE BUFFER PROBLEM
    /// ANYTHING RELATED TO THEM CAN BE COMMENTED
    /// </summary>
    class Platforms : GameObject
    {

        public string[] platforms;
        public Positions currentPos;
        public Positions newPos;
        public Queue<Positions> platformElements;



        public DoubleBuffer2D<char> db;

      
        public Platforms(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;

            platformElements = new Queue<Positions>();

            for (int x = 0; x <= 5; x++)
            {
                platformElements.Enqueue(new Positions(x, 10));
            }

            Character = ' ';

            ID = 1;  
        }

        public void MovePlatforms(Positions headPos)
        {
            //platformElements.Enqueue(headPos);

            for (int x = headPos.X + 1; x <= (headPos.X + 5); x++)
            {
                platformElements.Enqueue(new Positions(x, 10));
            }
        }


        public void SetPlatforms()
        {
            // new logic later

        }

        public void PrintPlatforms()
        {
            foreach (Positions pos in platformElements)
            {

                Random rnd = new Random();

                double random = rnd.Next(0, 10);

                if (random > 3)
                    db[pos.X, pos.Y] = '#';


                else
                    db[pos.X, pos.Y] = '.';

            }
               
        }
       
    }
}
