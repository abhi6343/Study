using CarRentalSystem.Enums;

namespace CarRentalSystem.DataClasses
{
    internal class Vehicle(string id, string licensePlate, VehicleType vehicleType, double dailyRate, string locationId)
    {
        public string Id => id;
        public string LicensePlate => licensePlate;
        public VehicleType VehicleType => vehicleType;
        public double DailyRate => dailyRate;
        public VehicleStatus Status { get; set; } = VehicleStatus.AVAILABLE;
        public string LocationId { get; set; } = locationId;

        public override string ToString() => $"Vehicle{{id={Id}, plate={LicensePlate}, type={VehicleType}, rate=${DailyRate}/day}}";
    }
}
