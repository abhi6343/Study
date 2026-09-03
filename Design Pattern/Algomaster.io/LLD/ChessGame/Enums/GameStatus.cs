namespace ChessGame.Enums
{
    internal enum GameStatus
    {
        Active,      // Normal play
        Check,       // Current player's king is under attack
        Checkmate,   // Current player has no legal move to escape check
        Stalemate,   // Current player has no legal moves but isn't in check
        Resigned     // A player voluntarily surrendered
    }
}
