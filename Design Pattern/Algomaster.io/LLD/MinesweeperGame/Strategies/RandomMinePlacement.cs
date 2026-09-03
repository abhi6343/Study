using MinesweeperGame.Entities;

namespace MinesweeperGame.Strategies
{
    internal class RandomMinePlacement : IMinePlacementStrategy
    {
        readonly Random _random = new();

        public List<Position> PlaceMines(Board board, int mineCount, Position safePosition)
        {
            var candidates = new List<Position>();

            for (int r = 0; r < board.Rows; r++)
            {
                for (int c = 0; c < board.Cols; c++)
                {
                    var pos = new Position(r, c);
                    if (!pos.Equals(safePosition))
                    {
                        candidates.Add(pos);
                    }
                }
            }

            // Fisher-Yates shuffle
            for (int i = candidates.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (candidates[j], candidates[i]) = (candidates[i], candidates[j]);
            }

            var minePositions = new List<Position>();

            for (int i = 0; i < mineCount && i < candidates.Count; i++)
            {
                Position pos = candidates[i];
                board.GetCell(pos).HasMine = true;
                minePositions.Add(pos);
            }

            return minePositions;
        }
    }
}
