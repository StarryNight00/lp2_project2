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
        // player's current position
        public Positions startPos;
        
        // player's new position after each movement
        public Positions newPos;

        // getting an instance of the doublebuffer so we can print to it
        public DoubleBuffer2D<char> db;

        /// <summary>
        /// this constructor takes the doublebuffer and sets the player's 
        /// starting stats
        /// </summary>
        /// <param name="doubleb"></param>
        public Player(DoubleBuffer2D<char> doubleb)
        {
            db = doubleb;
            Position = new Positions(10,10);
            Character = 'X';
            ID = 0;
        }

        /// <summary>
        /// this method let's us set the player with their character inside
        /// the doublebuffer's array for rendering
        /// </summary>
        public void RenderPlayer()
        {  
            db[newPos.X, newPos.Y] = Character;
        }

 
    }
}
