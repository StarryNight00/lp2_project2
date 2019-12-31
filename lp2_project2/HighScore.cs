using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lp2_project2
{
    public class HighScore
    {
        /// <summary>
        /// Public List Property, with a public get and private set, 
        /// to save the highest attained scores.
        /// </summary>
        public List<int> HighscoresLst { get; private set; }

        const string path = @".\highscoreData.txt";


        public void SaveHighscores()
        {
            SaveHighscoresToFile();
        }

        private void SaveHighscoresToFile()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach(int i in HighscoresLst)
                    {
                        sw.WriteLine(i);
                    }
                }
            }
            else if (File.Exists(path))
            {
                File.Delete(path);

                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (int i in HighscoresLst)
                    {
                        sw.WriteLine(i);
                    }
                }
            }
        }


        public void OpenHighScores()
        {
            OpenSavedHighScores();
        }

        private void OpenSavedHighScores()
        {
            if (!File.Exists(path))
            {
                AddZeros();
            }
            else if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;

                    while((s = sr.ReadLine()) != null)
                    {
                        try
                        {
                            int score = int.Parse(s);
                            AddScore(score);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\t\t  >> Score Loading Error" +
                                              " - List Reseted <<\n");
                            AddZeros();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Initializes the list.
        /// </summary>
        public void InitList()
        {
            HighscoresLst = new List<int>(10);
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

        public void AddValues()
        {
            AddScore(10);
            AddScore(200);
            AddScore(340);
            AddScore(5600);
            AddScore(17);
            AddScore(4);
            AddScore(195);
            AddScore(1050);
            AddScore(444);
            AddScore(1);
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
            HighscoresLst.Sort();

            //Auxiliar int that sets the index values to be cut off the list
            int auxCount = HighscoresLst.Count - 11;

            //Removes any index over the 10 elements, from the lowest values up
            if (HighscoresLst.Count > 10)
            {
                for (int i = 0; i <= auxCount; i++)
                {
                    HighscoresLst.RemoveAt(0);
                }
            }

            //If list has under 10 elements, score is simply added.
            //If list has 10 elements or more, score is added, sorted,
            //and the lowest value is cut off. 
            if (HighscoresLst.Count < 10)
            {
                HighscoresLst.Add(score);
            }
            else
            {
                HighscoresLst.Add(score);
                HighscoresLst.Sort();
                HighscoresLst.RemoveAt(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void HighScoreRender()
        {
            HighscoresLst.Sort();

            Console.WriteLine("\t\t\tHIGHSCORE TABLE");
            Console.WriteLine("\n\t\tCheck if your score made it to the " +
                              "highest" +
                              "\n\t\tscores table!" +
                              " Or you can always try again.\n");

            Console.WriteLine("\n\t\t      Place\t    Score");

            int placement = 1;

            for(int i = 9; i >= 0; --i)
            {
                if(HighscoresLst[i] == 0)
                {
                    Console.WriteLine($"\n\t\t    {placement} " +
                                      $"- score:\t   000000");
                }
                else
                {
                    if (HighscoresLst[i] < 10)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   00000{HighscoresLst[i]}");
                    }
                    else if (HighscoresLst[i] < 100)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   0000{HighscoresLst[i]}");
                    }
                    else if (HighscoresLst[i] < 1000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   000{HighscoresLst[i]}");
                    }
                    else if (HighscoresLst[i] < 10000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   00{HighscoresLst[i]}");
                    }
                    else if (HighscoresLst[i] < 100000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   0{HighscoresLst[i]}");
                    }
                    else if (HighscoresLst[i] < 1000000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   {HighscoresLst[i]}");
                    }
                    else if (HighscoresLst[i] > 1000000)
                    {
                        Console.WriteLine($"\n\t\t    {placement} - " +
                                      $"score:\t   {HighscoresLst[i]}");
                    }
                }

                placement++;
            }

            Console.WriteLine("\n\n\t\t    To go back, press ANY KEY");
            Console.Write("\n\n\t\t   >> ");
        }
    }
}
