using MinesweeperGame.Enums;
using MinesweeperGame.Extensions;
using MinesweeperGame.Observers;
using MinesweeperGame.Strategies;

namespace MinesweeperGame.Singleton_Facade
{
    internal class MinesweeperSystem
    {
        static readonly Lazy<MinesweeperSystem> _instance = new(() => new MinesweeperSystem());

        readonly GameStatistics _statistics;
        Game _currentGame;
        readonly Lock _lock = new();

        public static MinesweeperSystem Instance => _instance.Value;

        private MinesweeperSystem()
        {
            _statistics = new GameStatistics();
        }

        public Game CreateGame(Difficulty difficulty)
        {
            return CreateGame(difficulty, new RandomMinePlacement());
        }

        public Game CreateGame(Difficulty difficulty,
            IMinePlacementStrategy strategy)
        {
            lock (_lock)
            {
                _currentGame = new Game(difficulty, strategy);
                _currentGame.AddObserver(_statistics);
                _currentGame.AddObserver(new TimerObserver());
                Console.WriteLine($"New game: {difficulty} difficulty " + $"({difficulty.GetRows()}x{difficulty.GetCols()}, " + $"{difficulty.GetMineCount()} mines)");
                return _currentGame;
            }
        }

        public void RevealCell(int row, int col)
        {
            lock (_lock)
            {
                if (_currentGame == null)
                {
                    throw new InvalidOperationException(
                        "No active game. Call CreateGame first.");
                }
                _currentGame.RevealCell(row, col);
                _currentGame.PrintBoard();
            }
        }

        public void FlagCell(int row, int col)
        {
            lock (_lock)
            {
                if (_currentGame == null)
                {
                    throw new InvalidOperationException(
                        "No active game. Call CreateGame first.");
                }
                _currentGame.FlagCell(row, col);
                _currentGame.PrintBoard();
            }
        }

        public void UnflagCell(int row, int col)
        {
            lock (_lock)
            {
                if (_currentGame == null)
                {
                    throw new InvalidOperationException(
                        "No active game. Call CreateGame first.");
                }
                _currentGame.UnflagCell(row, col);
            }
        }

        public GameStatus GameStatus
        {
            get
            {
                if (_currentGame == null)
                {
                    throw new InvalidOperationException("No active game.");
                }
                return _currentGame.Status;
            }
        }

        public void PrintStatistics()
        {
            _statistics.PrintStatistics();
        }
    }
}
