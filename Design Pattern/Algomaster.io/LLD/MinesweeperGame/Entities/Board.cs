using MinesweeperGame.Exceptions;
using MinesweeperGame.Strategies;

namespace MinesweeperGame.Entities
{
    internal class Board
    {
        private readonly Cell[,] _grid;
        private List<Position> _minePositions;
        private bool _minesPlaced;

        public int Rows { get; }
        public int Cols { get; }

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _grid = new Cell[rows, cols];
            _minesPlaced = false;
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    _grid[r, c] = new Cell(new Position(r, c));
                }
            }
        }

        public void PlaceMines(IMinePlacementStrategy strategy, int mineCount,
            Position safePosition)
        {
            if (_minesPlaced) return;
            _minePositions = strategy.PlaceMines(this, mineCount, safePosition);
            ComputeAdjacentMineCounts();
            _minesPlaced = true;
        }

        private void ComputeAdjacentMineCounts()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (!_grid[r, c].HasMine)
                    {
                        var pos = new Position(r, c);
                        int count = 0;
                        foreach (Position neighbor in GetNeighbors(pos))
                        {
                            if (GetCell(neighbor).HasMine)
                            {
                                count++;
                            }
                        }
                        _grid[r, c].AdjacentMineCount = count;
                    }
                }
            }
        }

        public List<Position> RevealCell(Position position)
        {
            var revealedPositions = new List<Position>();
            var queue = new Queue<Position>();
            queue.Enqueue(position);

            while (queue.Count > 0)
            {
                Position current = queue.Dequeue();
                Cell cell = GetCell(current);

                if (cell.IsRevealed) continue;

                cell.Reveal();
                revealedPositions.Add(current);

                if (cell.AdjacentMineCount == 0 && !cell.HasMine)
                {
                    foreach (Position neighbor in GetNeighbors(current))
                    {
                        Cell neighborCell = GetCell(neighbor);
                        if (neighborCell.IsHidden)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return revealedPositions;
        }

        public List<Position> GetNeighbors(Position position)
        {
            var neighbors = new List<Position>();
            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int nr = position.Row + dr[i];
                int nc = position.Col + dc[i];
                if (nr >= 0 && nr < Rows && nc >= 0 && nc < Cols)
                {
                    neighbors.Add(new Position(nr, nc));
                }
            }

            return neighbors;
        }

        public bool AreAllNonMineCellsRevealed()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Cell cell = _grid[r, c];
                    if (!cell.HasMine && !cell.IsRevealed)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Cell GetCell(int row, int col)
        {
            ValidatePosition(row, col);
            return _grid[row, col];
        }

        public Cell GetCell(Position position)
        {
            return GetCell(position.Row, position.Col);
        }

        private void ValidatePosition(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
            {
                throw new InvalidActionException(
                    $"Position ({row}, {col}) is out of bounds");
            }
        }

        public void PrintBoard(bool revealAll)
        {
            Console.WriteLine();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Cell cell = _grid[r, c];
                    char display;

                    if (revealAll && cell.HasMine)
                    {
                        display = '*';
                    }
                    else if (cell.IsRevealed)
                    {
                        display = cell.HasMine ? '*'
                            : (char)('0' + cell.AdjacentMineCount);
                    }
                    else if (cell.IsFlagged)
                    {
                        display = 'F';
                    }
                    else
                    {
                        display = '#';
                    }

                    Console.Write($" {display} ");
                    if (c < Cols - 1) Console.Write("|");
                }
                Console.WriteLine();
                if (r < Rows - 1)
                {
                    Console.WriteLine(new string('-', Cols * 4 - 1));
                }
            }
            Console.WriteLine();
        }
    }
}
