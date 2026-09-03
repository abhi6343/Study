using System.Net;

namespace DefaultIfEmptyMethod
{
    internal class Program
    {
        //#region DefaultIfEmpty
        //static void Main(string[] args)
        //{
        //    //Sequence is not empty
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    //DefaultIfEmpty Method will return a new sequence with existing sequence values
        //    //Using Method Syntax
        //    IEnumerable<int> resultMS = numbers.DefaultIfEmpty();

        //    //Using Query Syntax
        //    IEnumerable<int> resultQS = (from num in numbers
        //                                 select num).DefaultIfEmpty();

        //    //Accessing the new sequence values using for each loop
        //    foreach (int num in resultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region DefaultIfEmpty when sequence is empty
        //static void Main(string[] args)
        //{
        //    //Sequence is empty
        //    List<int> numbers = new List<int>();

        //    //DefaultIfEmpty Method will return a new sequence with one element having the value 0
        //    //as the Sequence is Empty
        //    //Using Method Syntax
        //    IEnumerable<int> resultMS = numbers.DefaultIfEmpty();

        //    //Using Query Syntax
        //    IEnumerable<int> resultQS = (from num in numbers
        //                                 select num).DefaultIfEmpty();

        //    //Accessing the new sequence values using for each loop
        //    foreach (int num in resultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Supply User-Given Values when the Sequence is Empty
        //static void Main(string[] args)
        //{
        //    //Sequence is empty
        //    List<int> numbers = new List<int>();

        //    //DefaultIfEmpty Method will return 5 as the Sequence is Empty
        //    //as the Sequence is Empty
        //    //Using Method Syntax
        //    IEnumerable<int> resultMS = numbers.DefaultIfEmpty(5);

        //    //Using Query Syntax
        //    IEnumerable<int> resultQS = (from num in numbers
        //                                 select num).DefaultIfEmpty();

        //    //Accessing the new sequence values using for each loop
        //    foreach (int num in resultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region Sequence is not Empty and we have Supplied a Value to the DefaultIfEmpty method
        //static void Main(string[] args)
        //{
        //    //Sequence is not empty
        //    List<int> numbers = new List<int>() { 10, 20, 30 };

        //    //DefaultIfEmpty Method will return the Original Sequence values
        //    //as the Sequence is not Empty
        //    //Using Method Syntax
        //    IEnumerable<int> resultMS = numbers.DefaultIfEmpty(5);

        //    //Using Query Syntax
        //    IEnumerable<int> resultQS = (from num in numbers
        //                                 select num).DefaultIfEmpty();

        //    //Accessing the new sequence values using for each loop
        //    foreach (int num in resultMS)
        //    {
        //        Console.Write($"{num} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region DefaultIfEmpty Method with Complex Type
        //static void Main(string[] args)
        //{
        //    //Sequence is not empty
        //    List<Employee> employees = Employee.GetAllEmployees();

        //    //Create an Employee Object to pass into the DefaultIfEmpty method incase the sequence is Empty
        //    Employee emp5 = new Employee() { ID = 5, Name = "Hina", Salary = 10000, Gender = "Female" };

        //    //DefaultIfEmpty Method will return the Original Sequence values
        //    //as the Sequence is not Empty
        //    //Using Method Syntax
        //    IEnumerable<Employee> resultMS = employees.DefaultIfEmpty(emp5);

        //    //Using Query Syntax
        //    IEnumerable<Employee> resultQS = (from employee in employees
        //                                      select employee).DefaultIfEmpty(emp5);

        //    //Accessing the new sequence values using for each loop
        //    foreach (Employee emp in resultMS)
        //    {
        //        Console.WriteLine($"ID:{emp.ID}, Name:{emp.Name}, Gender:{emp.Gender}, Salary:{emp.Salary} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        //#region DefaultIfEmpty Method with Complex Type when sequence is empty
        //static void Main(string[] args)
        //{
        //    //Sequence is empty
        //    List<Employee> employees = new List<Employee>();

        //    //Create an Employee Object to pass into the DefaultIfEmpty method incase the sequence is Empty
        //    Employee emp5 = new Employee() { ID = 5, Name = "Hina", Salary = 10000, Gender = "Female" };

        //    //DefaultIfEmpty Method will return the Employee Object that we passed
        //    //as the Sequence is Empty
        //    //Using Method Syntax
        //    IEnumerable<Employee> resultMS = employees.DefaultIfEmpty(emp5);

        //    //Using Query Syntax
        //    IEnumerable<Employee> resultQS = (from employee in employees
        //                                      select employee).DefaultIfEmpty(emp5);

        //    //Accessing the new sequence values using for each loop
        //    foreach (Employee emp in resultMS)
        //    {
        //        Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Gender: {emp.Gender}, Salary: {emp.Salary} ");
        //    }
        //    Console.ReadLine();
        //}
        //#endregion


        #region DefaultIfEmpty in Left Outer Join
        static void Main()
        {
            //Using DefaultIfEmpty Method which does not take any parameter
            var query1 = from employee in Employee.GetAllEmployees() //Left Data Source
                        join address in Address.GetAddress() //Right Data Source
                                     on employee.AddressId equals address.ID //Inner Join Condition
                                     into EmployeeAddressGroup //Performing LINQ Group Join
                        from address in EmployeeAddressGroup.DefaultIfEmpty() //Performing Left Outer Join
                                     select new //Projecting the Result to Anonymous Type
                                     {
                                         EmployeeId = employee.ID,
                                         Name = employee.Name,
                                         Addrees = address?.AddressLine ?? "NA" //Check for Null Reference Exception
                                     };

            //Using Second Overloaded Version of DefaultIfEmpty Method which takes default value as a parameter
            var query2 = from employee in Employee.GetAllEmployees() //Left Data Source
                        join address in Address.GetAddress() //Right Data Source
                                     on employee.AddressId equals address.ID //Inner Join Condition
                                     into EmployeeAddressGroup //Performing LINQ Group Join
                        from address in EmployeeAddressGroup.DefaultIfEmpty(new Address() { AddressLine = "Address Not Available" }) //Performing Left Outer Join
                                     select new //Projecting the Result to Anonymous Type
                                     {
                                         EmployeeId = employee.ID,
                                         Name = employee.Name,
                                         Addrees = address.AddressLine
                                     };

            foreach (var item in query1)
            {
                Console.WriteLine($"EmployeeId: {item.EmployeeId}, Name: {item.Name}, Address: {item.Addrees}");
            }

            Console.ReadKey();
        }
        #endregion
    }
}
