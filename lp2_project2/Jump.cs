namespace lp2_project2
{
    /// <summary>
    /// this enum contains the different states of the jump
    /// </summary>
    public enum Jump
    {
        // for when there's no jump happening
        Idle,

        // different states of the jump
        Jumping,
        Hovering,
        Falling,

        // checking collisions
        Check,

        // leaving the game
        Leave

    }
}
