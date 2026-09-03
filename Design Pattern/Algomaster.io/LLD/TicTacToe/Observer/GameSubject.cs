using TicTacToe.Entities;

namespace TicTacToe.Observer
{
    internal abstract class GameSubject
    {
        readonly List<IGameObserver> observers = [];
        public void Attach(IGameObserver observer)
        {
            observers.Add(observer);
        }
        public void Detach(IGameObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update((Game)this);
            }
        }
    }
}
