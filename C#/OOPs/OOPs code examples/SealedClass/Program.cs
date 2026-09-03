namespace SealedClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager m1 = new Manager();
            m1.GetEmployeeData();
            m1.DisplayEmployeeData();
            Console.ReadKey();
        }
    }
}
