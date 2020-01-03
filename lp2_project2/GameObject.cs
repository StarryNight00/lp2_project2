namespace lp2_project2
{
    /// <summary>
    /// this class allows us to set various components in the game as game
    /// objects with the same characteristics for organisation and abstraction
    /// </summary>
    class GameObject
    {
        public Positions Position { get; set; }
        public char Character { get; set; }
        public int ID { get; set; }

        public GameObject()
        {
            
        }

        /// <summary>
        /// this method receives two game objects and checks for collision
        /// between them
        /// </summary>
        /// <param name="obj1">game object we want to check</param>
        /// <param name="obj2">other game object we want to check</param>
        /// <returns></returns>
        public bool CheckForCollision(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.X == obj2.Position.X ||
                obj1.Position.Y == obj2.Position.Y)
                return true;

            return false;
        }
    }
}
