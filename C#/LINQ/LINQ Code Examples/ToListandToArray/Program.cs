namespace ToListandToArray
{
    internal class Program
    {
        //#region ToList
        //public static void Main()
        //{
        //    //Creating Integer Array
        //    int[] numbersArray = { 10, 22, 30, 40, 50, 60 };

        //    //Converting Integer Array to List using ToList method
        //    List<int> numbersList = numbersArray.ToList();

        //    //Accessing the List Elements
        //    foreach (var num in numbersList)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region ToList with complex type
        //public static void Main()
        //{
        //    //Create an Array of Employees
        //    Employee[] EmployeesArray = new Employee[]
        //    {
        //        new Employee() {ID = 1, Name = "Pranaya", Department = "IT" },
        //        new Employee() {ID = 2, Name = "Priyanka", Department = "HR" },
        //        new Employee() {ID = 3, Name = "Preety", Department = "HR" },
        //        new Employee() {ID = 4, Name = "Sambit", Department = "IT" },
        //        new Employee() {ID = 5, Name = "Sudhanshu", Department = "IT"}
        //    };

        //    //Converting Array to List
        //    List<Employee> EmployeesList = EmployeesArray.ToList();

        //    //Accessing the Elements of the List
        //    foreach (var emp in EmployeesArray)
        //    {
        //        Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region ToList with data soure null
        //public static void Main()
        //{
        //    //Creating Integer Array and Initializing it with NULL
        //    int[] numbersArray = null;

        //    //Converting Integer Array to List using ToList method
        //    List<int> numbersList = numbersArray.ToList();

        //    //Accessing the List Elements
        //    foreach (var num in numbersList)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region ToArray
        //public static void Main()
        //{
        //    //Create a List
        //    List<int> numbersList = new List<int>(){10, 22, 30, 40, 50, 60 };

        //    //Converting List to Array
        //    int[] numbersArray = numbersList.ToArray();

        //    //Accessing the Elements of the Array
        //    foreach (var num in numbersArray)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        //#region ToArray with complex type
        //public static void Main()
        //{
        //    //Create a List of Employees
        //    List<Employee> EmployeesList = new List<Employee>()
        //    {
        //        new Employee() {ID = 1, Name = "Pranaya", Department = "IT" },
        //        new Employee() {ID = 2, Name = "Priyanka", Department = "HR" },
        //        new Employee() {ID = 3, Name = "Preety", Department = "HR" },
        //        new Employee() {ID = 4, Name = "Sambit", Department = "IT" },
        //        new Employee() {ID = 5, Name = "Sudhanshu", Department = "IT"}
        //    };

        //    //Converting List to Array
        //    Employee[] EmployeesArray = EmployeesList.ToArray();

        //    //Accessing the Elements of the Array
        //    foreach (var emp in EmployeesArray)
        //    {
        //        Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}");
        //    }
        //    Console.ReadKey();
        //}
        //#endregion


        #region ToArray with data source null
        public static void Main()
        {
            //Create a List
            List<int> numbersList = null;

            //Converting List to Array
            int[] numbersArray = numbersList.ToArray();

            //Accessing the Elements of the Array
            foreach (var num in numbersArray)
            {
                Console.Write($"{num} ");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
