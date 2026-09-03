namespace CarRentalSystem.DataClasses
{
    internal class Bill(Reservation reservation, double baseCost, double equipmentCost, double lateFee)
    {
        public Reservation Reservation => reservation;
        public double BaseCost => baseCost;
        public double EquipmentCost => equipmentCost;
        public double LateFee => lateFee;
        public double TotalCost => baseCost + equipmentCost + lateFee;

        public override string ToString() => $"Bill{{base=${BaseCost:F2}, equipment=${EquipmentCost:F2}, lateFee=${LateFee:F2}, total=${TotalCost:F2}}}";
    }
}
