namespace GroupByMultipleKeys
{
    internal class SaleRecord
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public static List<SaleRecord> GetAllSales()
        {
            var sales = new List<SaleRecord>
            {
                new SaleRecord { SaleId = 1, ProductId = 101, Country = "USA", Year = 2023, Amount = 150M },
                new SaleRecord { SaleId = 2, ProductId = 102, Country = "USA", Year = 2023, Amount = 250M },
                new SaleRecord { SaleId = 3, ProductId = 103, Country = "Canada", Year = 2023, Amount = 100M },
                new SaleRecord { SaleId = 4, ProductId = 104, Country = "USA", Year = 2023, Amount = 150M },
                new SaleRecord { SaleId = 5, ProductId = 102, Country = "Canada", Year = 2023, Amount = 170M },
                new SaleRecord { SaleId = 6, ProductId = 101, Country = "India", Year = 2023, Amount = 550M },
                new SaleRecord { SaleId = 1, ProductId = 101, Country = "USA", Year = 2024, Amount = 150M },
                new SaleRecord { SaleId = 2, ProductId = 102, Country = "USA", Year = 2024, Amount = 250M },
                new SaleRecord { SaleId = 3, ProductId = 103, Country = "Canada", Year = 2024, Amount = 100M },
                // Add more records as needed
            };

            return sales;
        }
    }
}
