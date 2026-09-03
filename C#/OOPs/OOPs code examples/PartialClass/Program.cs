namespace PartialClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee emp = new Employee
            //{
            //    FirstName = "Pranaya",
            //    LastName = "Rout",
            //    Salary = 100000,
            //    Gender = "Male"
            //};
            //emp.DisplayFullName();
            //emp.DisplayEmployeeDetails();


            PartialEmployee emp = new PartialEmployee()
            {
                FirstName = "Pranaya",
                LastName = "Rout",
                Salary = 100000,
                Gender = "Male"
            };
            emp.DisplayFullName();
            emp.DisplayEmployeeDetails();


            Console.ReadKey();
        }
    }
}
