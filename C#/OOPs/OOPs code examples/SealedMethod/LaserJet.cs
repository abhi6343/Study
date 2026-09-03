namespace SealedMethod
{
    internal class LaserJet : Printer
    {
        //The LaserJet class Overriding the two parent class virtal methods
        //But making the Display method as sealed, so the child classes of Las
        //will not override this method
        public sealed override void Display()
        {
            Console.WriteLine("Display Dimension: 10x10");
        }
        //The Print method can be override under the Child class of LaserJet c
        public override void Print()
        {
            Console.WriteLine("LaserJet Printer Printing...\n");
        }
    }
}
