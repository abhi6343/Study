namespace SealedClass
{
    internal sealed class Manager : Employee
    {
        double Bonus, Salary;
        public override void GetEmployeeData()
        {
            Console.WriteLine("Enter Manager Details:");
            Console.Write("Enter Manager ID:");
            Eid = int.Parse(Console.ReadLine());
            Console.Write("Enter Manager Name:");
            Ename = Console.ReadLine();
            Console.Write("Enter Manager Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Manager Bonus:");
            Bonus = double.Parse(Console.ReadLine());
        }
        public override void DisplayEmployeeData()
        {
            Console.WriteLine("\nManager Details Are:");
            Console.WriteLine($"Manager ID: {Eid}");
            Console.WriteLine($"Manager Name: {Ename}");
            Console.WriteLine($"Manager Salary: {Salary}");
            Console.WriteLine($"Manager Bonus: {Bonus}");
        }
    }



    //Further No Inheritance is Possible as we marked the class as sealed
    //public class TempManager : Manager
    //{
    //}
}
