namespace RestaurantManagementSystem.Entities
{
    internal class MenuItem(string id, string name, double price)
    {
        public string Id => id;
        public string Name => name;
        public double Price => price;
    }
}
