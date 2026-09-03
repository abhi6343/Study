namespace OfTypeFilteringMethod
{
    internal class Program
    {
        //#region OfType method
        //static void Main(string[] args)
        //{
        //    //Data Source Contains both Integer and String Data
        //    List<object> dataSource = new List<object>()
        //    {
        //        "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
        //    };
        //    //Fetching only the Integer Data from the Data Source
        //    //using Linq Method Syntax and OfType Method
        //    List<int> intData = dataSource.OfType<int>().ToList();

        //    //Print the Integer Data
        //    foreach (int number in intData)
        //    {
        //        Console.Write(number + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region OfType operator ans is operator
        //static void Main(string[] args)
        //{
        //    //Data Source Contains both Integer and String Data
        //    List<object> dataSource = new List<object>()
        //    {
        //        "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
        //    };

        //    //Fetching only the Integer Data from the Data Source
        //    //using Linq Query Syntax and OfType Method
        //    var intData = (from num in dataSource.OfType<int>()
        //                   select num).ToList();
        //    //Print the Integer Data
        //    Console.WriteLine("Using OfType Method");
        //    foreach (int number in intData)
        //    {
        //        Console.Write(number + " ");
        //    }

        //    Console.WriteLine("\nUsing IS Operator");
        //    //Fetching only the String Data from the Data Source
        //    //using Linq Query Syntax and is Method
        //    var stringData = (from name in dataSource
        //                      where name is string
        //                      select name).ToList();
        //    //Print the Integer Data
        //    foreach (string name in stringData)
        //    {
        //        Console.Write(name + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Conditional OfType and is operator
        //static void Main(string[] args)
        //{
        //    List<object> dataSource = new List<object>()
        //    {
        //        "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
        //    };

        //    //Fetching the Integer Numbers which are greater than 30
        //    //Using Method Syntax
        //    var intData = dataSource.OfType<int>().Where(num => num > 30).ToList();
        //    foreach (int number in intData)
        //    {
        //        Console.Write(number + " ");
        //    }
        //    Console.WriteLine();

        //    //Fetching the String Names whose length is greater than 3 characters
        //    //Using Query Syntax with is Operator
        //    var stringData = (from name in dataSource
        //                      where name is string && name.ToString().Length > 3
        //                      select name).ToList();

        //    //Fetching the String Names whose length is greater than 3 charact
        //    //Using Query Syntax with OfType Operator
        //    var stringData2 = (from name in dataSource.OfType<string>()
        //                       where name.Length > 3
        //                       select name).ToList();

        //    foreach (string name in stringData2)
        //    {
        //        Console.Write(name + " ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region OfType with Where method
        static void Main(string[] args)
        {
            //Data Source which contains both String and Integer Data
            List<object> dataSource = new List<object>()
            {
                "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
            };

            //Fetching the Integer numbers from the Data Source where the Numbers Greater than 30
            //Using Method Syntax
            var intData = dataSource.OfType<int>().Where(num => num > 30).ToList();
            foreach (int number in intData)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            //Using Query Syntax with OfType Operator
            var intData1 = (from num in dataSource.OfType<int>()
                            where num > 30
                            select num).ToList();

            //Using Query Syntax with is Operator
            //Here, we need to type cast num to int before applying the > operator
            var intData2 = (from num in dataSource
                            where num is int && (int)num > 30
                            select num).ToList(); 
            foreach (int name in intData2)
            {
                Console.Write(name + " ");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
