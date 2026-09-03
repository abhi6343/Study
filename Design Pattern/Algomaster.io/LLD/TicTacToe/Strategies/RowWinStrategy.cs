using TicTacToe.Entities;

namespace TicTacToe.Strategies
{
    internal class RowWinStrategy : IWinStrategy
    {
        public bool CheckWinner(Board board, Player player)
        {
            for (int row = 0; row < 3; row++)
            {
                bool rowWin = true;
                for (int col = 0; col < 3; col++)
                {
                    if (board.IsEmptyCell(row, col) || board.GetCellSymbol(row, col) != player.Symbol)
                    {
                        rowWin = false;
                        break;
                    }
                }
                if (rowWin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
