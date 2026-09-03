namespace MethodOverriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Class1 obj1 = new Class2();
            //obj1.Show();
            //Class2 obj2 = new Class2();
            //obj2.Show();


            //#region Not overriding vitual method
            //Class3 obj3 = new Class3();
            //obj3.Show();
            //Class1 obj4 = new Class3();
            //obj4.Show();
            //#endregion


            #region Parent method call from child class
            Class1 obj1 = new Class2();
            obj1.Show();
            Class2 obj2 = new Class2();
            obj2.Show();
            #endregion


            #region Method Overriding Real-Time Example
            Employee emp1 = new Developer
            {
                Id = 1001,
                Name = "Ramesh",
                Salary = 500000,
                Designation = "Developer"
            };
            double bonus = emp1.CalculateBonus(emp1.Salary);
            Console.WriteLine($"Name: {emp1.Name}, Designation: {emp1.Designation}, Salary: {emp1.Salary}, Bonus:{bonus}");
            Console.WriteLine();
            Employee emp2 = new Manager
            {
                Id = 1002,
                Name = "Sachin",
                Salary = 800000,
                Designation = "Manager"
            };
            bonus = emp2.CalculateBonus(emp2.Salary);
            Console.WriteLine($"Name: {emp2.Name}, Designation: {emp2.Designation}, Salary: {emp2.Salary}, Bonus:{bonus}");
            Console.WriteLine();
            Employee emp3 = new Admin
            {
                Id = 1003,
                Name = "Rajib",
                Salary = 300000,
                Designation = "Admin"
            };
            bonus = emp3.CalculateBonus(emp3.Salary);
            Console.WriteLine($"Name: {emp3.Name}, Designation: {emp3.Designation}, Salary: {emp3.Salary}, Bonus:{bonus}");
            Console.WriteLine();
            Employee emp4 = new Developer
            {
                Id = 1004,
                Name = "Priyanka",
                Salary = 200000,
                Designation = "Developer"
            };
            bonus = emp1.CalculateBonus(emp4.Salary);
            Console.WriteLine($"Name: {emp4.Name}, Designation: {emp4.Designation}, Salary: {emp4.Salary}, Bonus:{bonus}");
            #endregion


            Console.ReadKey();
        }
    }
}
