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
        public List<char> platforms;
        
        public Positions startPos;
        public Positions newPos;

        public DoubleBuffer2D<char> db;

        public List<Positions> platformArea;

        public Platforms(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;
            startPos = new Positions(11,10);

            Position = startPos;

            Character = ' ';

            ID = 1;  
        }

        public void MovePlatforms()
        {
            // new logic later
        }

        public void SetPlatforms()
        {

            platforms = new List<char>(50);
            platformArea = new List<Positions>();

            for (int x = 0; x < 60; x++)
            { 
                platformArea.Add(new Positions(x, 50));
            }

            foreach (Positions pos in platformArea)
            {
                Random rnd = new Random();

                double random = rnd.Next(0, 10);

                if (random > 3)
                    platforms.Add('#');

                else
                    platforms.Add('.');
            }
        }

        public void PrintPlatforms()
        {

            foreach (Positions pos in platformArea)
            {    
                    db[pos.X, pos.Y] = platforms[pos.X];  
            }
               
        }
       
    }
}
