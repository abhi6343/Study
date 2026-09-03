namespace CarRentalSystem.Enums
{
    internal enum VehicleStatus
    {
        AVAILABLE,          // Ready to rent
        RESERVED,           // Assigned to an upcoming reservation
        RENTED,             // Currently with a customer
        UNDER_MAINTENANCE   // Being serviced
    }
}
