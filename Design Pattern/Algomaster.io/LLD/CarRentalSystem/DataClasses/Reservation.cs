using CarRentalSystem.Enums;
using CarRentalSystem.Exceptions;

namespace CarRentalSystem.DataClasses
{
    internal class Reservation(string id, Customer customer, VehicleType vehicleType, string pickupLocationId, 
                    string returnLocationId, DateTime pickupDate, DateTime returnDate, List<Equipment> equipments)
    {
        public string Id => id;
        public Customer Customer => customer;
        public VehicleType VehicleType => vehicleType;
        public string PickupLocationId => pickupLocationId;
        public string ReturnLocationId => returnLocationId;
        public DateTime PickupDate => pickupDate;
        public DateTime ReturnDate => returnDate;
        public IReadOnlyList<Equipment> Equipment => equipments.AsReadOnly();
        public Vehicle AssignedVehicle { get; private set; }
        public ReservationStatus Status { get; private set; } = ReservationStatus.CONFIRMED;
        public double TotalCost { get; private set; } = 0;

        public void AssignVehicle(Vehicle vehicle)
        {
            AssignedVehicle = vehicle;
        }

        public void Activate()
        {
            if (Status != ReservationStatus.CONFIRMED)
            {
                throw new CarRentalException("Can only activate CONFIRMED reservations. Current: " + Status);
            }
            Status = ReservationStatus.ACTIVE;
        }

        public void Complete(double totalCost)
        {
            if (Status != ReservationStatus.ACTIVE)
            {
                throw new CarRentalException("Can only complete ACTIVE reservations. Current: " + Status);
            }
            Status = ReservationStatus.COMPLETED;
            TotalCost = totalCost;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.CONFIRMED)
            {
                throw new CarRentalException("Can only cancel CONFIRMED reservations. Current: " + Status);
            }
            Status = ReservationStatus.CANCELLED;
        }

        public override string ToString() => $"Reservation{{id={Id}, customer={Customer.Name}, type={VehicleType}, status={Status}}}";
    }
}
