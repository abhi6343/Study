using CarRentalSystem.Enums;

namespace CarRentalSystem.Extensions
{
    internal class DamageReport(string vehicleId, string reservationId, DamageLevel levelAtPickup, DamageLevel levelAtReturn, string notes)
    {
        public string VehicleId => vehicleId;
        public string ReservationId => reservationId;
        public DamageLevel LevelAtPickup => levelAtPickup;
        public DamageLevel LevelAtReturn => levelAtReturn;
        public string Notes => notes;

        public bool HasNewDamage() => (int)LevelAtReturn > (int)LevelAtPickup;
    }
}
