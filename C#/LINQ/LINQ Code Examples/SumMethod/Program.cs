namespace SumMethod
{
    internal class Program
    {
        //#region Sum method with int
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 30, 50, 40, 60, 20, 70, 90, 80, 100 };

        //    //Using Method Syntax
        //    int MSTotal = intNumbers.Sum();

        //    //Using Query Syntax
        //    int QSTotal = (from num in intNumbers
        //                   select num).Sum();

        //    Console.WriteLine("Sum = " + QSTotal);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Sum method with where extension
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 30, 50, 40, 60, 20, 70, 90, 80, 100 };

        //    //Using Method Syntax
        //    int MSTotal = intNumbers.Where(num => num > 50).Sum();

        //    //Using Query Syntax
        //    int QSTotal = (from num in intNumbers
        //                   where num > 50
        //                   select num).Sum();

        //    Console.WriteLine("Sum = " + QSTotal);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Sum Method with Predicate
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 10, 30, 50, 40, 60, 20, 70, 90, 80, 100 };

        //    //Using Method Syntax with a Predicate
        //    int MSTotal = intNumbers.Sum(num => {
        //                    if (num > 50)
        //                        return num;
        //                    else
        //                        return 0;
        //                });

        //    //Using Query Syntax with a Predicate
        //    int QSTotal = (from num in intNumbers
        //                   select num).Sum(num => {
        //                       if (num > 50)
        //                           return num;
        //                       else
        //                           return 0;
        //                   });

        //    Console.WriteLine("Sum = " + QSTotal);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Handling nullable type
        ////The Sum method also has overloads for handling nullable numeric types (int?, double?, etc.). When
        ////summing nullable types, the method will ignore null values.
        //static void Main(string[] args)
        //{
        //    int?[] nullableNumbers = { 1, 2, null, 4, 5 };
        //    int sum = nullableNumbers.Sum().GetValueOrDefault();
        //    Console.WriteLine("Sum = " + sum);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Sum with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var TotalSalaryMS = Employee.GetAllEmployees()
        //                        .Sum(emp => emp.Salary);

        //    //Using Query Syntax
        //    var TotalSalaryQS = (from emp in Employee.GetAllEmployees()
        //                         select emp).Sum(e => e.Salary);

        //    Console.WriteLine("Sum Of Salary = " + TotalSalaryMS);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Sum method with where
        //static void Main(string[] args)
        //{
        //    //Calculate the Sum of Salaries of IT Department
        //    //Using Method Syntax
        //    var TotalSalaryMS = Employee.GetAllEmployees()
        //                        .Where(emp => emp.Department == "IT")
        //                        .Sum(emp => emp.Salary);

        //    //Using Query Syntax
        //    var TotalSalaryQS = (from emp in Employee.GetAllEmployees()
        //                         where emp.Department == "IT"
        //                         select emp).Sum(e => e.Salary);

        //    Console.WriteLine("IT Department Total Salary = " + TotalSalaryQS);
        //    Console.ReadKey();
        //}
        //#endregion


        #region Sum with custom predicate
        static void Main(string[] args)
        {
            //Using Method Syntax and Predicate
            var TotalSalaryMS = Employee.GetAllEmployees()
                                .Sum(emp => {
                                    if (emp.Department == "IT")
                                        return emp.Salary;
                                    else
                                        return 0;
                                });

            Console.WriteLine("IT Department Total Salary = " + TotalSalaryMS);
            Console.ReadKey();
        }
        #endregion
    }
}
