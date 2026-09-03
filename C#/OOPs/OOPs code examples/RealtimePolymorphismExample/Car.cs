namespace RealtimePolymorphismExample
{
    // Derived class: Car
    internal class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving a car. Follow road signs!");
        }
    }
}
