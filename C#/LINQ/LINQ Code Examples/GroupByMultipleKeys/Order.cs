namespace GroupByMultipleKeys
{
    internal class Order
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public static List<Order> GetAllOrders()
        {
            // Sample list of orders
            List<Order> orders = new List<Order>
            {
                new Order { CustomerId = 1, OrderId = 100, OrderDate = new DateTime(2023, 1, 25), Total = 150.00m },
                new Order { CustomerId = 1, OrderId = 101, OrderDate = new DateTime(2023, 3, 12), Total = 250.00m },
                new Order { CustomerId = 2, OrderId = 102, OrderDate = new DateTime(2023, 2, 28), Total = 100.00m },
                new Order { CustomerId = 2, OrderId = 103, OrderDate = new DateTime(2024, 1, 15), Total = 200.00m },
                // Add more orders as needed
            };
            return orders;
        }
    }
}
