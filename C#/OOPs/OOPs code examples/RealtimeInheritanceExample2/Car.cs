namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Car
    internal class Car : Vehicle
    {
        public int Doors { get; set; }
        public override void Accelerate()
        {
            Speed += 10;
            Console.WriteLine($"Car accelerates. Current speed: {Speed} km/h.");
        }
        public void OpenSunroof()
        {
            Console.WriteLine("Sunroof opened.");
        }
    }
}
