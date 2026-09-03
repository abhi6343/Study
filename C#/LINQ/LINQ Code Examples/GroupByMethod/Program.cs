namespace GroupByMethod
{
    internal class Program
    {
        //#region GroupBy single property
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    IEnumerable<IGrouping<string, Student>> GroupByMS = Student.GetStudents().GroupBy(s => s.Barnch);

        //    //Using Query Syntax
        //    IEnumerable<IGrouping<string, Student>> GroupByQS = (from std in Student.GetStudents()
        //                                                         group std by std.Barnch);

        //    //It will iterate through each groups
        //    foreach (IGrouping<string, Student> group in GroupByMS)
        //    {
        //        Console.WriteLine(group.Key + " : " + group.Count());
        //        //Iterate through each student of a group
        //        foreach (var student in group)
        //        {
        //            Console.WriteLine("  Name : " + student.Name + ", Age: " + student.Age + ", Gender : " + student.Gender);
        //        }
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region Grouping Students by Gender in Descending Order, Names in Ascending Order in Each Group
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    //First Group the Data by Gender
        //    var GroupByMS = Student.GetStudents().GroupBy(s => s.Gender)
        //                    //Then Sorting the data based on key in Descending Order
        //                    .OrderByDescending(c => c.Key)
        //                    .Select(stdGroup => new
        //                    {
        //                        Key = stdGroup.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = stdGroup.OrderBy(x => x.Name)
        //                    });

        //    //Using Query Syntax
        //    //First Group the Data by Gender
        //    var GroupByQS = from std in Student.GetStudents()
        //                    // First store the data into a group
        //                    group std by std.Gender into stdGroup
        //                    //Then Sorting the data based on key in Descending Order
        //                    orderby stdGroup.Key descending
        //                    select new
        //                    {
        //                        Key = stdGroup.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = stdGroup.OrderBy(x => x.Name)
        //                    };

        //    //It will iterate through each groups
        //    foreach (var group in GroupByQS)
        //    {
        //        Console.WriteLine(group.Key + " : " + group.Students.Count());
        //        //Iterate through each student of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Barnch);
        //        }
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region Projecting result to StudentGroup class
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    //First Group the Data by Gender
        //    var GroupByMS = Student.GetStudents().GroupBy(s => s.Gender)
        //                    //Then Sorting the data based on key in Descending Order
        //                    .OrderByDescending(c => c.Key)
        //                    .Select(std => new StudentGroup
        //                    {
        //                        Key = std.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = std.OrderBy(x => x.Name).ToList()
        //                    });

        //    //Using Query Syntax
        //    //First Group the Data by Gender
        //    var GroupByQS = from std in Student.GetStudents()
        //                    //First store the data into a group
        //                    group std by std.Gender into stdGroup
        //                    //Then Sorting the data based on key in Descending Order
        //                    orderby stdGroup.Key descending
        //                    select new StudentGroup
        //                    {
        //                        Key = stdGroup.Key,
        //                        //Sorting the Students in Each Group based on Name in Ascending order
        //                        Students = stdGroup.OrderBy(x => x.Name).ToList()
        //                    };

        //    //It will iterate through each groups
        //    foreach (var group in GroupByQS)
        //    {
        //        Console.WriteLine(group.Key + " : " + group.Students.Count());
        //        //Iterate through each student of a group
        //        foreach (var student in group.Students)
        //        {
        //            Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Barnch);
        //        }
        //    }
        //    Console.Read();
        //}
        //#endregion


        //#region GroupBy with Aggregation
        //public static void Main(string[] args)
        //{
        //    var totalAmountPerCustomer = Order.GetAllOrders()
        //                                 .GroupBy(order => order.CustomerId)
        //                                 .Select(group => new
        //                                 {
        //                                     CustomerId = group.Key,
        //                                     TotalAmount = group.Sum(order => order.Amount)
        //                                 });

        //    foreach (var group in totalAmountPerCustomer)
        //    {
        //        Console.WriteLine($"Customer {group.CustomerId} Total Order Amount: {group.TotalAmount}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region GroupBy for hierarchical data display 
        //public static void Main(string[] args)
        //{
        //    var hierarchicalGrouping = Employee.GetAllEmployees()
        //                                .GroupBy(e => e.Department)
        //                                .Select(departmentGroup => new
        //                                {
        //                                    Department = departmentGroup.Key,
        //                                    Roles = departmentGroup
        //                                             .GroupBy(e => e.Role)
        //                                             .Select(roleGroup => new
        //                                             {
        //                                                 Role = roleGroup.Key,
        //                                                 Employees = roleGroup.ToList()
        //                                             })
        //                                             .ToList()
        //                                })
        //                                .ToList();

        //    foreach (var department in hierarchicalGrouping)
        //    {
        //        Console.WriteLine($"Department: {department.Department}");
        //        foreach (var role in department.Roles)
        //        {
        //            Console.WriteLine($"  Role: {role.Role}");
        //            foreach (var employee in role.Employees)
        //            {
        //                Console.WriteLine($"    - {employee.Name}");
        //            }
        //        }
        //    }

        //    Console.ReadKey();
        //}
        //#endregion


        //#region GroupBy for removing duplicates
        //public static void Main(string[] args)
        //{
        //    var distinctProductsByName = Product.GetAllProducts()
        //                                  .GroupBy(p => p.Name)
        //                                  .Select(g => g.First())
        //                                  .ToList();

        //    foreach (var product in distinctProductsByName)
        //    {
        //        Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Category: {product.Category}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region GroupBy for data analysis
        public static void Main(string[] args)
        {
            var groupedSales = Sale.GetAllSales()
                                 .GroupBy(sale => new { sale.ProductId, Month = sale.SaleDate.Month })
                                 .Select(group => new
                                 {
                                     group.Key.ProductId,
                                     group.Key.Month,
                                     TotalQuantity = group.Sum(sale => sale.Quantity)
                                 })
                                 .OrderBy(result => result.ProductId).ThenBy(result => result.Month);
            foreach (var sale in groupedSales)
            {
                Console.WriteLine($"Product {sale.ProductId} - Month: {sale.Month}, Total Quantity Sold: {sale.TotalQuantity}");
            }

            Console.ReadKey();
        }
        #endregion
    }
}
