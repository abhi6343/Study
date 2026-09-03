using TicTacToe.Entities;

namespace TicTacToe.State
{
    internal interface IGameState
    {
        void Move(Game game, Player p, int row, int col);
    }
}
