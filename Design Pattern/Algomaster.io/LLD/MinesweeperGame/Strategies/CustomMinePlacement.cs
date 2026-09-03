using MinesweeperGame.Entities;

namespace MinesweeperGame.Strategies
{
    internal class CustomMinePlacement(List<Position> minePositions) : IMinePlacementStrategy
    {
        private readonly List<Position> _minePositions = [.. minePositions];

        public List<Position> PlaceMines(Board board, int mineCount, Position safePosition)
        {
            foreach (Position pos in _minePositions)
            {
                board.GetCell(pos).HasMine = true;
            }
            return new List<Position>(_minePositions);
        }
    }
}
