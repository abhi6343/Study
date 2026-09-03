using TicTacToe.Entities;
using TicTacToe.Exceptions;

namespace TicTacToe.State
{
    internal class WinState : IGameState
    {
        public void Move(Game game, Player p, int row, int col)
        {
            throw new InvalidMoveException("Game is already over. " + game.Winner.Name + " has won.");
        }
    }
}
