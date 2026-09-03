using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Entities;

namespace TicTacToe.Strategies
{
    internal class DiagonalWinStrategy : IWinStrategy
    {
        public bool CheckWinner(Board board, Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                if(board.IsEmptyCell(i, i) || board.IsEmptyCell(i, 2 - i) || board.GetCellSymbol(i, i) != player.Symbol || board.GetCellSymbol(i, 2 - i) != player.Symbol)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
