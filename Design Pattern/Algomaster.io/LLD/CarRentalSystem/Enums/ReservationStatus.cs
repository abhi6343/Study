namespace CarRentalSystem.Enums
{
    internal enum ReservationStatus
    {
        CONFIRMED,   // Reservation created and confirmed
        ACTIVE,      // Customer has picked up the vehicle
        COMPLETED,   // Vehicle returned, rental finished
        CANCELLED    // Customer cancelled before pickup
    }
}
