namespace GroupByMethod
{
    internal class Sale
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public static List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>
            {
                new Sale { ProductId = 1, Quantity = 10, SaleDate = new DateTime(2023, 1, 15) },
                new Sale { ProductId = 1, Quantity = 5, SaleDate = new DateTime(2023, 1, 20) },
                new Sale { ProductId = 2, Quantity = 7, SaleDate = new DateTime(2023, 1, 25) },
                new Sale { ProductId = 1, Quantity = 13, SaleDate = new DateTime(2023, 2, 5) },
                new Sale { ProductId = 2, Quantity = 8, SaleDate = new DateTime(2023, 2, 10) },
                new Sale { ProductId = 1, Quantity = 5, SaleDate = new DateTime(2023, 1, 18) },
                new Sale { ProductId = 2, Quantity = 4, SaleDate = new DateTime(2023, 2, 12) },
                new Sale { ProductId = 3, Quantity = 8, SaleDate = new DateTime(2023, 2, 22) },
                // Add more data as needed
            };
            return sales;
        }
    }
}
