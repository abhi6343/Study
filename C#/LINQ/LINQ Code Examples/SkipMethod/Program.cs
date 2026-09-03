namespace SkipMethod
{
    internal class Program
    {
        //#region Skip
        //static void Main(string[] args)
        //{
        //    //Data Source 
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Skip the First Four Elements and Return Remaining Elements from the Data Source
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Skip(4).ToList();

        //    //Using Mixed Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num).Skip(4).ToList();

        //    //Accessing the Elements using a Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Skip with Where
        //static void Main(string[] args)
        //{
        //    //Sequence Contains 10 Elements
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Skipping the First four elements and Return Remaining Elements from the Sequence 
        //    //where Number > 3
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Where(num => num > 3).Skip(4).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          where num > 3
        //                          select num).Skip(4).ToList();

        //    //Accessing the Results using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Skip before where
        //static void Main(string[] args)
        //{
        //    //Sequence Contains 10 Elements
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Skipping the First three elements and Returns the Remaining Elements
        //    //from the Sequence where Number > 4
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Skip(3).Where(num => num > 4).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num)
        //                          .Skip(3).Where(num => num > 4).ToList();

        //    //Accessing the Results using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Data source null
        //static void Main(string[] args)
        //{
        //    //Sequence is Null
        //    List<int> numbers = null;
        //    //Skip the First three elements and Returns the Remaining Elements

        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Skip(3).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num)
        //                          .Skip(3).ToList();

        //    //Accessing the Results using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Skip with complex type
        static void Main(string[] args)
        {
            //Data Source
            List<Employee> employees = Employee.GetAllEmployees();

            //Skip First four Employees who are getting lowest Salary
            //Using Method Syntax
            List<Employee> ResultMS = employees.OrderBy(emp => emp.Salary).Skip(4).ToList();

            //Using Query Syntax
            List<Employee> ResultQS = (from emp in employees
                                       orderby emp.Salary ascending
                                       select emp).Skip(4).ToList();

            //Accessing the Results using Foreach Loop
            foreach (Employee emp in ResultMS)
            {
                Console.WriteLine($"ID:{emp.ID}, Name:{emp.Name}, Gender:{emp.Gender}, Salary:{emp.Salary}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
