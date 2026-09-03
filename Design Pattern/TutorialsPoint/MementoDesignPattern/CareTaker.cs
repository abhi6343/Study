namespace MementoDesignPattern
{
    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();    
        public void add(Memento memento)
        {
            mementoList.Add(memento);
        }
        public Memento get(int index)
        {
            return mementoList[index];
        }
    }
}
