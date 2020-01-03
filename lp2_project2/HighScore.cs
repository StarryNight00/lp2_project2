using System;
using System.Collections.Generic;
using System.IO;

namespace lp2_project2
{
    /// <summary>
    /// Public class that handles the highest scores attained and saves them 
    /// on a file, also keeping track of its content.
    /// </summary>
    public class HighScore
    {
        /// <summary>
        /// Public List property, with a public get and private set, 
        /// to save the highest attained scores.
        /// </summary>
        public List<int> HighscoresLst { get; private set; }

        /// <summary>
        /// A constant string path to save the file within the project folder.
        /// </summary>
        private const string path = @".\highscoreData.txt";

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
            AddScore(2);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
            AddScore(0);
        }

        

        /// <summary>
        /// Adds the score to the highscore list.
        /// </summary>
        /// <param name="score">Represents a 32-bit signed integer.</param>
        public void AddScore(int score)
        {
            AddAndCutScore(score);
        }

        /// <summary>
        /// Receives a score and places it at the High Scores list if high 
        /// enough. Cuts off any extra elements.
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
        /// Renders the Highscore List content on the console screen.
        /// </summary>
        public void HighScoreRender()
        {
            //SaveHighscores(); // -----------------------------------------------Turn on when rest is done to test
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


        /// <summary>
        /// Method that runs the Highscore saving methods.
        /// </summary>
        public void SaveHighscores()
        {
            SaveHighscoresToFile();
        }

        /// <summary>
        /// Checks for a file path within the project and whether or not the 
        /// file to save the Highscore information exits. 
        /// If it exists the method will delete that file and save a new one, if
        /// it doesn't it will create the file.
        /// </summary>
        private void SaveHighscoresToFile()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (int i in HighscoresLst)
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

        /// <summary>
        /// Method that runs the saved Highscores file opening methods.
        /// </summary>
        public void OpenHighScores()
        {
            OpenSavedHighScores();
        }

        /// <summary>
        /// Checks for a file path within the project and whether or not the 
        /// file to open exits. If it doesn't, the Highscore list will be 
        /// reseted to 0 on all placements. If it does, then the method will try
        /// to open each content and add it to the program's Highscore list, 
        /// converting the string to an int value, or run an Exception if it 
        /// can't process the variable, reseting all to 0.
        /// </summary>
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

                    while ((s = sr.ReadLine()) != null)
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

    }
}
