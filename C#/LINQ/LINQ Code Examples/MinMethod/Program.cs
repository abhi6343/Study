using System;

namespace MinMethod
{
    internal class Program
    {
        //#region Min method
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    int MSLowestNumber = intNumbers.Min();

        //    //Using Query Syntax
        //    int QSLowestNumber = (from num in intNumbers
        //                          select num).Min();

        //    Console.WriteLine("Lowest Number = " + MSLowestNumber);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Min method with where
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    int MSLowestNumber = intNumbers.Where(num => num > 50).Min();

        //    //Using Query Syntax
        //    int QSLowestNumber = (from num in intNumbers
        //                          where num > 50
        //                          select num).Min();

        //    Console.WriteLine("Lowest Number = " + MSLowestNumber);
        //    Console.ReadKey();
        //}
        //#endregion


        //    #region Min method with custom predicate
        //    static void Main(string[] args)
        //    {
        //        int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };
        //        //Using Method Syntax
        //        int MSLowestNumber = intNumbers.Where(num => num > 50)
        //                            .Min(num => { 
        //                                if (num > 50)
        //                                    return num;
        //                                else
        //                                    return 0;
        //                            });

        //        Console.WriteLine("Lowest Number = " + MSLowestNumber);
        //        Console.ReadKey();
        //    }
        //#endregion


        //#region Min method with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSLowestSalary = Employee.GetAllEmployees()
        //                         .Min(emp => emp.Salary);

        //    //Using Query Syntax
        //    var QSLowestSalary = (from emp in Employee.GetAllEmployees()
        //                          select emp).Min(e => e.Salary);

        //    Console.WriteLine("Lowest Salary = " + MSLowestSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Min method with where with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSLowestSalary = Employee.GetAllEmployees()
        //    .Where(emp => emp.Department == "IT")
        //    .Min(emp => emp.Salary);

        //    //Using Query Syntax
        //    var QSLowestSalary = (from emp in Employee.GetAllEmployees()
        //                          where emp.Department == "IT"
        //                          select emp).Min(e => e.Salary);

        //    Console.WriteLine("IT Department Lowest Salary = " + QSLowestSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Min method with custom predicate
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax and Predicate
        //    var MinumumSalaryMS = Employee.GetAllEmployees()
        //                           .Min(emp => {
        //                               if (emp.Department == "IT")
        //                                   return emp.Salary;
        //                               else
        //                                   return null;
        //                           });

        //    Console.WriteLine("IT Department Lowest Salary = " + MinumumSalaryMS);
        //    Console.ReadKey();
        //}
        //#endregion


        #region Handling nullable type
        static void Main(string[] args)
        {
            int?[] nullableNumbers = { 10, 1, 2, null, 4, 5 }; 
            int? min = nullableNumbers.Min();
            Console.WriteLine("Min = " + min);
            Console.ReadKey();
        }
        #endregion
    }
}
