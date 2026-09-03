namespace SealedMethod
{
    //The InkJet class can not override the Display Method as it is marked sealed in LaserJet class.
    //So, InkJet will have same Display feature i.e it also has "Display Dimention: 10x10".
    internal class InkJet : LaserJet
    {
        //The following method overriding will give compile time error
        //'InkJet.Display()': cannot override inherited member 'LaserJet.Display() because it is sealed
        //public override void Display()
        //{
        // Console.WriteLine("Some Different Display Dimension");
        //}
        public override void Print()
        {
            Console.WriteLine("InkJet Printer Printing...");
        }
    }
}
