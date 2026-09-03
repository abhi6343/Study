namespace SealedMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            printer.Display();
            printer.Print();
            LaserJet laserJet = new LaserJet();
            laserJet.Display();
            laserJet.Print();
            InkJet inkJet = new InkJet();
            inkJet.Display();
            inkJet.Print();


            Class2 obj1 = new Class2();
            obj1.Method1();
            Class3 obj3 = new Class3();
            obj3.Method1();
            obj3.Method2();


            Console.ReadKey();
        }
    }
}
