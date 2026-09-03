using CarRentalSystem.DataClasses;

namespace CarRentalSystem.Observers
{
    internal interface IRentalObserver
    {
        void OnReservationCreated(Reservation reservation);
        void OnVehiclePickedUp(Reservation reservation);
        void OnVehicleReturned(Reservation reservation, Bill bill);
    }
}
