namespace BuilderDesignPattern
{
    public abstract class ColdDrink : IItem
    {
        public abstract string name();
        public IPacking packing()
        {
            return new Bottle();
        }
        public abstract float price();
    }
}
