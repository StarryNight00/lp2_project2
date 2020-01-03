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
        /// <summary>
        /// this queue will store positions for the platforms to move
        /// </summary>
        public Queue<Positions> platformElements;

        /// <summary>
        /// the doublebuffer will allow smooth printing
        /// </summary>
        public DoubleBuffer2D<char> db;
    
        /// <summary>
        /// this class sets moving platforms 
        /// in a specified area on the console with different properties
        /// </summary>
        /// <param name="doubleb"></param>
        public Platforms(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;

            platformElements = new Queue<Positions>();

            SetPlatforms();

            Character = ' ';

            ID = 1;  
        }

        /// <summary>
        /// this method allows us to reset the platforms when they reach the
        /// end of the console
        /// </summary>
        public void SetPlatforms()
        {
            
            for (int x = 0; x <= 3; x++)
            {
                platformElements.Enqueue(new Positions(x, 9));
            }
        }

        /// <summary>
        /// this method allows us to move the platforms on the console
        /// </summary>
        /// <param name="headPos">last known position</param>
        public void MovePlatforms(Positions headPos)
        {
            for (int x = headPos.X + 1; x <= (headPos.X + 3); x++)
            {
                platformElements.Enqueue(new Positions(x, 9));
            }
         
        }

        /// <summary>
        /// this method is to be called on the update method of the game loop
        /// it updates the platforms' positions and allows them to move
        /// </summary>
        public void PlatformUpdate()
        {
            Positions platformStart = platformElements.Last();

            platformElements.Dequeue();

            if (platformStart.X < db.XDim)//Console.BufferWidth - 1)
            {
                Positions newPlatformStart = new Positions(platformStart.X
                    + 1, platformStart.Y);

                MovePlatforms(newPlatformStart);
            }

            // check if the end of the console has been reached and reset
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
                if(pos.X >= 0 && pos.X <= 10)
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
