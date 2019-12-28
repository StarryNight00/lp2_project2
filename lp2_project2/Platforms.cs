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
               platformElements.Enqueue(new Positions(x, 0));
            }

        }

        
    }
}
