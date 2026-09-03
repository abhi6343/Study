namespace RealtimeInheritanceExample2
{
    internal class Laptop : Device
    {
        public int BatteryLife { get; set; } // in hours
        public Laptop(string processor, int ram, int storage, int batteryLife)
            : base(processor, ram, storage)
        {
            BatteryLife = batteryLife;
        }
        public void DisplayLaptopInfo()
        {
            Console.WriteLine($"Laptop with {Processor}, {RAM}GB RAM, {Storage}GB Storage, and {BatteryLife} hours battery life.");
        }
    }
}
