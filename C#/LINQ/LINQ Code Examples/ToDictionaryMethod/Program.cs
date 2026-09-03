namespace ToDictionaryMethod
{
    internal class Program
    {
        //#region ToDictionary
        //public static void Main()
        //{
        //    List<Product> listProducts = new List<Product>
        //    {
        //        new Product { ID= 1001, Name = "Mobile", Price = 800 },
        //        new Product { ID= 1002, Name = "Laptop", Price = 900 },
        //        new Product { ID= 1003, Name = "Desktop", Price = 800 }
        //    };

        //    Dictionary<int, Product> productsDictionary = listProducts.ToDictionary(x => x.ID);

        //    foreach (KeyValuePair<int, Product> kvp in productsDictionary)
        //    {
        //        Console.WriteLine(kvp.Key + " Name : " + kvp.Value.Name + ", Price: " + kvp.Value.Price);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region ToDictionary with element selector
        //public static void Main()
        //{
        //    List<Product> listProducts = new List<Product>
        //    {
        //        new Product { ID= 1001, Name = "Mobile", Price = 800 },
        //        new Product { ID= 1002, Name = "Laptop", Price = 900 },
        //        new Product { ID= 1003, Name = "Desktop", Price = 800 }
        //    };
        //    Dictionary<int, string> productsDictionary = listProducts.ToDictionary(x => x.ID, x => x.Name);
        //    foreach (KeyValuePair<int, string> kvp in productsDictionary)
        //    {
        //        Console.WriteLine("Key : " + kvp.Key + " Value : " + kvp.Value);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Key is same for two elements
        //public static void Main()
        //{
        //    List<Product> listProducts = new List<Product>
        //    {
        //        new Product { ID= 1001, Name = "Mobile", Price = 800 },
        //        new Product { ID= 1001, Name = "Laptop", Price = 900 },
        //        new Product { ID= 1003, Name = "Desktop", Price = 800 }
        //    };

        //    Dictionary<int, string> productsDictionary = listProducts.ToDictionary(x => x.ID, x => x.Name);

        //    foreach (KeyValuePair<int, string> kvp in productsDictionary)
        //    {
        //        Console.WriteLine("Key : " + kvp.Key + " Value : " + kvp.Value);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Data source is null
        public static void Main()
        {
            List<Product> listProducts = null;

            Dictionary<int, string> productsDictionary = listProducts.ToDictionary(x => x.ID, x => x.Name);

            foreach (KeyValuePair<int, string> kvp in productsDictionary)
            {
                Console.WriteLine("Key : " + kvp.Key + " Value : " + kvp.Value);
            }
            Console.ReadKey();
        }
        #endregion
    }
}
