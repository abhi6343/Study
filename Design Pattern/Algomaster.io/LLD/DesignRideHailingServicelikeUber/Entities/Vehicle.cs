using RideHailingServicelikeUber.Enums;

namespace RideHailingServicelikeUber.Entities
{
    internal class Vehicle(string license, string model, RideType type)
    {
        public string LicenseNumber => license;
        public string Model => model;
        public RideType Type => type;
    }
}
