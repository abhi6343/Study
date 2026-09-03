using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WhereFilteringMethod
{
    internal class Program
    {
        //#region Predicate
        //static void Main(string[] args)
        //{
        //    List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //    //Method Syntax
        //    IEnumerable<int> filteredData = intList.Where(num => num > 5);

        //    //Func<int, bool> predicate = i => i > 5;
        //    //IEnumerable<int> filteredData = intList.Where(predicate);

        //    //Query Syntax
        //    IEnumerable<int> filteredResult = from num in intList
        //                                      where num > 5
        //                                      select num;
        //    foreach (int number in filteredData)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Seperate method for the prdicate
        //static void Main(string[] args)
        //{
        //    List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //    //Method Syntax
        //    IEnumerable<int> filteredData = intList.Where(num => CheckNumber(num));
        //    foreach (int number in filteredData)
        //    {
        //        Console.WriteLine(number);
        //    }
        //    Console.ReadKey();
        //}
        //public static bool CheckNumber(int number)
        //{
        //    if (number > 5)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //#endregion


        //#region Overloaded verson of Where
        //static void Main(string[] args)
        //{
        //    List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Method Syntax
        //    var OddNumbersWithIndexPositionMethod = intList.Select((num, index) => new
        //                                      {
        //                                          Numbers = num,
        //                                          IndexPosition = index
        //                                      }).Where(x => x.Numbers % 2 != 0)
        //                                      .Select(data => new
        //                                      {
        //                                          Number = data.Numbers,
        //                                          IndexPosition = data.IndexPosition
        //                                      });

        //    //Query Syntax
        //    var OddNumbersWithIndexPositionQuery = from number in intList.Select((num, index) => new 
        //                                            { 
        //                                                Numbers = num, 
        //                                                IndexPosition = index 
        //                                            })
        //                                            where number.Numbers % 2 != 0
        //                                            select new
        //                                            {
        //                                                Number = number.Numbers,
        //                                                IndexPosition = number.IndexPosition
        //                                            };

        //    foreach (var item in OddNumbersWithIndexPositionQuery)
        //    {
        //        Console.WriteLine($"IndexPosition : {item.IndexPosition} , Value : {item.Number}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Complex data type
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    var QuerySyntax = from employee in Employee.GetEmployees()
        //                      where employee.Salary > 50000
        //                      select employee;
        //    //Method Syntax
        //    var MethodSyntax = Employee.GetEmployees()
        //                        .Where(emp => emp.Salary > 50000);

        //    foreach (var emp in QuerySyntax)
        //    {
        //        Console.WriteLine($"Name : {emp.Name}, Salary : {emp.Salary}, Gender : { emp.Gender}");
        //        if (emp.Technology != null && emp.Technology.Count() > 0)
        //        {
        //            Console.Write(" Technology : ");
        //            foreach (var tech in emp.Technology)
        //            {
        //                Console.Write(tech + " ");
        //            }
        //            Console.WriteLine();
        //        }
        //        else
        //        {
        //            Console.WriteLine(" Technology Not Available ");
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Multiple conditions
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    var QuerySyntax = from employee in Employee.GetEmployees()
        //                      where employee.Salary > 500000 && employee.Gender == "Male"
        //                      select employee;
        //    //Method Syntax
        //    var MethodSyntax = Employee.GetEmployees()
        //                        .Where(emp => emp.Salary > 500000 && emp.Gender == "Male")
        //                        .ToList();

        //    foreach (var emp in MethodSyntax)
        //    {
        //        Console.WriteLine($"Name : {emp.Name}, Salary : {emp.Salary}, Gender : { emp.Gender}");
        //        if (emp.Technology != null && emp.Technology.Count() > 0)
        //        {
        //            Console.Write(" Technology : ");
        //            foreach (var tech in emp.Technology)
        //            {
        //                Console.Write(tech + " ");
        //            }
        //            Console.WriteLine();
        //        }
        //        else
        //        {
        //            Console.WriteLine(" Technology Not Available ");
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Complex example
        //static void Main(string[] args)
        //{
        //    //Query Syntax
        //    var QuerySyntax = (from employee in Employee.GetEmployees()
        //                        where employee.Salary >= 50000 && employee.Technology != null
        //                        select new
        //                        {
        //                            EmployeeName = employee.Name,
        //                            Gender = employee.Gender,
        //                            MonthlySalary = employee.Salary / 12
        //                        }).ToList();

        //    //Method Syntax
        //    var MethodSyntax = Employee.GetEmployees()
        //                        .Where(emp => emp.Salary >= 50000 && emp.Technology != null)
        //                        .Select(emp => new 
        //                        {
        //                            EmployeeName = emp.Name,
        //                            Gender = emp.Gender,
        //                            MonthlySalary = emp.Salary / 12
        //                        })
        //                        .ToList();

        //    foreach (var emp in QuerySyntax)
        //    {
        //        Console.WriteLine($"Name : {emp.EmployeeName}, Gender : {emp.Gender}, Monthly Salary : {emp.MonthlySalary}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Fetch elements with their index positions
        //Fetch all the employees whose Gender is Male and whose Salary is greater than 500000,
        //along with their index position to an anonymous type
        static void Main(string[] args)
        {
            //Query Syntax
            var QuerySyntax = (from data in Employee.GetEmployees().Select((Data,index) => new 
                                { 
                                    employee = Data,
                                    Index = index 
                                })
                                where data.employee.Salary >= 500000 && data.employee.Gender == "Male"
                                select new
                                {
                                    EmployeeName = data.employee.Name,
                                    Gender = data.employee.Gender,
                                    Salary = data.employee.Salary,
                                    IndexPosition = data.Index
                                }).ToList();

            //Method Syntax
            var MethodSyntax = Employee.GetEmployees().Select((Data, index) => new
                                { 
                                    employee = Data,
                                    Index = index 
                                })
                                .Where(emp => emp.employee.Salary >= 500000 && emp.employee.Gender == "Male")
                                .Select(emp => new
                                {
                                    EmployeeName = emp.employee.Name,
                                    Gender = emp.employee.Gender,
                                    Salary = emp.employee.Salary,
                                    IndexPosition = emp.Index
                                })
                                .ToList();
            foreach (var emp in QuerySyntax)
            {
                Console.WriteLine($"Position : {emp.IndexPosition} Name : {emp.EmployeeName}, Gender: {emp.Gender}, Salary: {emp.Salary}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
