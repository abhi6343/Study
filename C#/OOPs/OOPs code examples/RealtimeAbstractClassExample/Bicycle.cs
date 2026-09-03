namespace RealtimeAbstractClassExample
{
    //Bicycle.cs (Concrete Class)
    internal class Bicycle : Vehicle
    {
        public Bicycle(string brand)
        {
            Brand = brand;
        }
        // Concrete implementation of the Move method for Bicycle
        public override void Move()
        {
            Console.WriteLine($"{Brand} bicycle is pedaling.");
        }
        // Overriding the Refuel method specifically for Bicycle as they don't traditionally refuel
        public override void Refuel()
        {
            Console.WriteLine($"{Brand} bicycle doesn't need to refuel.");
        }
    }
}
