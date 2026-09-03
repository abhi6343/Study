namespace RealtimeAbstractionExample
{
    //Concrete Implementation
    internal class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car is starting with a key turn.");
        }
        public override void Stop()
        {
            Console.WriteLine("Car is stopping using its brakes.");
        }
    }
}
