namespace RealtimeInheritanceExample2
{
    //Base Class (Parent Class) - ElectronicDevice
    internal class ElectronicDevice
    {
        public string Brand { get; set; }
        public void PowerOn()
        {
            Console.WriteLine($"{Brand} device is powered on.");
        }
        public void PowerOff()
        {
            Console.WriteLine($"{Brand} device is powered off.");
        }
    }
}
