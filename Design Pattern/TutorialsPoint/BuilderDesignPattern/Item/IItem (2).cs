namespace BuilderDesignPattern
{
    public interface IItem
    {
        public string name();
        IPacking packing();
        float price();
    }
}
