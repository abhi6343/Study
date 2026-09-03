namespace VariableReferenceandInstanceofaClass
{
    internal class Program
    {
        int x = 10;
        static void Main(string[] args)
        {
            Console.WriteLine(x);


            Program e = new Program();
            Console.WriteLine(e.x);


            //Variable
            //Uninitialized copy of class Program
            Program p;
            Console.WriteLine(p.x);

            Program pe; //pe is Variable of class Program
            pe = new Program(); //pe is instance of class Program
            Console.WriteLine(pe.x);


            Program e1 = new Program(); //e1 is Instance of class Example
            Program e2 = new Program(); //e2 is Instance of class Example
            Console.WriteLine($"e1.x: {e1.x} and e2.x: {e2.x}");


            e1.x = 50; //Modifying the x variable of e1 instance
            Console.WriteLine($"e1.x: {e1.x} and e2.x {e2.x}");


            e2.x = 150; //Modifying the x variable of e2 instance
            Console.WriteLine($"e1.x: {e1.x} and e2.x {e2.x}");


            Program pe1 = new Program(); //pe1 is Instance of class Example
            Program pe2 = pe1; //pe2 is Reference of class Example
            Console.WriteLine($"e1.x: {pe1.x} and e2.x: {pe2.x}");
            pe1.x = 50; //Modifying the x variable of pe1 instance
            Console.WriteLine($"e1.x: {pe1.x} and e2.x {pe2.x}");


            pe2.x = 150; //Modifying the x variable of pe2 reference
            Console.WriteLine($"e1.x: {e1.x} and e2.x {e2.x}");


            Console.ReadKey();
        }
    }
}
