using TicTacToe.Entities;

namespace TicTacToe.Observer
{
    internal interface IGameObserver
    {
        void Update(Game game);
    }
}
