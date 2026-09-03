namespace CarRentalSystem.DataClasses
{
    internal class Customer(string id, string name, string email, string drivingLicense)
    {
        public string Id => id;
        public string Name => name;
        public string Email => email;
        public string DrivingLicense => drivingLicense;

        public override string ToString() => Name;
    }
}
