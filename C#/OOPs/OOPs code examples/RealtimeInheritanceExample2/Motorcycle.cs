namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Motorcycle
    internal class Motorcycle : Vehicle
    {
        public bool HasSideCar { get; set; }
        public override void Accelerate()
        {
            Speed += 7;
            Console.WriteLine($"Motorcycle accelerates. Current speed: {Speed} km/h.");
        }
        public void UseKickstand()
        {
            Console.WriteLine("Kickstand placed.");
        }
    }
}
