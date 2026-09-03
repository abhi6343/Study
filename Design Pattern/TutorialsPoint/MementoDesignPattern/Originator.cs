namespace MementoDesignPattern
{
    public class Originator
    {
        private string state;
        public void setState(string state)
        {
            this.state = state;
        }
        public string getState() 
        { 
            return this.state;
        }
        public Memento saveStateToMemento()
        {
            return new Memento(this.state);
        }
        public void getStateFromMemento(Memento memento)
        {
            state = memento.getState();
        }
    }
}
