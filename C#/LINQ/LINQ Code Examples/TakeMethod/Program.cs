namespace TakeMethod
{
    internal class Program
    {
        //#region Take method
        //static void Main(string[] args)
        //{
        //    //Sequence Contains 10 Elements
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Fetching the First four elements from the Sequence using Take Method
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Take(4).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num).Take(4).ToList();

        //    //Accessing the Results using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Take with filtering
        //static void Main(string[] args)
        //{
        //    //Sequence Contains 10 Elements
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Fetching the First four elements from the Sequence where Number > 3
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Where(num => num > 3).Take(4).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          where num > 3
        //                          select num).Take(4).ToList();

        //    //Accessing the Results using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Above example first take and then filter
        //static void Main(string[] args)
        //{
        //    //Sequence Contains 10 Elements
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Fetching the First four elements from the Sequence where Number > 2
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Take(4).Where(num => num > 2).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num)
        //                          .Take(4)
        //                          .Where(num => num > 2).ToList();

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
        //    //Data Source is Null
        //    List<int> numbers = null;

        //    //Fetching the First four elements from the Sequence
        //    //Using Method Syntax
        //    List<int> ResultMS = numbers.Take(4).ToList();

        //    //Using Query Syntax
        //    List<int> ResultQS = (from num in numbers
        //                          select num)
        //                          .Take(4).ToList();

        //    //Accessing the Results using Foreach Loop
        //    foreach (var num in ResultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region Take with complex type
        static void Main(string[] args)
        {
            //Data Source
            List<Employee> employees = Employee.GetAllEmployees();

            //Fetching First four Employees who are getting Highest Salary
            //Using Method Syntax
            List<Employee> ResultMS = employees.OrderByDescending(emp => emp.Salary).Take(4).ToList();

            //Using Query Syntax
            List<Employee> ResultQS = (from emp in employees
                                       orderby emp.Salary descending
                                       select emp).Take(4).ToList();

            //Accessing the Results using Foreach Loop
            foreach (Employee emp in ResultMS)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Gender: {emp.Gender}, Salary: {emp.Salary}");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
