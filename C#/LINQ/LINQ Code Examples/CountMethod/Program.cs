namespace CountMethod
{
    internal class Program
    {
        //#region Count method
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };

        //    //Using Method Syntax
        //    int MSCount = intNumbers.Count();

        //    //Using Query Syntax
        //    var QSCount = (from num in intNumbers
        //                   select num).Count();

        //    Console.WriteLine("No of Elements = " + MSCount);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Count method with where
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };
        //    //Using Method Syntax
        //    int MSCount = intNumbers.Where(num => num > 40).Count();

        //    //Using Query Syntax
        //    var QSCount = (from num in intNumbers
        //                   where num > 40
        //                   select num).Count();

        //    Console.WriteLine("No of Elements = " + MSCount);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Count method with predicate
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = new int[] { 60, 80, 50, 90, 10, 30, 70, 40, 20, 100 };
        //    //Using Method Syntax with a Predicate
        //    int MSCount = intNumbers.Count(num => {
        //                        if (num > 40)
        //                            return true;
        //                        else
        //                            return false;
        //                    });

        //    //Using Query Syntax with a Predicate
        //    int QSCount = (from num in intNumbers
        //                   select num).Count(num => {
        //                       if (num > 40)
        //                           return true;
        //                       else
        //                           return false;
        //                   });

        //    Console.WriteLine("No of Elements = " + MSCount);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Count method with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSCount = Employee.GetAllEmployees().Count();

        //    //Using Query Syntax
        //    var QSCount = (from emp in Employee.GetAllEmployees()
        //                   select emp).Count();

        //    Console.WriteLine("Total No of Employees = " + QSCount);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Count method with where with complex type
        //static void Main(string[] args)
        //{
        //    //Using Method Syntax
        //    var MSCount = Employee.GetAllEmployees()
        //                   .Where(emp => emp.Department == "IT")
        //                   .Count();

        //    //Using Query Syntax
        //    var QSCount = (from emp in Employee.GetAllEmployees()
        //                   where emp.Department == "IT"
        //                   select emp).Count();

        //    Console.WriteLine("Total No of Employees of IT Department = " + QSCount);
        //    Console.ReadKey();
        //}
        //#endregion


        #region Count with custom predicate with complex type
        static void Main(string[] args)
        {
            //Using Method Syntax
            var MSCount = Employee.GetAllEmployees()
                           .Count(emp => {
                               if (emp.Department == "IT")
                                   return true;
                               else
                                   return false;
                           });

            //Using Query Syntax
            var QSCount = (from emp in Employee.GetAllEmployees()
                           select emp).Count(emp => {
                               if (emp.Department == "IT")
                                   return true;
                               else
                                   return false;
                           });

            Console.WriteLine("Total No of Employees of IT Department = " + QSCount);
            Console.ReadKey();
        }
        #endregion
    }
}
