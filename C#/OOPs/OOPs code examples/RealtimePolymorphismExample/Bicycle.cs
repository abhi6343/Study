namespace RealtimePolymorphismExample
{
    // Derived class: Bicycle
    internal class Bicycle : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Riding a bicycle. Stay in the bike lane and wear a helmet!");
        }
    }
}
