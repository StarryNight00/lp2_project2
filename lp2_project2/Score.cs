using System;

namespace lp2_project2
{
    /// <summary>
    /// Public class that handles all in-game scoring methods.
    /// </summary>
    public class Score
    {
        /// <summary>
        /// Public int property, with a public get and private set, to save the 
        /// score value.
        /// </summary>
        public int ScoreValue { get; private set; }

        /// <summary>
        /// Resets the score to 0 when called.
        /// </summary>
        public void ResetScore()
        {
            ScoreValue = 0;
        }

        /// <summary>
        /// Adds one unit to the score.
        /// </summary>
        public void AddScore()
        {
            ScoreValue += 1;
        }

        /// <summary>
        /// Renders the score on the console screen. Stops rendering at 
        /// value 9999999 to not lose formatting. 
        /// </summary>
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
