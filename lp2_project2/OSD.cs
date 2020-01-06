using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    /// <summary>
    /// OSD = Operating System Dependent
    /// This class contains code that depends on a specific Operating 
    /// system and will be runned from here
    /// </summary>
    public class OSD
    {
        /// <summary>
        /// Static variable to get version of the current enviroment
        /// </summary>
        static OperatingSystem checkOS = Environment.OSVersion;

        /// <summary>
        /// Method that checks OS and checks if its windows case its true
        /// The console will get the following measure
        /// </summary>
        public static void OSCheckerSize()
        {
            if (checkOS.Platform == PlatformID.Win32NT)
            {
                // set the console size
                Console.WindowHeight = 35;
                Console.WindowWidth = 65;

                // match console buffer size to console size
                Console.BufferHeight = Console.WindowHeight;
                Console.BufferWidth = Console.WindowWidth;
            }
        }

        /// <summary>
        /// Checks current OS and runs Main sound if OS is windows
        /// </summary>
        public static void OSCheckerMainSound()
        {
            if (checkOS.Platform == PlatformID.Win32NT)
                MainEntrySound();
        }

        /// <summary>
        /// Checks current OS and runs Jump if OS is windows
        /// </summary>
        public static void OSCheckerJumpSound() 
        {
            if (checkOS.Platform == PlatformID.Win32NT)
                JumpSound();
        }

        /// <summary>
        /// Checks current OS and runs die if OS is windows
        /// </summary>
        public static void OSCheckerDieSound() 
        {
            if (checkOS.Platform == PlatformID.Win32NT)
                DieSound();
        }
        
        /// <summary>
        /// Method that makes a random frenquency of console beep to get
        /// diferent types of sounds.
        /// </summary>
        public static void MainEntrySound()
        {
            // Variable to set duration of each sound
            int duration = 1000;

            // To set frequency of the tone
            int frenquency;

            // To set random frenquecy
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                frenquency = rnd.Next(500, 1500);
                Console.Beep(frenquency, duration);
            }
        }

        /// <summary>
        /// Method with Jumping sound by pressing space
        /// </summary>
        public static void JumpSound() 
        {
            Console.Beep(1000, 50);
        }

        /// <summary>
        /// Method of dying sound if player falls in '.' platforms
        /// </summary>
        public static void DieSound() 
        {
            Console.Beep(600, 500);
        }
    }
}
