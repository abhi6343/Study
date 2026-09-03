namespace BuilderDesignPattern
{
    public abstract class Burger: IItem
    {
        public abstract string name();
        public IPacking packing()
        {
            return new Wrapper();
        }
        public abstract float price();
    }
}
