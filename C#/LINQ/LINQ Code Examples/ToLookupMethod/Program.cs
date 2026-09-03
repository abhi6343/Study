namespace ToLookupMethod
{
    internal class Program
    {
        //#region ToLookup method
        //static void Main(string[] args)
        //{
        //    //Grouping the Students Based on Branch using ToLookup Method
        //    //Using Method Syntax
        //    var GroupByMS = Student.GetStudents().ToLookup(s => s.Branch);

        //    //Using Query Syntax
        //    var GroupByQS = (from std in Student.GetStudents()
        //                     select std).ToLookup(x => x.Branch);

        //    //It will iterate through each group
        //    foreach (var group in GroupByMS)
        //    {
        //        Console.WriteLine(group.Key + " : " + group.Count());
        //        //Iterate through each student of a group
        //        foreach (var student in group)
        //        {
        //            Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
        //        }
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region ToLookup for Grouping Students by Gender in Descending Order, Names in Ascending Order
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    //First Group the Data by Gender using ToLookup Method
        //    var GroupByMS = Student.GetStudents().ToLookup(s => s.Gender)
        //                    //Then Sorting the data based on key in Descending Order
        //                    .OrderByDescending(c => c.Key)
        //                    .Select(std => new
        //                    {
        //                        Key = std.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = std.OrderBy(x => x.Name)
        //                    });

        //    //Using Query Syntax
        //    var GroupByQS = (from std in Student.GetStudents()
        //                     select std).ToLookup(x => x.Gender)
        //                    //Then Sorting the data based on key in Descending Order
        //                    .OrderByDescending(c => c.Key)
        //                    .Select(std => new
        //                    {
        //                        Key = std.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = std.OrderBy(x => x.Name)
        //                    });

        //    //It will iterate through each groups
        //    foreach (var group in GroupByQS)
        //    {
        //        Console.WriteLine(group.Key + " : " + group.Students.Count());
        //        //Iterate through each student of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Branch);
        //        }
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region Project result to defined type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    //First Group the Data by Gender using ToLookup Method
        //    var GroupByMS = Student.GetStudents().ToLookup(s => s.Gender)
        //                    //Then Sorting the data based on key in Descending Order
        //                    .OrderByDescending(c => c.Key)
        //                    .Select(std => new StudentGroup
        //                    {
        //                        Key = std.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = std.OrderBy(x => x.Name).ToList()
        //                    });
        //    //Using Query Syntax
        //    var GroupByQS = (from std in Student.GetStudents()
        //                     select std).ToLookup(x => x.Gender)
        //                    //Then Sorting the data based on key in Descending Order
        //                    .OrderByDescending(c => c.Key)
        //                    .Select(std => new StudentGroup
        //                    {
        //                        Key = std.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = std.OrderBy(x => x.Name).ToList()
        //                    });

        //    //It will iterate through each groups
        //    foreach (var group in GroupByQS)
        //    {
        //        Console.WriteLine(group.Key + " : " + group.Students.Count());
        //        //Iterate through each student of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Branch);
        //        }
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region ToLookupMethod with multiple keys
        //static void Main(string[] args)
        //{
        //    //Grouping Students by Branch and Gender using ToLookup Method
        //    var GroupByMultipleKeysMS = Student.GetStudents()
        //                                .ToLookup(x => new { x.Branch, x.Gender })
        //                                .Select(g => new
        //                                {
        //                                    Branch = g.Key.Branch,
        //                                    Gender = g.Key.Gender,
        //                                    Students = g.OrderBy(x => x.Name)
        //                                });

        //    //It will iterate through each group
        //    foreach (var group in GroupByMultipleKeysMS)
        //    {
        //        Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
        //        //It will iterate through each item of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region Grouping Students Based on the Branch and Gender along with OrderBy Method
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var GroupByMultipleKeysMS = Student.GetStudents()
        //                                //Group the Students first by Branch and then by Gender using ToLookup
        //                                .ToLookup(x => new { x.Branch, x.Gender })
        //                                //Sort Each Group in Descending Order Based on Branch
        //                                .OrderByDescending(g => g.Key.Branch)
        //                                //Then Sort Each Branch Group in Ascending Order Based on Gender
        //                                .ThenBy(g => g.Key.Gender)
        //                                //Project the Result to an Annonymous Type
        //                                .Select(g => new
        //                                {
        //                                    Branch = g.Key.Branch,
        //                                    Gender = g.Key.Gender,
        //                                    //Sort the Students of Each group by Name in Ascending Order
        //                                    Students = g.OrderBy(x => x.Name)
        //                                });

        //    //It will iterate through each group
        //    foreach (var group in GroupByMultipleKeysMS)
        //    {
        //        Console.WriteLine($"Barnch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
        //        //It will iterate through each item of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region ToLookup for data lookup
        //static void Main(string[] args)
        //{
        //    List<Book> books = new List<Book>
        //    {
        //        new Book("The Fellowship of the Ring", "Fantasy"),
        //        new Book("The Two Towers", "Fantasy"),
        //        new Book("The Return of the King", "Fantasy"),
        //        new Book("The Hobbit", "Fantasy"),
        //        new Book("Foundation", "Science Fiction"),
        //        new Book("Dune", "Science Fiction")
        //    };

        //    var booksByGenre = books.ToLookup(book => book.Genre);

        //    foreach (var genreGroup in booksByGenre)
        //    {
        //        Console.WriteLine($"Genre: {genreGroup.Key}");
        //        foreach (Book book in genreGroup)
        //        {
        //            Console.WriteLine($"\t{book.Title}");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region Preventing Deferred Execution Issues
        //public static void Main()
        //{
        //    List<Product> products = new List<Product>
        //    {
        //        new Product { Name = "Apple", Category = "Fruit" },
        //        new Product { Name = "Banana", Category = "Fruit" },
        //        new Product { Name = "Cucumber", Category = "Vegetable" }
        //    };

        //    // Using ToLookup to immediately execute the query and group products by category
        //    var lookup = products.ToLookup(p => p.Category);

        //    // Imagine the products list changes here
        //    products.Add(new Product { Name = "Orange", Category = "Fruit" });

        //    // Iterating over the lookup
        //    foreach (var category in lookup)
        //    {
        //        Console.WriteLine($"Category: {category.Key}");
        //        foreach (var product in category)
        //        {
        //            Console.WriteLine($"  Product: {product.Name}");
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Handling Duplicate Keys
        public static void Main()
        {
            // Example list of employees
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "John Doe", Department = "IT" },
                new Employee { Name = "Jane Smith", Department = "HR" },
                new Employee { Name = "Jack White", Department = "IT" },
                new Employee { Name = "Sara Parker", Department = "Finance" },
                new Employee { Name = "Tom Brown", Department = "IT" }
            };

            // Creating a lookup to group employees by department
            var lookup = employees.ToLookup(emp => emp.Department);

            // Displaying the grouped employees
            foreach (var group in lookup)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (Employee emp in group)
                {
                    Console.WriteLine($"\t{emp.Name}");
                }
            }
            Console.ReadKey();
        }
        #endregion
    }
}
