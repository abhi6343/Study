namespace RealtimeInterfaceExample
{
    //Step 2: Implement the interface for different types of vehicles.
    // Car.cs
    internal class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("The car drives on the road.");
        }
    }
}
