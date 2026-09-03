namespace AggregateMethod
{
    internal class Program
    {
        //#region Witohut Aggregate method
        //static void Main(string[] args)
        //{
        //    string[] skills = { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET" };
        //    string result = string.Empty;
        //    foreach (string skill in skills)
        //    {
        //        result = result + skill + ", ";
        //    }

        //    //Find the index position of last comma
        //    int lastIndex = result.LastIndexOf(",");

        //    //Remove the last comma
        //    result = result.Remove(lastIndex);

        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Aggregate method
        //static void Main(string[] args)
        //{
        //    string[] skills = { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET" };
        //    string result = skills.Aggregate((s1, s2) => s1 + ", " + s2); 
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Product of integers without Aggregate method
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = { 3, 5, 7, 9 };
        //    int result = 1;
        //    foreach (int num in intNumbers)
        //    {
        //        result = result * num;
        //    }
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Product of integers with Aggregate method
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = { 3, 5, 7, 9 };
        //    int result = intNumbers.Aggregate((n1, n2) => n1 * n2);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Aggregate with seed value
        //static void Main(string[] args)
        //{
        //    int[] intNumbers = { 3, 5, 7, 9 };
        //    int result = intNumbers.Aggregate(2, (n1, n2) => n1 * n2);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Aggregate with complex type to get total salary
        //static void Main(string[] args)
        //{
        //    int Salary = Employee.GetAllEmployees()
        //    .Aggregate<Employee, int>(0,
        //    (TotalSalary, emp) => TotalSalary += emp.Salary);
        //    Console.WriteLine(Salary);
        //    Console.ReadKey();
        //}
        //#endregion


        //#region Aggregate with complex type to get all names in one string
        //static void Main(string[] args)
        //{
        //    string CommaSeparatedEmployeeNames =
        //            Employee.GetAllEmployees().Aggregate<Employee, string>(
        //                "Employee Names: ", // seed value
        //                (employeeNames, employee) => employeeNames = 
        //                employeeNames + employee.Name + ", ");

        //    int LastIndex = CommaSeparatedEmployeeNames.LastIndexOf(",");
        //    CommaSeparatedEmployeeNames = CommaSeparatedEmployeeNames.Remove(LastIndex);

        //    Console.WriteLine(CommaSeparatedEmployeeNames);
        //    Console.ReadKey(); 
        //}
        //#endregion


        #region Aggregate with Rsesult selector
        static void Main(string[] args)
        {
            string CommaSeparatedEmployeeNames =
                Employee.GetAllEmployees().Aggregate<Employee, string, string>(
                    "Employee Names: ", // seed value

                    (employeeNames, employee) => employeeNames = 
                    employeeNames + employee.Name + ", "
                    ,
                    employeeNames => employeeNames.Substring(employeeNames.Length - 1));

            Console.WriteLine(CommaSeparatedEmployeeNames);
            Console.ReadKey();
        }
        #endregion
    }
}
