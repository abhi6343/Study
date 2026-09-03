using CarRentalSystem.Enums;

namespace CarRentalSystem.DataClasses
{
    internal class Equipment(EquipmentType type, double dailyRate)
    {
        public EquipmentType Type => type;
        public double DailyRate => dailyRate;

        public override string ToString() => $"{Type} (${DailyRate}/day)";
    }
}
