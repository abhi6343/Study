namespace GroupByMethod
{
    internal class Order
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public static List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>
            {
                new Order { CustomerId = 1, Amount = 250 },
                new Order { CustomerId = 2, Amount = 150 },
                new Order { CustomerId = 1, Amount = 100 },
                new Order { CustomerId = 3, Amount = 200 },
                new Order { CustomerId = 2, Amount = 300 }
            };
            return orders;
        }
    }
}
