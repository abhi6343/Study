namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - MobilePhone
    internal class MobilePhone : ElectronicDevice
    {
        public void MakeCall(string number)
        {
            Console.WriteLine($"Calling {number} from {Brand} mobile phone.");
        }
        public void ReceiveCall(string number)
        {
            Console.WriteLine($"Receiving call from {number} on {Brand} mobile phone.");
        }
    }
}
