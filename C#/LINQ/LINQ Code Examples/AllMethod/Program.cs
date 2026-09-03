using System.Text.RegularExpressions;

namespace AllMethod
{
    internal class Program
    {
        //#region All with value type
        //static void Main(string[] args)
        //{
        //    int[] IntArray = { 11, 22, 33, 44, 55 };
        //    //Using Method Syntax
        //    bool ResultMS = IntArray.All(x => x > 10);

        //    //Using Query Syntax
        //    bool ResultQS = (from num in IntArray
        //                     select num).All(x => x > 10);

        //    Console.WriteLine("Are All Numbers greater than 10? " + ResultMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region All with string type
        //static void Main(string[] args)
        //{
        //    string[] stringArray = { "James", "Sachin", "Sourav", "Pam", "Sara" };
        //    //Using Method Syntax
        //    bool ResultMS = stringArray.All(name => name.Length > 5);

        //    //Using Query Syntax
        //    bool ResultQS = (from num in stringArray
        //                     select num).All(name => name.Length > 5);

        //    Console.WriteLine("Are All Names greater than 5 Characters: " + ResultQS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region All with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    bool MSResult = Student.GetAllStudnets().All(std => std.TotalMarks > 250);

        //    //Using Query Syntax
        //    bool QSResult = (from std in Student.GetAllStudnets()
        //                     select std).All(std => std.TotalMarks > 250);

        //    Console.WriteLine($"Is All Students Having Total Marks 250: {MSResult}");
        //    Console.ReadKey();
        //}
        //#endregion


        //#region All with complex type with complex condition
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSResult = Student.GetAllStudnets()
        //                    .Where(std => std.Subjects.All(x => x.Marks > 80));

        //    //Using Query Syntax
        //    var QSResult = (from std in Student.GetAllStudnets()
        //                    where std.Subjects.All(x => x.Marks > 80)
        //                    select std).ToList();

        //    foreach (var student in QSResult)
        //    {
        //        Console.WriteLine($"{student.Name} - {student.TotalMarks}");
        //        foreach (var subject in student.Subjects)
        //        {
        //            Console.WriteLine($" {subject.SubjectName} - {subject.Marks}");
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region All method for checking user permissons
        //static void Main(string[] args)
        //{
        //    var users = new List<User>
        //    {
        //        new User { Name = "Alice", Roles = new List<string> { "Admin", "User" } },
        //        new User { Name = "Bob", Roles = new List<string> { "Admin" } },
        //        new User { Name = "Charlie", Roles = new List<string> { "Admin", "Editor" } }
        //    };

        //    bool allUsersAreAdmins = users.All(user => user.Roles.Contains("Admin"));

        //    if (allUsersAreAdmins)
        //    {
        //        Console.WriteLine("All Users are Admin");
        //        // Perform sensitive operation
        //    }
        //    else
        //    {
        //        Console.WriteLine("All Users are not Admin");
        //    }

        //    Console.ReadKey();
        //}
        //#endregion


        //#region All method for data validation across a collection
        //static void Main(string[] args)
        //{
        //    var orders = new List<Order>
        //    {
        //        new Order { OrderId = 1, Date = new DateTime(2024, 1, 10) },
        //        new Order { OrderId = 2, Date = new DateTime(2024, 2, 15) },
        //        new Order { OrderId = 3, Date = new DateTime(2024, 3, 20) }
        //    };

        //    bool allOrdersFromCurrentYear = orders.All(order => order.Date.Year == DateTime.Now.Year);

        //    if (allOrdersFromCurrentYear)
        //    {
        //        Console.WriteLine("Validation Success");
        //        // Proceed with batch operation
        //    }
        //    else
        //    {
        //        Console.WriteLine("Validation Failed");
        //    }

        //    Console.ReadKey();
        //}
        //#endregion


        //#region All method for product inventory check
        //static void Main(string[] args)
        //{
        //    var cartItems = new List<CartItem>
        //    {
        //        new CartItem { ProductId = 1, Quantity = 2 },
        //        new CartItem { ProductId = 2, Quantity = 1 },
        //        new CartItem { ProductId = 3, Quantity = 5 }
        //    };
        //    var inventory = new Dictionary<int, int>
        //    {
        //        { 1, 5 }, // Product ID 1 has 5 items in stock
        //        { 2, 2 }, // Product ID 2 has 2 items in stock
        //        { 3, 5 }  // Product ID 3 has 5 items in stock
        //    };

        //    bool allItemsInStock = cartItems.All(item => inventory[item.ProductId] >= item.Quantity);

        //    if (allItemsInStock)
        //    {
        //        // Allow the user to proceed to checkout
        //        Console.WriteLine("Proceed for Checkout");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Some Product Out of Stock");
        //    }

        //    Console.ReadKey();
        //}
        //#endregion


        //#region All method for validating input data
        //static void Main(string[] args)
        //{
        //    var emails = new List<string> { "user1@example.com", "user2@example.net", "user3@example.org" };

        //    bool allEmailsValid = emails.All(email => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));

        //    if (allEmailsValid)
        //    {
        //        Console.WriteLine("All Emails are Valid");
        //        // Process the emails
        //    }
        //    else
        //    {
        //        Console.WriteLine("All Emails are Not Valid");
        //    }

        //    Console.ReadKey();
        //}
        //#endregion


        #region All method for ensuring consistent data across multiple fields
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Alice", PostalCode = "12345" },
                new Customer { Name = "Bob", PostalCode = "23456" },
                new Customer { Name = "Charlie", PostalCode = string.Empty }
            };

            bool allDataIsValid = customers.All(c => !string.IsNullOrWhiteSpace(c.Name) && c.PostalCode.Length == 5);

            if (allDataIsValid)
            {
                // Launch marketing campaign
                Console.WriteLine("Launch Marketing Campaign");
            }
            else
            {
                Console.WriteLine("Do Not Launch a Marketing Campaign");
            }

            Console.ReadKey();
        }
        #endregion
    }
}
