using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    class Score
    {
        //Properties
        public int ScoreValue { get; private set; }

        //method to init the score
        public void ResetScore()
        {
            ScoreValue = 0;
        }
        //Method to add score
        public void AddScore()
        {
            ScoreValue += 1;
        }
        //Method to render score
        public void RenderScore()
        {
            Console.Write("\t");

            if(ScoreValue < 1)
            {
                Console.Write("000000");
            }
            else if (ScoreValue < 10)
            {
                Console.Write($"00000{ScoreValue}");
            }
            else if (ScoreValue < 100)
            {
                Console.Write($"0000{ScoreValue}");
            }
            else if (ScoreValue < 1000)
            {
                Console.Write($"000{ScoreValue}");
            }
            else if (ScoreValue < 10000)
            {
                Console.Write($"00{ScoreValue}");
            }
            else if (ScoreValue < 100000)
            {
                Console.Write($"0{ScoreValue}");
            }
            else if (ScoreValue <= 9999999)
            {
                Console.Write($"{ScoreValue}");
            }
            else if (ScoreValue > 9999999)
            {
                Console.Write("Can't print Score");
            }

        }
    }
}
