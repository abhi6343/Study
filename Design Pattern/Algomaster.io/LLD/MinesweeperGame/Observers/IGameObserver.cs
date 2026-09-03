using MinesweeperGame.Entities;

namespace MinesweeperGame.Observers
{
    internal interface IGameObserver
    {
        void OnCellRevealed(Position position, int adjacentMines);
        void OnCellFlagged(Position position);
        void OnGameWon();
        void OnGameLost(Position minePosition);
    }
}
