using CarRentalSystem.DataClasses;

namespace CarRentalSystem.Observers
{
    internal class EmailNotificationObserver : IRentalObserver
    {
        public void OnReservationCreated(Reservation reservation)
        {
            Console.WriteLine("[Email] Reservation confirmed: " + reservation.Id
                + " for " + reservation.Customer.Name
                + " - " + reservation.VehicleType
                + " (" + reservation.PickupDate.ToString("yyyy-MM-dd")
                + " to " + reservation.ReturnDate.ToString("yyyy-MM-dd") + ")");
        }

        public void OnVehiclePickedUp(Reservation reservation)
        {
            Console.WriteLine("[Email] Vehicle picked up: "
                + reservation.Customer.Name + " picked up "
                + reservation.AssignedVehicle.LicensePlate
                + " (" + reservation.VehicleType + ")");
        }

        public void OnVehicleReturned(Reservation reservation, Bill bill)
        {
            Console.WriteLine("[Email] Vehicle returned: "
                + reservation.Customer.Name + " returned "
                + reservation.AssignedVehicle.LicensePlate
                + $". Total: ${bill.TotalCost:F2}");
        }
    }
}
