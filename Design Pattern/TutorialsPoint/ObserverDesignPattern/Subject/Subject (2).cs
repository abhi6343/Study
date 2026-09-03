namespace ObserverDesignPattern.Subject
{
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();
        private int state;
        public int getState()
        {
            return state;
        }
        public void setState(int state)
        {
            this.state = state;
            notifyAllObservers();
        }
        public void attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void deattach(Observer observer)
        {
            observers.Remove(observer);
        }
        private void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update();
            }
        }
    }
}
