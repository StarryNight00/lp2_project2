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
        public string platforms;
        
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

            platforms = 
                
                "##########*#######################****#################**";

            platformArea = new List<Positions>();
            
            for(int x = 0; x<60; x++)
            {
                for (int y = 0; y < 60; y++)
                {
                    platformArea.Add(new Positions(x, 0));    
                }
            }
        }

        public void MovePlatforms()
        {
            // new logic later
        }

        public void SetPlatforms()
        {
            
        }

        public void PrintPlatforms()
        {
            for(int x = 0; x < platforms.Length; x++)
                db[x, 0] = (char)platforms[x];
                       
        }
       
    }
}
