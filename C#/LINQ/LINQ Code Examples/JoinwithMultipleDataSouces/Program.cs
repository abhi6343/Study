namespace JoinwithMultipleDataSources
{
    internal class Program
    {
        //#region Join using Query syntax
        //static void Main(string[] args)
        //{
        //    var JoinMultipleDSUsingQS = (//Data Source1 i.e. Employee
        //                                 from emp in Employee.GetAllEmployees()
        //                                 //Joining with Address Data Source (Data Source2)
        //                                 join adrs in Address.GetAllAddresses()
        //                                 on emp.AddressId equals adrs.ID
        //                                 //Joining with Department Data Source (Data Source3)
        //                                 join dept in Department.GetAllDepartments()
        //                                 on emp.DepartmentId equals dept.ID
        //                                 //Projecting the Result to an Annonymous Type
        //                                 select new
        //                                 {
        //                                     ID = emp.ID,
        //                                     EmployeeName = emp.Name,
        //                                     DepartmentName = dept.Name,
        //                                     AddressLine = adrs.AddressLine
        //                                 }).ToList();

        //    //Accessing the Result using a Foreach Loop
        //    foreach (var employee in JoinMultipleDSUsingQS)
        //    {
        //        Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Join with defined type
        //static void Main(string[] args)
        //{
        //    var JoinMultipleDSUsingQS = (//Data Source1 i.e. Employee
        //                                 from emp in Employee.GetAllEmployees()
        //                                 //Joining with Address Data Source (Data Source2)
        //                                 join adrs in Address.GetAllAddresses()
        //                                 on emp.AddressId equals adrs.ID
        //                                 //Joining with Department Data Source (Data Source3)
        //                                 join dept in Department.GetAllDepartments()
        //                                 on emp.DepartmentId equals dept.ID
        //                                 //Projecting the Result to a Named Type i.e. EmployeeResult
        //                                 select new EmployeeResult
        //                                 {
        //                                     ID = emp.ID,
        //                                     EmployeeName = emp.Name,
        //                                     DepartmentName = dept.Name,
        //                                     AddressLine = adrs.AddressLine
        //                                 }).ToList();

        //    //Accessing the Result using a Foreach Loop
        //    foreach (var employee in JoinMultipleDSUsingQS)
        //    {
        //        Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Join method syntax 
        //static void Main(string[] args)
        //{
        //    var JoinMultipleDSUsingMS =
        //                    //Employee data Source (i.e. Data Source 1)
        //                    Employee.GetAllEmployees()
        //                    //Joining with Address data Source (i.e. Data Source 2)
        //                    .Join(
        //                            Address.GetAllAddresses(), //Inner Data Source 1
        //                            empLevel1 => empLevel1.AddressId, //Outer Key selector
        //                            addLevel1 => addLevel1.ID, //Inner Key selector
        //                                                       //Result set
        //                            (empLevel1, addLevel1) => new { empLevel1, addLevel1 }
        //                        )
        //                    // Joinging with Department Data Source (i.e. data Source 3)
        //                    .Join(
        //                            Department.GetAllDepartments(), //Inner Data Source 2
        //                                                            //You cannot access the outer key selector directly
        //                                                            //You can only access with the result set created in previous step
        //                                                            //i.e. using empLevel1 and addLevel1
        //                            empLevel2 => empLevel2.empLevel1.DepartmentId, //Outer Key selector
        //                            deptLevel1 => deptLevel1.ID, //Inner Key selector
        //                                                         //Result set
        //                            (empLevel2, deptLevel1) => new { empLevel2, deptLevel1 }
        //                    )
        //                    //Creating the actual result set
        //                    .Select(e => new
        //                    {
        //                        ID = e.empLevel2.empLevel1.ID,
        //                        EmployeeName = e.empLevel2.empLevel1.Name,
        //                        AddressLine = e.empLevel2.addLevel1.AddressLine,
        //                        DepartmentName = e.deptLevel1.Name
        //                    }).ToList();

        //    foreach (var employee in JoinMultipleDSUsingMS)
        //    {
        //        Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Join method with defined type
        //static void Main(string[] args)
        //{
        //    var JoinMultipleDSUsingMS =
        //                    //Employee data Source (i.e. Data Source 1)
        //                    Employee.GetAllEmployees()
        //                    //Joining with Address data Source (i.e. Data Source 2)
        //                    .Join(
        //                            Address.GetAllAddresses(), //Inner Data Source 1
        //                            empLevel1 => empLevel1.AddressId, //Outer Key selector
        //                            addLevel1 => addLevel1.ID, //Inner Key selector
        //                                                       //Result set
        //                            (empLevel1, addLevel1) => new { empLevel1, addLevel1 }
        //                        )
        //                    // Joinging with Department Data Source (i.e. data Source 3)
        //                    .Join(
        //                            Department.GetAllDepartments(), //Inner Data Source 2
        //                                                            //You cannot access the outer key selector directly
        //                                                            //You can only access with the result set created in previous step
        //                                                            //i.e. using empLevel1 and addLevel1
        //                            empLevel2 => empLevel2.empLevel1.DepartmentId, //Outer Key selector
        //                            deptLevel1 => deptLevel1.ID, //Inner Key selector
        //                                                         //Result set
        //                            (empLevel2, deptLevel1) => new { empLevel2, deptLevel1 }
        //                    )
        //                    //Creating the actual result set
        //                    .Select(e => new EmployeeResult
        //                    {
        //                        ID = e.empLevel2.empLevel1.ID,
        //                        EmployeeName = e.empLevel2.empLevel1.Name,
        //                        AddressLine = e.empLevel2.addLevel1.AddressLine,
        //                        DepartmentName = e.deptLevel1.Name
        //                    }).ToList();

        //    foreach (var employee in JoinMultipleDSUsingMS)
        //    {
        //        Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region Real time example 3 data sources
        static void Main()
        {
            // Define the data sources
            var customers = new[] {
                new Customer { CustomerId = 1, Name = "Customer A" },
                new Customer { CustomerId = 2, Name = "Customer B" }
            };
            var orders = new[] {
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now }
            };
            var orderDetails = new[] {
                new OrderDetails { OrderDetailId = 1, OrderId = 1, ProductName = "Product 1" },
                new OrderDetails { OrderDetailId = 2, OrderId = 2, ProductName = "Product 2" }
            };
            // Perform the join using query syntax
            var querySyntax = from customer in customers
                              join order in orders on customer.CustomerId equals order.CustomerId
                              join detail in orderDetails on order.OrderId equals detail.OrderId
                              select new
                              {
                                  customer.Name,
                                  order.OrderDate,
                                  detail.ProductName
                              };
            // Perform the join using method syntax
            var methodSyntax = customers
                               .Join(orders,
                                     customer => customer.CustomerId,
                                     order => order.CustomerId,
                                     (customer, order) => new { customer, order })
                               .Join(orderDetails,
                                     co => co.order.OrderId,
                                     detail => detail.OrderId,
                                     (co, detail) => new {
                                         co.customer.Name,
                                         co.order.OrderDate,
                                         detail.ProductName
                                     });
            // Execute the query and print the results
            foreach (var result in querySyntax) // or methodSyntax
            {
                Console.WriteLine($"{result.Name} placed an order on {result.OrderDate} for {result.ProductName}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
