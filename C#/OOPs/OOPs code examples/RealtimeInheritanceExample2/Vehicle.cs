namespace RealtimeInheritanceExample2
{
    //Base Class (Parent Class) - Vehicle
    internal class Vehicle
    {
        public int Speed { get; protected set; }
        public void Start()
        {
            Console.WriteLine("Vehicle started.");
        }
        public void Stop()
        {
            Console.WriteLine("Vehicle stopped.");
        }
        public virtual void Accelerate()
        {
            Speed += 5;
            Console.WriteLine($"Vehicle accelerates. Current speed: {Speed} km/h.");
        }
    }
}
