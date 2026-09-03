namespace FirstandFirstOrDefaultMethod
{
    internal class Program
    {
        //#region First method
        //static void Main(string[] args)
        //{
        //    //Fetching the First Element from the Data Source using First Method
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.First();

        //    //Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).First();

        //    //Printing the value returned by the First Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region First method with predicate
        //static void Main(string[] args)
        //{
        //    //Fetching the First Element from the Data Source which is Divisble by 2
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.First(num => num % 2 == 0);

        //    //Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).First(num => num % 2 == 0);

        //    //Printing the value returned by the First Method
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region First with empty data source
        //static void Main(string[] args)
        //{
        //    //Empty Data Source
        //    List<int> numbersEmpty = new List<int>() { };
        //    int MethodSyntax = numbersEmpty.First();
        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region First with predicate return no value
        //static void Main(string[] args)
        //{
        //    //Specified Condition Doesnot Return Any Element
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    int MethodSyntax = numbers.First(num => num > 50);

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region FirstOrDefault method
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.FirstOrDefault();

        //    //Using Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).FirstOrDefault();

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region FirstOrDefault with predicate
        //static void Main(string[] args)
        //{
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax = numbers.FirstOrDefault(num => num > 5);

        //    //Using Query Syntax
        //    int QuerySyntax = (from num in numbers
        //                       select num).FirstOrDefault(num => num > 5);

        //    Console.WriteLine(MethodSyntax);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Empty Data Source or predicate returns no value
        //static void Main(string[] args)
        //{
        //    //Empty Data Source
        //    List<int> numbersEmpty = new List<int>();

        //    //Using Method Syntax
        //    int MethodSyntax1 = numbersEmpty.FirstOrDefault();

        //    //Using Query Syntax
        //    int QuerySyntax1 = (from num in numbersEmpty
        //                        select num).FirstOrDefault();
        //    Console.WriteLine(MethodSyntax1);

        //    //Specified condition doesnot return any element
        //    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    //Using Method Syntax
        //    int MethodSyntax2 = numbers.FirstOrDefault(num => num > 50);

        //    //Using Query Syntax
        //    int QuerySyntax2 = (from num in numbers
        //                        select num).FirstOrDefault(num => num > 50);
        //    Console.WriteLine(MethodSyntax2);
        //    Console.ReadLine();
        //}
        //#endregion


        //#region First with complex data type
        //static void Main(string[] args)
        //{
        //    //Data Source
        //    List<Employee> listEmployees = Employee.GetAllEmployees();

        //    //Fetching the First Employee from listEmployees Collection
        //    Employee Employee1 = listEmployees.First();

        //    Console.WriteLine($"{Employee1.ID}, {Employee1.Name}, {Employee1.Gender}, {Employee1.Salary}");

        //    //Fetch the First Employee where the Gender is Male
        //    Employee Employee2 = listEmployees.First(emp => emp.Gender == "Male");
        //    Console.WriteLine($"{Employee2.ID}, {Employee2.Name}, {Employee2.Gender}, {Employee2.Salary}");

        //    //Fetch the First Employee where the Salary is less than 30000
        //    Employee Employee3 = listEmployees.First(emp => emp.Salary < 30000);
        //    Console.WriteLine($"{Employee3.ID}, {Employee3.Name}, {Employee3.Gender}, {Employee3.Salary}");

        //    Console.ReadLine();
        //}
        //#endregion


        #region FirstOrDefault with complex data type
        static void Main(string[] args)
        {
            //Data Source
            List<Employee> listEmployees = Employee.GetAllEmployees();

            //Fetching the First Employee from listEmployees Collection
            Employee Employee1 = listEmployees.FirstOrDefault();
            Console.WriteLine($"{Employee1.ID}, {Employee1.Name}, {Employee1.Gender}, {Employee1.Salary}");

            //Fetch the First Employee where the Gender is Female
            Employee Employee2 = listEmployees.FirstOrDefault(emp => emp.Gender == "Female");
            Console.WriteLine($"{Employee2.ID}, {Employee2.Name}, {Employee2.Gender}, {Employee2.Salary}");

            //Fetch the First Employee where the Salary is greater than 30000
            Employee Employee3 = listEmployees.First(emp => emp.Salary > 30000);
            Console.WriteLine($"{Employee3.ID}, {Employee3.Name}, {Employee3.Gender}, {Employee3.Salary}");

            Console.ReadLine();
        }
        #endregion
    }
}
