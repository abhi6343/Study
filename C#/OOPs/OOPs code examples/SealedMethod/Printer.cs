namespace SealedMethod
{
    internal class Printer
    {
        //The Printer class declaring two virtual methods
        public virtual void Display()
        {
            Console.WriteLine("Display Dimension: 5x5");
        }
        public virtual void Print()
        {
            Console.WriteLine("Printer Printing...\n");
        }
    }
}
