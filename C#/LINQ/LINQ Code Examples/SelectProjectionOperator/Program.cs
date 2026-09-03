using System;
using System.Linq;
using System.Xml.Linq;

namespace SelectProjectionOperator
{
    internal class Program
    {
        //#region Select operator/method
        //static void Main(string[] args)
        //{
        //    //Using Query Syntax
        //    List<Employee> basicQuery = (from emp in Employee.GetEmployees()
        //                                 select emp).ToList();
        //    foreach (Employee emp in basicQuery)
        //    {
        //        Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} { emp.LastName}");
        //    }

        //    //Using Method Syntax
        //    IEnumerable<Employee> basicMethod = Employee.GetEmployees().ToList();
        //    foreach (Employee emp in basicMethod)
        //    {
        //        Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} { emp.LastName}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Select single prop
        //static void Main(string[] args)
        //{
        //    //Using Query Syntax
        //    List<int> basicPropQuery = (from emp in Employee.GetEmployees()
        //                                select emp.ID).ToList(); //At this Point the Query is Executed
        //    foreach (var id in basicPropQuery)
        //    {
        //        Console.WriteLine($"ID : {id}");
        //    }

        //    //Using Method Syntax
        //    IEnumerable<int> basicPropMethod = Employee.GetEmployees()
        //    .Select(emp => emp.ID);
        //    //At this Point the Query is Just Generated, Not Executed
        //    foreach (var id in basicPropMethod) //At this Point the Query is going to be Executed
        //    {
        //        Console.WriteLine($"ID : {id}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Select/Project some properties to same class
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    IEnumerable<Employee> selectQuery = (from emp in Employee.GetEmployees()
        //                                         select new Employee()
        //                                         {
        //                                             FirstName = emp.FirstName,
        //                                             LastName = emp.LastName,
        //                                             Salary = emp.Salary
        //                                         });
        //    foreach (var emp in selectQuery)
        //    {
        //        Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
        //    }

        //    //Method Syntax
        //    List<Employee> selectMethod = Employee.GetEmployees().
        //                                  Select(emp => new Employee()
        //                                  {
        //                                      FirstName = emp.FirstName,
        //                                      LastName = emp.LastName,
        //                                      Salary = emp.Salary
        //                                  }).ToList();
        //    foreach (var emp in selectMethod)
        //    {
        //        Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Selelct/Project properties to different class
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    IEnumerable<EmployeeBasicInfo> selectQuery = (from emp in Employee.GetEmployees()
        //                                                  select new EmployeeBasicInfo()
        //                                                  {
        //                                                      FirstName = emp.FirstName,
        //                                                      LastName = emp.LastName,
        //                                                      Salary = emp.Salary
        //                                                  });
        //    foreach (var emp in selectQuery)
        //    {
        //        Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salarey : {emp.Salary}");
        //    }

        //    //Method Syntax
        //    List<EmployeeBasicInfo> selectMethod = Employee.GetEmployees().
        //                                           Select(emp => new EmployeeBasicInfo()
        //                                           {
        //                                               FirstName = emp.FirstName,
        //                                               LastName = emp.LastName,
        //                                               Salary = emp.Salary
        //                                           }).ToList();
        //    foreach (var emp in selectMethod)
        //    {
        //        Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Selelct/Project properties to anonymous type
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    var selectQuery = (from emp in Employee.GetEmployees()
        //                       select new
        //                       {
        //                           FirstName = emp.FirstName,
        //                           LastName = emp.LastName,
        //                           Salary = emp.Salary
        //                       });
        //    foreach (var emp in selectQuery)
        //    {
        //        Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
        //    }

        //    //Method Syntax
        //    var selectMethod = Employee.GetEmployees().
        //                       Select(emp => new
        //                       {
        //                           FirstName = emp.FirstName,
        //                           LastName = emp.LastName,
        //                           Salary = emp.Salary
        //                       }).ToList();
        //    foreach (var emp in selectMethod)
        //    {
        //        Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Perform calculations on selected data
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    var selectQuery = (from emp in Employee.GetEmployees()
        //                       select new
        //                       {
        //                           EmployeeId = emp.ID,
        //                           FullName = emp.FirstName + " " + emp.LastName,
        //                           AnnualSalary = emp.Salary * 12
        //                       });
        //    foreach (var emp in selectQuery)
        //    {
        //        Console.WriteLine($" ID {emp.EmployeeId} Name : {emp.FullName} Salary: { emp.AnnualSalary}");
        //    }

        //    //Method Syntax
        //    var selectMethod = Employee.GetEmployees().
        //                       Select(emp => new
        //                       {
        //                           EmployeeId = emp.ID,
        //                           FullName = emp.FirstName + " " + emp.LastName,
        //                           AnnualSalary = emp.Salary * 12
        //                       }).ToList();
        //    foreach (var emp in selectMethod)
        //    {
        //        Console.WriteLine($" ID {emp.EmployeeId} Name : {emp.FullName} Salary: { emp.AnnualSalary}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Select/Project data with index value
        static void Main(string[] args)
        {
            //Query Syntax
            var query = (from emp in Employee.GetEmployees().Select((value, index) => new { value, index })
                        select new
                        {
                            //Index is 0-Based, and always increases by 1
                            IndexPosition = emp.index,
                            FullName = emp.value.FirstName + " " + emp.value.LastName,
                            emp.value.Salary
                        }).ToList();
            foreach (var emp in query)
            {
                Console.WriteLine($" Position {emp.IndexPosition} Name : {emp.FullName} Salary: {emp.Salary}");
            }

            //Method Syntax
            //Projects each element of a sequence into a new form by incorporate element's index.
            var selectMethod = Employee.GetEmployees().
                               Select((emp, index) => new
                               {
                                   //Index is 0-Based, and always increases by 1
                                   IndexPosition = index,
                                   FullName = emp.FirstName + " " + emp.LastName,
                                   emp.Salary
                               });
            foreach (var emp in selectMethod)
            {
                Console.WriteLine($" Position {emp.IndexPosition} Name : {emp.FullName} Salary: {emp.Salary}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
