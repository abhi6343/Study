using MinesweeperGame.Entities;

namespace MinesweeperGame.Observers
{
    internal class GameStatistics : IGameObserver
    {
        private int _gamesPlayed;
        private int _gamesWon;
        private int _gamesLost;
        private int _totalCellsRevealed;

        public void OnCellRevealed(Position position, int adjacentMines)
        {
            Interlocked.Increment(ref _totalCellsRevealed);
        }

        public void OnCellFlagged(Position position)
        {
            // No-op for current implementation
        }

        public void OnGameWon()
        {
            Interlocked.Increment(ref _gamesPlayed);
            Interlocked.Increment(ref _gamesWon);
            Console.WriteLine("Statistics updated: You won!");
        }

        public void OnGameLost(Position minePosition)
        {
            Interlocked.Increment(ref _gamesPlayed);
            Interlocked.Increment(ref _gamesLost);
            Console.WriteLine($"Statistics updated: Game over! Mine at {minePosition}");
        }

        public void PrintStatistics()
        {
            int played = Interlocked.CompareExchange(ref _gamesPlayed, 0, 0);
            int won = Interlocked.CompareExchange(ref _gamesWon, 0, 0);
            int lost = Interlocked.CompareExchange(ref _gamesLost, 0, 0);
            int cells = Interlocked.CompareExchange(ref _totalCellsRevealed, 0, 0);
            double winRate = played > 0 ? (won * 100.0 / played) : 0;

            Console.WriteLine("\n===== STATISTICS =====");
            Console.WriteLine($"Games Played: {played}");
            Console.WriteLine($"Games Won:    {won}");
            Console.WriteLine($"Games Lost:   {lost}");
            Console.WriteLine($"Win Rate:     {winRate:F1}%");
            Console.WriteLine($"Cells Revealed: {cells}");
            Console.WriteLine("======================\n");
        }
    }
}
