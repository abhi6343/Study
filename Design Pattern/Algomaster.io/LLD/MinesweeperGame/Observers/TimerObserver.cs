using MinesweeperGame.Entities;
using System.Diagnostics;

namespace MinesweeperGame.Observers
{
    internal class TimerObserver : IGameObserver
    {
        readonly Stopwatch _stopwatch = new();

        public void OnCellRevealed(Position position, int adjacentMines)
        {
            if (!_stopwatch.IsRunning)
            {
                _stopwatch.Start();
            }
        }

        public void OnGameWon()
        {
            _stopwatch.Stop();
            Console.WriteLine($"Time: {_stopwatch.Elapsed.TotalSeconds:F1} seconds");
        }

        public void OnGameLost(Position minePosition)
        {
            _stopwatch.Stop();
            Console.WriteLine($"Time: {_stopwatch.Elapsed.TotalSeconds:F1} seconds");
        }

        public void OnCellFlagged(Position position) { }
    }
}
