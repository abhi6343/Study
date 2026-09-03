namespace OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(3, 7);
            c1.Display();
            Complex c2 = new Complex(5, 2);
            c2.Display();
            Complex c3 = Complex.Add(c1, c2);
            c3.Display();
            Console.ReadKey();
        }
    }
}
