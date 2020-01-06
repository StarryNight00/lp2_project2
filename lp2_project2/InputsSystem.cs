using System;
using System.Collections.Concurrent;

namespace lp2_project2
{
    /// <summary>
    /// this class let's us analyse player input and set the different cases
    /// so the update function on the main Loop can know what to do
    /// </summary>
    class InputsSystem
    {
        /// <summary>
        /// get user's input securely
        /// </summary>
        public BlockingCollection<ConsoleKey> input;

        /// <summary>
        /// get the state of the jump
        /// </summary>
        public Jump jump;

        /// <summary>
        /// this constructor lets us set the current input and jump state
        /// </summary>
        public InputsSystem()
        {
            input = new BlockingCollection<ConsoleKey>();
            jump = new Jump();
        }

        /// <summary>
        /// this method lets us process the user's input and returns the
        /// current jump state for the loop
        /// </summary>
        /// <returns>current jump state for the main loop</returns>
        public Jump ProcessInput()
        {
            // if the spacebar was pressed, the user is jumping
            ConsoleKey key;

            if (input.TryTake(out key))
            {
                // if player hits ESC end game
                if (key == ConsoleKey.Escape)
                    return Jump.Leave;

                // if player hits SPACEBAR return jumping state and beep
                if (key == ConsoleKey.Spacebar)
                {
                    Console.Beep(1000, 50);
                    return Jump.Jumping;
                }
            }

            // default return when player isn't acting
            return Jump.Idle;
        }

        /// <summary>
        /// this method allows us to read the keys while the input is different
        /// from ESC
        /// </summary>
        public void ReadKeys()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                input.Add(key);
            }
            while (key != ConsoleKey.Escape);
        }
    }
}
