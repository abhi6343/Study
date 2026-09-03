namespace RealtimeInheritanceExample2
{
    //Base Class (Parent Class) - Device
    internal class Device
    {
        public string Processor { get; set; }
        public int RAM { get; set; } // in GB
        public int Storage { get; set; } // in GB
        public Device(string processor, int ram, int storage)
        {
            Processor = processor;
            RAM = ram;
            Storage = storage;
        }
        public void BootUp()
        {
            Console.WriteLine("Device is booting up...");
        }
    }
}
