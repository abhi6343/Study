using MinesweeperGame.Entities;
using MinesweeperGame.Enums;
using MinesweeperGame.Exceptions;
using MinesweeperGame.Extensions;
using MinesweeperGame.Observers;
using MinesweeperGame.Strategies;

namespace MinesweeperGame
{
    internal class Game(Difficulty difficulty, IMinePlacementStrategy strategy)
    {
        private readonly Board _board = new(difficulty.GetRows(), difficulty.GetCols());
        private GameStatus _status = GameStatus.NotStarted;
        private readonly List<IGameObserver> _observers = [];
        private readonly int _mineCount = difficulty.GetMineCount();
        private readonly Lock _lock = new();

        public Board Board => _board;
        public GameStatus Status => _status;
        public Difficulty Difficulty => difficulty;

        public void RevealCell(int row, int col)
        {
            lock (_lock)
            {
                if (_status == GameStatus.Won || _status == GameStatus.Lost)
                {
                    throw new InvalidActionException("Game is already over!");
                }

                Cell cell = _board.GetCell(row, col);

                if (cell.IsFlagged)
                {
                    throw new InvalidActionException(
                        $"Cell {cell.Position} is flagged. Unflag it first.");
                }

                if (cell.IsRevealed)
                {
                    return; // No-op for already revealed cells
                }

                // First click: place mines and transition to InProgress
                if (_status == GameStatus.NotStarted)
                {
                    var safePosition = new Position(row, col);
                    _board.PlaceMines(strategy, _mineCount,
                        safePosition);
                    _status = GameStatus.InProgress;
                }

                // Check if it's a mine
                if (cell.HasMine)
                {
                    cell.Reveal();
                    _status = GameStatus.Lost;
                    NotifyGameLost(cell.Position);
                    return;
                }

                // Flood fill reveal
                List<Position> revealedPositions =
                    _board.RevealCell(new Position(row, col));

                // Notify observers for each revealed cell
                foreach (Position pos in revealedPositions)
                {
                    Cell revealedCell = _board.GetCell(pos);
                    NotifyCellRevealed(pos, revealedCell.AdjacentMineCount);
                }

                // Check win condition
                if (_board.AreAllNonMineCellsRevealed())
                {
                    _status = GameStatus.Won;
                    NotifyGameWon();
                }
            }
        }

        public void FlagCell(int row, int col)
        {
            lock (_lock)
            {
                if (_status == GameStatus.Won || _status == GameStatus.Lost)
                {
                    throw new InvalidActionException("Game is already over!");
                }

                Cell cell = _board.GetCell(row, col);

                if (cell.IsRevealed)
                {
                    throw new InvalidActionException($"Cell {cell.Position} is already revealed.");
                }

                if (cell.IsFlagged)
                {
                    return; // Already flagged, no-op
                }

                cell.Flag();
                NotifyCellFlagged(cell.Position);
            }
        }

        public void UnflagCell(int row, int col)
        {
            lock (_lock)
            {
                if (_status == GameStatus.Won || _status == GameStatus.Lost)
                {
                    throw new InvalidActionException("Game is already over!");
                }

                Cell cell = _board.GetCell(row, col);

                if (!cell.IsFlagged)
                {
                    return; // Not flagged, no-op
                }

                cell.Unflag();
            }
        }

        public Position GetHint()
        {
            var safeCells = new List<Position>();
            for (int r = 0; r < _board.Rows; r++)
            {
                for (int c = 0; c < _board.Cols; c++)
                {
                    Cell cell = _board.GetCell(r, c);
                    if (cell.IsHidden && !cell.HasMine)
                    {
                        safeCells.Add(new Position(r, c));
                    }
                }
            }
            if (safeCells.Count == 0) return null;
            var random = new Random();
            return safeCells[random.Next(safeCells.Count)];
        }

        public void AddObserver(IGameObserver observer)
        {
            _observers.Add(observer);
        }

        private void NotifyCellRevealed(Position position, int adjacentMines)
        {
            foreach (IGameObserver observer in _observers)
            {
                observer.OnCellRevealed(position, adjacentMines);
            }
        }

        private void NotifyCellFlagged(Position position)
        {
            foreach (IGameObserver observer in _observers)
            {
                observer.OnCellFlagged(position);
            }
        }

        private void NotifyGameWon()
        {
            foreach (IGameObserver observer in _observers)
            {
                observer.OnGameWon();
            }
        }

        private void NotifyGameLost(Position minePosition)
        {
            foreach (IGameObserver observer in _observers)
            {
                observer.OnGameLost(minePosition);
            }
        }

        public void PrintBoard()
        {
            bool revealAll = (_status == GameStatus.Lost);
            _board.PrintBoard(revealAll);
        }
    }
}
