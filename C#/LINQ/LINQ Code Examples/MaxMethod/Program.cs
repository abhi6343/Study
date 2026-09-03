namespace MaxMethod
{
    internal class Program
    {
        //#region Max method
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 80, 50, 90, 60, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    int MSLargestNumber = intNumbers.Max();

        //    //Using Query Syntax
        //    int QSLargestNumber = (from num in intNumbers
        //                           select num).Max();

        //    Console.WriteLine("Largest Number = " + MSLargestNumber);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Max with where
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 80, 50, 90, 60, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    int MSLargestNumber = intNumbers.Where(num => num < 50).Max();

        //    //Using Query Syntax
        //    int QSLargestNumber = (from num in intNumbers
        //                           where num < 50
        //                           select num).Max();

        //    Console.WriteLine("Largest Number = " + MSLargestNumber);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Max with predicate
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 80, 50, 90, 60, 30, 70, 40, 20, 100, };

        //    //Using Method Syntax
        //    int MSLargestNumber = intNumbers.Max(num => {
        //                            if (num < 50)
        //                                return num;
        //                            else
        //                                return 0;
        //                            });

        //    Console.WriteLine("Largest Number = " + MSLargestNumber);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Max method with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSHighestSalary = Employee.GetAllEmployees()
        //                           .Max(emp => emp.Salary);

        //    //Using Query Syntax
        //    var QSHighestSalary = (from emp in Employee.GetAllEmployees()
        //                           select emp).Max(e => e.Salary);

        //    Console.WriteLine("Highest Salary = " + QSHighestSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Max method with where
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSHighestSalary = Employee.GetAllEmployees()
        //                           .Where(emp => emp.Department == "IT")
        //                           .Max(emp => emp.Salary);

        //    //Using Query Syntax
        //    var QSHighestSalary = (from emp in Employee.GetAllEmployees()
        //                           where emp.Department == "IT"
        //                           select emp).Max(e => e.Salary);

        //    Console.WriteLine("It Department Highest Salary = " + QSHighestSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Max method with custom predecate
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSHighestSalary = Employee.GetAllEmployees()
        //                          .Max(emp => {
        //                              if (emp.Department == "IT")
        //                                  return emp.Salary;
        //                              else
        //                                  return 0;
        //                          });

        //    Console.WriteLine("It Department Highest Salary = " + MSHighestSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Max method with custom predecate returning null in else
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax and Predicate
        //    var HighestSalaryMS = Employee.GetAllEmployees()
        //                           .Max(emp => {
        //                               if (emp.Department == "IT")
        //                                   return emp.Salary;
        //                               else
        //                                   return null;
        //                           });

        //    Console.WriteLine("IT Department Highest Salary = " + HighestSalaryMS);
        //    Console.ReadKey();
        //}
        //#endregion


        #region Handling nullable types
        //The max method will ignore null values.
        static void Main(string[] args)
        {
            int?[] nullableNumbers = { 1, 2, 10, null, 4, 5 };
            int? max = nullableNumbers.Max();
            Console.WriteLine("Max = " + max);
            Console.ReadKey();
        }
        #endregion
    }
}
