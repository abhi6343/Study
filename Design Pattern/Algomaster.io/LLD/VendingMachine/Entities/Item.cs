namespace VendingMachine.Entities
{
    internal class Item(string code, string name, int price)
    {
        public string GetName()
        {
            return name;
        }

        public int GetPrice()
        {
            return price;
        }
    }
}
