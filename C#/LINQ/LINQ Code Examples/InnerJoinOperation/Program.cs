namespace InnerJoinOperation
{
    internal class Program
    {
        //#region Join method
        //static void Main(string[] args)
        //{
        //    //Performing Inner Join Between Employees and Addresses Data Sources
        //    var JoinUsingMS = Employee.GetAllEmployees() //Outer Data Source
        //                       .Join( //Performing LINQ Inner Join
        //                       Address.GetAllAddresses(),  //Outer Data Source
        //                       employee => employee.AddressId, //Outer Key Selector
        //                       address => address.ID, //Inner Key selector
        //                       (employee, address) => new //Projecting the data into an Annonymous Type
        //                       {
        //                           EmployeeName = employee.Name,
        //                           AddressLine = address.AddressLine
        //                       }).ToList();

        //    //Accessing the Result using For Each Loop
        //    foreach (var employee in JoinUsingMS)
        //    {
        //        Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Join with defined type
        //static void Main(string[] args)
        //{
        //    //Performing Inner Between Employees and Addresses Data Sources
        //    var JoinUsingMS = Address.GetAllAddresses()  //Outer Data Source
        //                       .Join( //Performing LINQ Inner Join
        //                       Employee.GetAllEmployees(),  //Outer Data Source
        //                       address => address.ID,   //Outer Key Selector
        //                       employee => employee.AddressId, //Inner Key selector
        //                       (address, employee) => new EmployeeAddress //Projecting the data to named type i.e. EmployeeAddress
        //                       {
        //                           EmployeeName = employee.Name,
        //                           AddressLine = address.AddressLine
        //                       }).ToList();

        //    //Accessing the Result using For Each Loop
        //    foreach (var employee in JoinUsingMS)
        //    {
        //        Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Join using Query syntax
        //static void Main(string[] args)
        //{
        //    //Performing Inner Join Between Employees and Addresses Collections
        //    var JoinUsingQS = (from emp in Employee.GetAllEmployees() //Outer Data Source
        //                       join address in Address.GetAllAddresses() //Joining with Inner Data Source
        //                       on emp.AddressId equals address.ID //Joining Condition
        //                       select new //Projecting the Result to an Anonymous Type
        //                       {
        //                           EmployeeName = emp.Name,
        //                           AddressLine = address.AddressLine
        //                       }).ToList();

        //    //Accessing the Elements using Foreach Loop
        //    foreach (var employee in JoinUsingQS)
        //    {
        //        Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Join using Query syntax with defined type
        //static void Main(string[] args)
        //{
        //    //Performing Inner Join Between Employees and Addresses Collections
        //    var JoinUsingQS = (from emp in Employee.GetAllEmployees() //Outer Data Source
        //                       join address in Address.GetAllAddresses() //Joining with Inner Data Source
        //                       on emp.AddressId equals address.ID //Joining Condition
        //                       select new EmployeeAddress//Projecting the Result to EmployeeAddress Type
        //                       {
        //                           EmployeeName = emp.Name,
        //                           AddressLine = address.AddressLine
        //                       }).ToList();
        //    //Accessing the Elements using Foreach Loop
        //    foreach (var employee in JoinUsingQS)
        //    {
        //        Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region Optimizing Performance for Large Datasets using LINQ Inner Join

        //#region Basic Join example
        //static void Main(string[] args)
        //{
        //    //Performing Inner Join Between Employees and Addresses Collections
        //    var joinedList = from employee in Employee.GetAllEmployees() //Collection 1
        //                     join address in Address.GetAllAddresses() //Collection 2
        //                     on employee.AddressId equals address.ID //Joining Condition
        //                     //Projecting the Result to an anonymous type
        //                     select new { employee.ID, employee.Name, address.AddressLine };

        //    //Accessing the Elements using Foreach Loop
        //    foreach (var empAddress in joinedList)
        //    {
        //        Console.WriteLine($"Id: {empAddress.ID}, Name :{empAddress.Name}, Address : {empAddress.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Optimizing the LINQ Query Using Method Syntax
        //static void Main(string[] args)
        //{
        //    //Performing Inner Join Between Employees and Addresses Collections
        //    var optimizedJoin = Employee.GetAllEmployees().Join(Address.GetAllAddresses(),
        //                              employee => employee.AddressId,
        //                              address => address.ID,
        //                              (employee, address) => new { employee.ID, employee.Name, address.AddressLine });

        //    //Accessing the Elements using Foreach Loop
        //    foreach (var empAddress in optimizedJoin)
        //    {
        //        Console.WriteLine($"Id: {empAddress.ID}, Name :{empAddress.Name}, Address : {empAddress.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Optimized the LINQ Query By Ensuring Collections Are Indexed
        //static void Main(string[] args)
        //{
        //    //Performing Inner Join Between Employees and Addresses Collections
        //    var addressDictionary = Address.GetAllAddresses().ToDictionary(address => address.ID);
        //    var optimizedJoinWithDictionary = from employee in Employee.GetAllEmployees()
        //                                      join address in addressDictionary on employee.AddressId equals address.Key
        //                                      select new { employee.ID, employee.Name, Address = address.Value };

        //    //Accessing the Elements using Foreach Loop
        //    foreach (var empAddress in optimizedJoinWithDictionary)
        //    {
        //        Console.WriteLine($"Id: {empAddress.ID}, Name :{empAddress.Name}, Key : {empAddress.Address.AddressLine}");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region Optimized the LINQ Join By Processing the Operation in Parallel
        static void Main(string[] args)
        {
            //Performing Inner Join Between Employees and Addresses Collections

            var parallelJoin = Employee.GetAllEmployees().AsParallel()
                                .Join(Address.GetAllAddresses().AsParallel(),
                                employee => employee.AddressId,
                                address => address.ID,
                                (employee, address) => new { employee.ID, employee.Name, address.AddressLine });

            //Accessing the Elements using Foreach Loop
            foreach (var empAddress in parallelJoin)
            {
                Console.WriteLine($"Id: {empAddress.ID}, Name :{empAddress.Name}, Address : {empAddress.AddressLine}");
            }
            Console.ReadLine();
        }
        #endregion
        #endregion
    }
}
