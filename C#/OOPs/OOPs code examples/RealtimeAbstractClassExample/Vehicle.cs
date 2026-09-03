namespace RealtimeAbstractClassExample
{
    //Vehicle.cs (Abstract Class)
    internal abstract class Vehicle
    {
        public string Brand { get; set; }
        // Abstract method with no body
        public abstract void Move();
        // Virtual method with a default implementation
        public virtual void Refuel()
        {
            Console.WriteLine($"{Brand} is refueling.");
        }
    }
}
