namespace RealtimePolymorphismExample
{
    // Derived class: Boat
    internal class Boat : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Piloting a boat. Watch out for waves and other vessels!");
        }
    }
}
