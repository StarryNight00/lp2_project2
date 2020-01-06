namespace lp2_project2
{
    /// <summary>
    /// this class creates our player in the game, assigning them a position
    /// a character and an ID to be verified when interacting with other 
    /// objects
    /// </summary>
    class Player
    {
        // center of the cart
        public Positions Position;

        // front wheel of the cart
        private Positions backWheelPosition;

        // top of the cart
        private Positions topPosition;

        // middle of the cart
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

            // sets player's front in specified position
            Position = new Positions(db.XDim - 8, db.YDim - 3);

            // sets positions for all cart elements
            SetPositions();
        }

        /// <summary>
        /// this method let's us set the player with their character inside
        /// the doublebuffer's array for rendering
        /// </summary>
        public void RenderPlayer()
        {
            // call function to set the cart's positions counting from start
            SetPositions();

            // printing cart head in it's due position
            db[topPosition.X, topPosition.Y] =
                (char)Characters.tankHead;

            // printing cart middle in it's due position
            db[middlePosition.X, middlePosition.Y] =
                (char)Characters.tankmiddle;

            // printing front wheel as the main position
            db[Position.X, Position.Y] =
                (char)Characters.tankWheels;

            // printing back wheel in it's due position
            db[backWheelPosition.X, backWheelPosition.Y] =
                (char)Characters.tankWheels;

            // check previous wheel char and change it so the wheels "rotate"
            if (db[Position.X, Position.Y] == (char)Characters.tankWheels)
            {
                db[Position.X, Position.Y] = (char)Characters.tankWheels1;
                db[backWheelPosition.X, backWheelPosition.Y] =
                    (char)Characters.tankWheels1;
            }

            // check if it's in the second position and change
            else
            {
                db[Position.X, Position.Y] = (char)Characters.tankWheels;
                db[backWheelPosition.X, backWheelPosition.Y] =
                    (char)Characters.tankWheels;
            }
        }

        /// <summary>
        /// this method sets the positions for the cart component based on
        /// the front wheel's position that's our main position
        /// </summary>
        public void SetPositions()
        {
            middlePosition = new Positions(Position.X + 1, Position.Y);
            backWheelPosition = new Positions(Position.X + 2, Position.Y);
            topPosition = new Positions(Position.X + 1, Position.Y - 1);
        }
    }
}
