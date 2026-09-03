using MinesweeperGame.Entities;

namespace MinesweeperGame.Strategies
{
    internal interface IMinePlacementStrategy
    {
        List<Position> PlaceMines(Board board, int mineCount, Position safePosition);
    }
}
