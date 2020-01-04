using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    /// <summary>
    /// this class creates our player in the game, assigning them a position
    /// a character and an ID to be verified when interacting with other objects
    /// </summary>
    class Player
    {
        // center of the cart
        public Positions Position;
        
        // front wheel of the cart
        private Positions backWheelPosition;

        // top of the cart
        private Positions topPosition;

        private Positions middlePosition;

        // getting an instance of the doublebuffer so we can print to it
        public DoubleBuffer2D<char> db;

        /// <summary>
        /// this constructor takes the doublebuffer and sets the player's 
        /// starting stats
        /// </summary>
        /// <param name="doubleb">gets doublebuffer for printing</param>
        public Player(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;
            Position = new Positions(db.XDim-4, db.YDim - 3);
            SetPositions();
            db[Position.X, Position.Y] = (char)Characters.tankWheels;
            db[backWheelPosition.X, backWheelPosition.Y] = 
                (char)Characters.tankWheels;
        }

        /// <summary>
        /// this method let's us set the player with their character inside
        /// the doublebuffer's array for rendering
        /// </summary>
        public void RenderPlayer()
        {

            SetPositions();

            // printing cart in it's due position
            db[topPosition.X, topPosition.Y] = (char)Characters.tankHead;

            db[middlePosition.X, middlePosition.Y] = (char)Characters.tankmiddle;

            if (db[Position.X, Position.Y] == (char)Characters.tankWheels)
            {
                db[Position.X, Position.Y] = (char)Characters.tankWheels1;
                db[backWheelPosition.X, backWheelPosition.Y] = (char)Characters.tankWheels1;
            }

            else
            {
                db[Position.X, Position.Y] = (char)Characters.tankWheels;
                db[backWheelPosition.X, backWheelPosition.Y] = (char)Characters.tankWheels;
            }
        }
        public void SetPositions()
        {
            middlePosition = new Positions(Position.X + 1, Position.Y);
            backWheelPosition = new Positions(Position.X + 2, Position.Y);
            topPosition = new Positions(Position.X + 1, Position.Y - 1);
        }
    }
}
