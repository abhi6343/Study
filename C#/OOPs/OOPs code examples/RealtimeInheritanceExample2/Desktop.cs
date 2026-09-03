namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Desktop
    internal class Desktop : Device
    {
        public string CoolingSystem { get; set; }
        public Desktop(string processor, int ram, int storage, string coolingSystem)
            : base(processor, ram, storage)
        {
            CoolingSystem = coolingSystem;
        }
        public void DisplayDesktopInfo()
        {
            Console.WriteLine($"Desktop with {Processor}, {RAM}GB RAM, {Storage}GB Storage, and {CoolingSystem} cooling.");
        }
    }
}
