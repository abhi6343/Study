namespace MultipleInheritance
{
    internal class Demo : Car, Bus
    {
        //How to implement the Drive() Method inherited from Bus and Car
        void Car.Drive()
        {
            Console.WriteLine("Drive Car");
        }
        void Bus.Drive()
        {
            Console.WriteLine("Drive Bus");
        }
    }
}
