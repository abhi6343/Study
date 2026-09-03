namespace RealtimeAbstractionExample
{
    //Concrete Implementation
    internal class ElectricTrain : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Electric train is starting by powering up.");
        }
        public override void Stop()
        {
            Console.WriteLine("Electric train is stopping by cutting off the power.");
        }
    }
}
