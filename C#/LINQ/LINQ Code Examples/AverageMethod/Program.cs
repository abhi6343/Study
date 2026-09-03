namespace AverageMethod
{
    internal class Program
    {
        //#region Average method
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    var MSAverageValue = intNumbers.Average();

        //    //Using Query Syntax
        //    var QSAverageValue = (from num in intNumbers
        //                          select num).Average();

        //    Console.WriteLine("Average Value = " + MSAverageValue);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Average with where
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    var MSAverageValue = intNumbers.Where(num => num > 50).Average();

        //    //Using Query Syntax
        //    var QSAverageValue = (from num in intNumbers
        //                          where num > 50
        //                          select num).Average();

        //    Console.WriteLine("Average Value = " + MSAverageValue);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Average with predicate
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 30, 50, 40, 60, 20, 70, 90, 80, 100 };
        //    //Using Method Syntax with a Predicate
        //    var MSAverageValue = intNumbers.Average(num => {
        //                                if (num > 50)
        //                                    return num;
        //                                else
        //                                    return 0;
        //                            });

        //    //Using Query Syntax with a Predicate
        //    var QSAverageValue = (from num in intNumbers
        //                          select num).Average(num => {
        //                              if (num > 50)
        //                                  return num;
        //                              else
        //                                  return 0;
        //                          });

        //    Console.WriteLine("Average Value = " + QSAverageValue);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Average with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSAverageSalary = Employee.GetAllEmployees()
        //                           .Average(emp => emp.Salary);

        //    //Using Query Syntax
        //    var QSAverageSalary = (from emp in Employee.GetAllEmployees()
        //                           select emp).Average(e => e.Salary);

        //    Console.WriteLine("Average Salary = " + MSAverageSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Average with where with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSAverageSalary = Employee.GetAllEmployees()
        //                          .Where(emp => emp.Department == "IT")
        //                          .Average(emp => emp.Salary);

        //    //Using Query Syntax
        //    var QSAverageSalary = (from emp in Employee.GetAllEmployees()
        //                           where emp.Department == "IT"
        //                           select emp).Average(e => e.Salary);

        //    Console.WriteLine("IT Department Average Salary = " + MSAverageSalary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Average with custom predicate with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax and Predicate
        //    var TotalSalaryMS = Employee.GetAllEmployees()
        //                        .Average(emp => {
        //                            if (emp.Department == "IT")
        //                                return emp.Salary;
        //                            else
        //                                return null;
        //                        });

        //    Console.WriteLine("IT Department Total Salary = " + TotalSalaryMS);
        //    Console.ReadKey();
        //}
        //#endregion


        #region Handling nullable type
        static void Main(string[] args)
        {
            int?[] nullableNumbers = { 10, 4, 2, null, 4, 5 };
            double? average = nullableNumbers.Average();
            Console.WriteLine("Average = " + average);
            Console.ReadKey();
        }
        #endregion
    }
}
