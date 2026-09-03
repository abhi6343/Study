namespace LeftOuterJoinOperation
{
    internal class Program
    {
        //SELECT columns
        //FROM table1
        //LEFT JOIN table2
        //ON table1.common_column = table2.common_column;

        //#region Left Ouer Join using query syntax
        //static void Main(string[] args)
        //{
        //    //Performing Left Outer Join using LINQ using Query Syntax
        //    //Left Data Source: Employees
        //    //Right Data Source: Addresses
        //    //Note: Left and Right Data Source Matters
        //    var QSOuterJoin = from emp in Employee.GetAllEmployees() //Left Data Source
        //                      join add in Address.GetAddress() //Right Data Source
        //                      on emp.AddressId equals add.ID //Inner Join Condition
        //                      into EmployeeAddressGroup //Performing LINQ Group Join
        //                      from address in EmployeeAddressGroup.DefaultIfEmpty() //Performing Left Outer Join
        //                      select new { emp, address }; //Projecting the Result to Anonymous Type

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in QSOuterJoin)
        //    {
        //        //Before Accessing the AddressLine, please check null else you will get Null Reference Exception
        //        Console.WriteLine($"Name : {item.emp.Name}, Address : {item.address?.AddressLine} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Left Outer join with defined type
        //static void Main(string[] args)
        //{
        //    //Performing Left Outer Join using LINQ using Query Syntax
        //    //Left Data Source: Employees
        //    //Right Data Source: Addresses
        //    //Note: Left and Right Data Source Matters
        //    var QSOuterJoin = from emp in Employee.GetAllEmployees() //Left Data Source
        //                      join add in Address.GetAddress() //Right Data Source
        //                      on emp.AddressId equals add.ID //Inner Join Condition
        //                      into EmployeeAddressGroup //Performing LINQ Group Join
        //                      from address in EmployeeAddressGroup.DefaultIfEmpty() //Performing Left Outer Join

        //                        //Projecting the Result to Named Type
        //                      select new EmployeeResult
        //                      {
        //                          Employee = emp,
        //                          Address = address
        //                      };

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in QSOuterJoin)
        //    {
        //        //Before Accessing the AddressLine, please check null else you will get Null Reference Exception
        //        Console.WriteLine($"Name : {item.Employee.Name}, Address : {item.Address?.AddressLine} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Left Outer Join with method syntax
        //static void Main(string[] args)
        //{
        //    //Performing Left Outer Join using LINQ using Method Syntax
        //    //Left Data Source: Employees
        //    //Right Data Source: Addresses
        //    //Note: Left and Right Data Source Matters
        //    var MSOuterJOIN = Employee.GetAllEmployees() //Left Data Source
        //                      //Performing Group join with Right Data Source
        //                      .GroupJoin(
        //                            Address.GetAddress(), //Right Data Source
        //                            employee => employee.AddressId, //Outer Key Selector, i.e. Left Data Source Common Property
        //                            address => address.ID, //Inner Key Selector, i.e. Right Data Source Common Property
        //                            (employee, address) => new { employee, address } //Projecting the Result
        //                      )
        //                      .SelectMany(
        //                            x => x.address.DefaultIfEmpty(), //Performing Left Outer Join 
        //                            (employee, address) => new { employee, address } //Final Result Set
        //                       );

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in MSOuterJOIN)
        //    {
        //        Console.WriteLine($"Name : {item.employee.employee.Name}, Address : {item.address?.AddressLine} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Left Outer join with defined type
        //static void Main(string[] args)
        //{
        //    //Performing Left Outer Join using LINQ using Method Syntax
        //    //Left Data Source: Employees
        //    //Right Data Source: Addresses
        //    //Note: Left and Right Data Source Matters
        //    var MSOuterJOIN = Employee.GetAllEmployees() //Left Data Source
        //                      //Performing Group join with Right Data Source
        //                      .GroupJoin(
        //                            Address.GetAddress(), //Right Data Source
        //                            employee => employee.AddressId, //Outer Key Selector, i.e. Left Data Source Common Property
        //                            address => address.ID, //Inner Key Selector, i.e. Right Data Source Common Property
        //                            (employee, address) => new { employee, address } //Projecting the Result
        //                      )
        //                      .SelectMany(
        //                            x => x.address.DefaultIfEmpty(), //Performing Left Outer Join 
        //                            //Final Result Set
        //                            (employee, address) => new EmployeeResult
        //                            {
        //                                Employee = employee.employee,
        //                                Address = address
        //                            }
        //                       );

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in MSOuterJOIN)
        //    {
        //        Console.WriteLine($"Name : {item.Employee.Name}, Address : {item.Address?.AddressLine} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Anonymous Type with User-Defined Properties in the ResultSet
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSOuterJOIN = Employee.GetAllEmployees()
        //                      .GroupJoin(
        //                            Address.GetAddress(),
        //                            emp => emp.AddressId,
        //                            add => add.ID,
        //                            (emp, add) => new { emp, add }
        //                      )
        //                      .SelectMany(
        //                            x => x.add.DefaultIfEmpty(),
        //                            (employee, address) => new
        //                            {
        //                                EmployeeName = employee.emp.Name,
        //                                AddressLine = address == null ? "NA" : address.AddressLine
        //                            }
        //                       );

        //    //Using Query Syntax
        //    var QSOuterJoin = from emp in Employee.GetAllEmployees()
        //                      join add in Address.GetAddress()
        //                      on emp.AddressId equals add.ID
        //                      into EmployeeAddressGroup
        //                      from address in EmployeeAddressGroup.DefaultIfEmpty()
        //                      select new
        //                      {
        //                          EmployeeName = emp.Name,
        //                          AddressLine = address == null ? "NA" : address.AddressLine
        //                      };

        //    foreach (var item in MSOuterJOIN)
        //    {
        //        Console.WriteLine($"Name : {item.EmployeeName}, Address : {item.AddressLine} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Right Outer Join
        ////Right Outer Joins are not supported with LINQ. LINQ only supports left outer joins.
        ////Exchange the data sources to perform the right outer join
        //static void Main(string[] args)
        //{
        //    //Performing Right Outer Join using LINQ using Query Syntax
        //    //Changing the Data Sources
        //    //Left Data Source: Addresses 
        //    //Right Data Source: Employees
        //    //Note: Left and Right Data Source Matters
        //    var QSRightJoin = from add in Address.GetAddress()  //Left Data Source
        //                      join emp in Employee.GetAllEmployees() //Right Data Source
        //                      on add.ID equals emp.AddressId //Inner Join Condition
        //                      into EmployeeAddressGroup //Performing LINQ Group Join
        //                      from employee in EmployeeAddressGroup.DefaultIfEmpty() //Performing Left Outer Join
        //                      select new { add, employee }; //Projecting the Result to Anonymous Type

        //    //Accessing the Elements using For Each Loop
        //    foreach (var item in QSRightJoin)
        //    {
        //        //Before Accessing the AddressLine, please check null else you will get Null Reference Exception
        //        Console.WriteLine($"Name : {item.employee?.Name}, Address : {item.add?.AddressLine} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Real-Time Example to Understand LINQ Left Join
        //static void Main(string[] args)
        //{
        //    List<Order> orders = new List<Order>
        //    {
        //        new Order { OrderId = 101, CustomerId = 10101, OrderDate = DateTime.Parse("2022-05-10") },
        //        new Order { OrderId = 102, CustomerId = 10102, OrderDate = DateTime.Parse("2022-05-15") },
        //        new Order { OrderId = 103, CustomerId = 10103, OrderDate = DateTime.Parse("2022-05-20") },
        //    };
        //    List<Customer> customers = new List<Customer>
        //    {
        //        new Customer { CustomerId = 10101, Name = "Pranaya" },
        //        new Customer { CustomerId = 10103, Name = "Rout" },
        //    };
        //    var leftJoinQuery = from order in orders
        //                        join customer in customers
        //                        on order.CustomerId equals customer.CustomerId into customerGroup
        //                        from customerInfo in customerGroup.DefaultIfEmpty()
        //                        select new
        //                        {
        //                            OrderId = order.OrderId,
        //                            OrderDate = order.OrderDate,
        //                            CustomerName = customerInfo?.Name ?? "No Customer"
        //                        };

        //    foreach (var result in leftJoinQuery)
        //    {
        //        Console.WriteLine($"OrderID: {result.OrderId}, OrderDate: {result.OrderDate}, CustomerName: {result.CustomerName}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Another Real-Time Example
        public static void Main()
        {
            // Sample Departments
            List<Department> departments = new List<Department>()
            {
                new Department{ DepartmentID = 1, DepartmentName = "IT"},
                new Department{ DepartmentID = 2, DepartmentName = "HR"},
                new Department{ DepartmentID = 3, DepartmentName = "Finance"}
            };
            // Sample Employees
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ EmployeeID = 1, EmployeeName = "John Doe", DepartmentID = 1},
                new Employee{ EmployeeID = 2, EmployeeName = "Jane Doe", DepartmentID = 1},
                new Employee{ EmployeeID = 3, EmployeeName = "Jim Beam", DepartmentID = 2}
            };
            var departmentEmployees = from department in departments
                                      join employee in employees
                                      on department.DepartmentID equals employee.DepartmentID into deptEmps
                                      from employee in deptEmps.DefaultIfEmpty()
                                      select new
                                      {
                                          DepartmentName = department.DepartmentName,
                                          EmployeeName = employee?.EmployeeName ?? "No Employees"
                                      };

            foreach (var deptEmp in departmentEmployees)
            {
                Console.WriteLine($"Department: {deptEmp.DepartmentName}, Employee: {deptEmp.EmployeeName}");
            }
        }
        public class Employee
        {
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public int DepartmentID { get; set; }
        }
        #endregion
    }
}
