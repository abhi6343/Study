namespace JoinOperations
{
    internal class Program
    {
        //#region Join or Inner Join
        //static void Main()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "Alice" },
        //        new Customer { Id = 2, Name = "Bob" },
        //        new Customer { Id = 3, Name = "John" }
        //    };
        //    var orders = new List<Order>
        //    {
        //        new Order { OrderId = 101, CustomerId = 1 },
        //        new Order { OrderId = 102, CustomerId = 2 },
        //        new Order { OrderId = 103, CustomerId = 1 },
        //        new Order { OrderId = 104, CustomerId = 3 }
        //    };

        //    var result = from customer in customers
        //                 join order in orders on customer.Id equals order.CustomerId
        //                 select new { CustomerName = customer.Name, OrderId = order.OrderId };

        //    foreach (var item in result)
        //    {
        //        Console.WriteLine($"Customer: {item.CustomerName}, Order ID: {item.OrderId}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region GroupJoin
        //static void Main()
        //{
        //    var departments = new List<Department>
        //    {
        //        new Department { DepartmentId = 1, Name = "HR" },
        //        new Department { DepartmentId = 2, Name = "IT" }
        //    };
        //    var employees = new List<Employee>
        //    {
        //        new Employee { EmployeeId = 101, DepartmentId = 1, Name = "Alice" },
        //        new Employee { EmployeeId = 102, DepartmentId = 2, Name = "Bob" },
        //        new Employee { EmployeeId = 103, DepartmentId = 1, Name = "Charlie" },
        //        new Employee { EmployeeId = 104, DepartmentId = 2, Name = "John" },
        //        new Employee { EmployeeId = 105, DepartmentId = 1, Name = "Smith" }
        //    };

        //    //Performing Group Join
        //    var result = from department in departments
        //                 join employee in employees on department.DepartmentId equals employee.DepartmentId into grouped
        //                 select new { DepartmentName = department.Name, Employees = grouped };

        //    foreach (var item in result)
        //    {
        //        Console.WriteLine($"Department: {item.DepartmentName}");
        //        foreach (var employee in item.Employees)
        //        {
        //            Console.WriteLine($"\tEmployee: {employee.Name}");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region SelectMany
        static void Main()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Courses = new List<string> { "C#", "ASP.NET Core" } },
                new Student { Id = 2, Name = "Bob", Courses = new List<string> { "MySQL", "SQL Server" } },
                new Student { Id = 3, Name = "John", Courses = new List<string> { "Java", "PHP" } }
            };

            var result = from student in students
                         from course in student.Courses
                         select new { StudentName = student.Name, CourseName = course };

            foreach (var item in result)
            {
                Console.WriteLine($"Student: {item.StudentName}, Course: {item.CourseName}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
