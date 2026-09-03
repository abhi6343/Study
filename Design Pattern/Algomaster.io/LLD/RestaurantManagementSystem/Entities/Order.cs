namespace RestaurantManagementSystem.Entities
{
    internal class Order(int orderId, int tableId)
    {
        private readonly List<OrderItem> items = [];

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public double GetTotalPrice()
        {
            return items.Sum(item => item.MenuItem.Price);
        }

        public int OrderId => orderId;
        public int TableId => tableId;
        public List<OrderItem> OrderItems => items;
    }
}
