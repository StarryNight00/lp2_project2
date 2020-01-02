using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                platformElements.Enqueue(new Positions(x, 50));
            }

            Character = ' ';

            ID = 1;  
        }

        public void MovePlatforms(Positions headPos)
        {
            for (int x = headPos.X + 1; x <= (headPos.X + 5); x++)
            {
                platformElements.Enqueue(new Positions(x, 50));
            }
         
        }

        public void SetPlatforms()
        {
            platformElements = new Queue<Positions>();

            for (int x = 0; x <= 5; x++)
            {
                platformElements.Enqueue(new Positions(x, 50));
            }
        }

        public void PlatformUpdate()
        {
            Positions platformStart = platformElements.Last();

            platformElements.Dequeue();

            if (platformStart.X < Console.BufferWidth - 1)
            {
                Positions newPlatformStart = new Positions(platformStart.X
                    + 1, platformStart.Y);

                MovePlatforms(newPlatformStart);
            }

            else
            {
                platformElements.Dequeue();
                platformStart.X = 1;
                SetPlatforms();
            } 
        }

        /// <summary>
        /// this method prints the platforms in their area according to their
        /// position and using the doublebuffer
        /// BUG : PRINTS RANDOMLY EVERY TIME, THIS HAS TO BE MOVED ELSEWHERE
        /// </summary>
        public void PrintPlatforms()
        {
            foreach (Positions pos in platformElements)
            {
                if(pos.X >= 0 && pos.X <= 60)
                { 
                Random rnd = new Random();

                double random = rnd.Next(0, 10);

                if (random > 2)
                    db[pos.X, pos.Y] = '#';

                else
                    db[pos.X, pos.Y] = '.';
                }
            }
               
        }
      
    }
}
