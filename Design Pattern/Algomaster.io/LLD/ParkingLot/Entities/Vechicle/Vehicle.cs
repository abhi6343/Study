using ParkingLot.Enums;

namespace ParkingLot.Entities.Vechicle
{
    internal class Vehicle(string licenseNumber, VehicleSize size)
    {
        public VehicleSize Size { get{ return size; } }
        public string LicenseNumber { get{ return licenseNumber; } }
    }
}
