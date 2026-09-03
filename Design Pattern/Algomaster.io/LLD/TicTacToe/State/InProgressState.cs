using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Entities;
using TicTacToe.Exceptions;

namespace TicTacToe.State
{
    internal class InProgressState : IGameState
    {
        public void Move(Game game, Player p, int row, int col)
        {
            try
            {
                if (game.CurrentPlayer != p)
                {
                    throw new InvalidMoveException("Not your turn!");
                }

                game.Board.SetCellSymbol(p.Symbol, row, col);


                if (game.CheckWinner(p))
                {
                    game.SetWinner(p);
                    game.State = new WinState();
                }
                else if (game.Board.IsFull())
                {
                    game.State = new DrawState();
                }
                else
                {
                    game.SwitchPlayer();
                }
            }
            catch { }
        }
    }
}
