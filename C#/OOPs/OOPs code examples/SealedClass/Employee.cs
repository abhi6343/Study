namespace SealedClass
{
    internal class Employee
    {
        protected int Eid, Eage;
        protected string Ename, Eaddress;
        public virtual void GetEmployeeData()
        {
            Console.WriteLine("Enter Emplpyee Details:");
            Console.Write("Enter Employee ID:");
            Eid = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Name:");
            Ename = Console.ReadLine();
            Console.Write("Enter Employee Address:");
            Eaddress = Console.ReadLine();
            Console.Write("Enter Employee Age:");
            Eage = int.Parse(Console.ReadLine());
        }
        public virtual void DisplayEmployeeData()
        {
            Console.WriteLine("\nEmplpyee Details Are:");
            Console.WriteLine($"Employee ID: {Eid}");
            Console.WriteLine($"Employee Name: {Ename}");
            Console.WriteLine($"Employee Address: {Eaddress}");
            Console.WriteLine($"Employee Age: {Eage}");
        }
    }
}
