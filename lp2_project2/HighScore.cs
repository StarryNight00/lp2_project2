using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    public class HighScore
    {
        /// <summary>
        /// Public List Property, with a public get and private set, 
        /// to save the highest attained scores.
        /// </summary>
        public List<int> Highscores { get; private set; }

        /// <summary>
        /// Initializes the list.
        /// </summary>
        public void InitList()
        {
            Highscores = new List<int>(10);
        }

        /// <summary>
        /// Sets the list to contain elements of value zero.
        /// </summary>
        public void AddZeros()
        {
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
        }

        /// <summary>
        /// Method that adds the score to the highscore list.
        /// </summary>
        /// <param name="score">Represents a 32-bit signed integer.</param>
        public void AddScore(int score)
        {
            AddAndCutScore(score);
        }

        /// <summary>
        /// Method that receives a score and places it at the High Scores list 
        /// if high enough. Cuts off any extra elements.
        /// </summary>
        /// <param name="score">Represents a 32-bit signed integer.</param>
        private void AddAndCutScore(int score)
        {
            //Sorts the current list
            Highscores.Sort();

            //Auxiliar int that sets the index values to be cut off the list
            int auxCount = Highscores.Count - 11;

            //Removes any index over the 10 elements, from the lowest values up
            if (Highscores.Count > 10)
            {
                for (int i = 0; i <= auxCount; i++)
                {
                    Highscores.RemoveAt(0);
                }
            }

            //If list has under 10 elements, score is simply added.
            //If list has 10 elements or more, score is added, sorted,
            //and the lowest value is cut off. 
            if (Highscores.Count < 10)
            {
                Highscores.Add(score);
            }
            else
            {
                Highscores.Add(score);
                Highscores.Sort();
                Highscores.RemoveAt(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void HighScoreRender()
        {
            Console.WriteLine("\t\t\tHIGHSCORE TABLE");
            Console.WriteLine("\n\t\tCheck if your score made it to the " +
                              "highest" +
                              "\n\t\tscores table!" +
                              " Or you can always try again.\n");

            Console.WriteLine("n\t\t      Place\t    Score");

            int placement = 1;

            for(int i = 9; i >= 0; --i)
            {
                if(Highscores[i] == 0)
                {
                    Console.WriteLine($"\n\t\t    {placement} " +
                                      $"- score:\t   000000");
                }
                else
                {
                    if (Highscores[i] < 10)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   00000{Highscores[i]}");
                    }
                    else if (Highscores[i] < 100)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   0000{Highscores[i]}");
                    }
                    else if (Highscores[i] < 1000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   000{Highscores[i]}");
                    }
                    else if (Highscores[i] < 10000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   00{Highscores[i]}");
                    }
                    else if (Highscores[i] < 100000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   0{Highscores[i]}");
                    }
                    else if (Highscores[i] < 1000000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   {Highscores[i]}");
                    }
                    else if (Highscores[i] > 1000000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   {Highscores[i]}");
                    }
                }

                placement++;
            }

            Console.WriteLine("\n\n\t\t    To go back, press ANY KEY");
            Console.Write("\n\n\t\t   >> ");
        }
    }
}
