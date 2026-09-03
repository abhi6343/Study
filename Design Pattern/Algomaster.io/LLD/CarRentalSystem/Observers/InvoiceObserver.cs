using CarRentalSystem.DataClasses;

namespace CarRentalSystem.Observers
{
    internal class InvoiceObserver : IRentalObserver
    {
        public void OnReservationCreated(Reservation reservation)
        {
            // No invoice needed at reservation time
        }

        public void OnVehiclePickedUp(Reservation reservation)
        {
            // No invoice needed at pickup time
        }

        public void OnVehicleReturned(Reservation reservation, Bill bill)
        {
            Console.WriteLine("[Invoice] Invoice generated for " + reservation.Id
                + $": Base=${bill.BaseCost:F2}"
                + $", Equipment=${bill.EquipmentCost:F2}"
                + $", Late Fee=${bill.LateFee:F2}"
                + $", Total=${bill.TotalCost:F2}");
        }
    }
}
