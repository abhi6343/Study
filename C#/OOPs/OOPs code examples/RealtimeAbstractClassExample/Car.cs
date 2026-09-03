namespace RealtimeAbstractClassExample
{
    //Car.cs (Concrete Class)
    internal class Car : Vehicle
    {
        public Car(string brand)
        {
            Brand = brand;
        }// Concrete implementation of the Move method for Car
        public override void Move()
        {
            Console.WriteLine($"{Brand} car is driving.");
        }
        // Overriding the Refuel method for Car
        public override void Refuel()
        {
            Console.WriteLine($"{Brand} car is filling up with gas.");
        }
    }
}
