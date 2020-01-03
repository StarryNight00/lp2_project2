using System;
using System.Collections.Generic;
using System.Text;

namespace lp2_project2
{
    /// <summary>
    /// this class creates our player in the game, assigning them a position
    /// a character and an ID to be verified when interacting with other objects
    /// </summary>
    class Player : GameObject
    {
        // center of the cart
        public Positions Position;

        // front wheel of the cart
        private Positions frontWheelPosition;

        // front wheel of the cart
        private Positions backWheelPosition;

        // top of the cart
        private Positions topPosition;

        public char topImg = 'X';
        public char wheelsImg = 'O';

        public char wheelsImg2 = '0';

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
            Position = new Positions(56, 27);
            SetPositions();
            db[frontWheelPosition.X, frontWheelPosition.Y] = wheelsImg;
            db[backWheelPosition.X, backWheelPosition.Y] = wheelsImg;
            Character = 'X';
            ID = 0;
        }

        /// <summary>
        /// this method let's us set the player with their character inside
        /// the doublebuffer's array for rendering
        /// </summary>
        public void RenderPlayer()
        {
            // for debug
            db[Position.X, Position.Y] = '.';

            SetPositions();

            // printing cart in it's due position
            db[topPosition.X, topPosition.Y] = topImg;

            if (db[frontWheelPosition.X, frontWheelPosition.Y] == wheelsImg)
            {
                db[frontWheelPosition.X, frontWheelPosition.Y] = wheelsImg2;
                db[backWheelPosition.X, backWheelPosition.Y] = wheelsImg2;
            }

            else
            {
                db[frontWheelPosition.X, frontWheelPosition.Y] = wheelsImg;
                db[backWheelPosition.X, backWheelPosition.Y] = wheelsImg;
            }
        }

        public void SetPositions()
        {
            frontWheelPosition = new Positions(Position.X - 1, Position.Y);
            backWheelPosition = new Positions(Position.X + 1, Position.Y);
            topPosition = new Positions(Position.X, Position.Y - 1);
        }
    }
}
