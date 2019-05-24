namespace PinnacleWrapper.Enums
{
    public enum Status
    {
        /// <summary>
        /// This is the starting status of a game. It means that the lines are open for betting.
        /// </summary>
        Open,

        /// <summary>
        /// This status indicates that one or more lines have a red circle (a lower maximum bet amount).
        /// </summary>
        LowerMaximum,

        /// <summary>
        /// This status indicates that the lines are temporarily unavailable for betting.
        /// </summary>
        Unavailable,

        /// <summary>
        /// When a game is cancelled all bets on the game are refunded and the status becomes canceled.
        /// </summary>
        Cancelled
    }
}
