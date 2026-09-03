namespace GroupByMethod
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Table", Category = "Furniture" },
                new Product { Id = 2, Name = "Chair", Category = "Furniture" },
                new Product { Id = 3, Name = "Table", Category = "Office" },
                new Product { Id = 4, Name = "Desk", Category = "Office" },
                new Product { Id = 5, Name = "Chair", Category = "Garden" },
            };
            return products;
        }
    }
}
