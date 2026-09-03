namespace IsAandHasARelationship
{
    internal class Employee
    {
        //Using Address in Employee class
        //Establishing Has-A relationship i.e. Employee HAS-A Address
        public Address address;
        public int Id;
        public string Name;
        public Employee(int id, string name, Address adrs)
        {
            Id = id;
            Name = name;
            address = adrs;
        }
        public void Display()
        {
            Console.WriteLine($"Employee Id: {Id}");
            Console.WriteLine($"Employee Name: {Name}");
            Console.WriteLine($"AddressLine: {address.AddressLine}");
            Console.WriteLine($"City: {address.City}");
            Console.WriteLine($"State: {address.State}");
        }
    }
}
