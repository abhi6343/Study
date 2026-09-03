using TicTacToe.Entities;

namespace TicTacToe.Strategies
{
    internal class ColumnWinStrategy : IWinStrategy
    {
        public bool CheckWinner(Board board, Player player)
        {
            for (int col = 0; col < 3; col++)
            {
                bool colWin = true;
                for (int row = 0; row < 3; row++)
                {
                    if (board.IsEmptyCell(row, col) || board.GetCellSymbol(row, col) != player.Symbol)
                    {
                        colWin = false;
                        break;
                    }
                }
                if (colWin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
