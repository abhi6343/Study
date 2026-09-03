using TicTacToe.Entities;

namespace TicTacToe.Strategies
{
    internal interface IWinStrategy
    {
        bool CheckWinner(Board board, Player player);
    }
}
