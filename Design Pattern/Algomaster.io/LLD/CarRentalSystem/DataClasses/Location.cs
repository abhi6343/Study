namespace CarRentalSystem.DataClasses
{
    internal class Location(string id, string name, string address)
    {
        public string Id => id;
        public string Name => name;
        public string Address => address;

        public override string ToString() => Name;
    }
}
