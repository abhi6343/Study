namespace LastandLasttOrDefaultMethod
{
    internal class Program
    {
        //#region Last method
        //static void Main(string[] args)
        //{
        //    //Fetching the Last Element from the Data Source using Last Method
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.Last();

        //    //Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).Last();

        //    //Printing the value returned by the Last Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Last method with predicate
        //static void Main(string[] args)
        //{
        //    //Fetching the Last Element from the Data Source which is Divisble by 3
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.Last(num => num % 3 == 0);

        //    //Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).Last(num => num % 3 == 0);

        //    //Printing the value returned by the Last Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Last method on empty data source
        //static void Main(string[] args)
        //{
        //    //Empty Data Source
        //    List<int> numbersEmpty = new List<int>();

        //    int MethodSyntax = numbersEmpty.Last();

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Lat method when predicate returns no value
        //static void Main(string[] args)
        //{
        //    //Specified Condition Doesnot Return Any Element
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    int MethodSyntax = numbers.Last(num => num > 50);

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region LastOrDefault method
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.LastOrDefault();

        //    //Using Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).LastOrDefault();

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region LastOrDefault method with predicate
        //static void Main(string[] args)
        //{
        //    //Fetching the Last Element which is less than 5
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.LastOrDefault(num => num < 5);

        //    //Using Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).LastOrDefault(num => num < 5);

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region LastOrDefault Method on empty data source or when predicate returns no value
        //static void Main(string[] args)
        //{
        //    //Empty Data Source
        //    List<int> numbersEmpty = new List<int>();

        //    //Using Method Syntax
        //    int MethodSyntax1 = numbersEmpty.LastOrDefault();

        //    //Using Query Syntax
        //    int QuerySyntax1 = (from num in numbersEmpty
        //                        select num).LastOrDefault();

        //    Console.WriteLine(MethodSyntax1);

        //    //Specified condition doesnot return any element
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax2 = numbers.LastOrDefault(num => num > 50);

        //    //Using Query Syntax
        //    int QuerySyntax2 = (from num in numbers
        //                        select num).LastOrDefault(num => num > 50);

        //    Console.WriteLine(MethodSyntax2);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Last Method with Complex Type
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<Employee> listEmployees = Employee.GetAllEmployees();

        //    //Fetching the Last Employee from listEmployees Collection
        //    Employee Employee1 = listEmployees.Last();

        //    Console.WriteLine($"{Employee1.ID}, {Employee1.Name}, {Employee1.Gender}, {Employee1.Salary}");

        //    //Fetch the Last Employee where the Gender is Male
        //    Employee Employee2 = listEmployees.Last(emp => emp.Gender == "Male");

        //    Console.WriteLine($"{Employee2.ID}, {Employee2.Name}, {Employee2.Gender}, {Employee2.Salary}");

        //    //Fetch the Last Employee where the Salary is less than 30000
        //    Employee Employee3 = listEmployees.Last(emp => emp.Salary < 30000);

        //    Console.WriteLine($"{Employee3.ID}, {Employee3.Name}, {Employee3.Gender}, {Employee3.Salary}");
        //    Console.ReadLine();
        //}
        //#endregion


        #region LastOrDefault Method with Complex Type
        static void Main(string[] args)
        {
            //Data Source
            List<Employee> listEmployees = Employee.GetAllEmployees();

            //Fetching the Last Employee from listEmployees Collection
            Employee Employee1 = listEmployees.LastOrDefault();

            Console.WriteLine($"{Employee1.ID}, {Employee1.Name}, {Employee1.Gender}, {Employee1.Salary}");

            //Fetch the Last Employee where the Gender is Male
            Employee Employee2 = listEmployees.LastOrDefault(emp => emp.Gender == "Male");

            Console.WriteLine($"{Employee2.ID}, {Employee2.Name}, {Employee2.Gender}, {Employee2.Salary}");

            //Fetch the Last Employee where the Salary is less than 30000
            Employee Employee3 = listEmployees.Last(emp => emp.Salary < 30000);

            Console.WriteLine($"{Employee3.ID}, {Employee3.Name}, {Employee3.Gender}, {Employee3.Salary}");
            Console.ReadLine();
        }
        #endregion
    }
}
