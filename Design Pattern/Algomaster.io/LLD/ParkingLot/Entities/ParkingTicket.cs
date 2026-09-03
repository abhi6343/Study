using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;

namespace ParkingLot.Entities
{
    internal class ParkingTicket(ParkingSpot parkingSpot, Vehicle vehicle)
    {
        readonly string ticketId = Guid.NewGuid().ToString();
        readonly long entryTimeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public long ParkingDuration => DateTimeOffset.Now.ToUnixTimeMilliseconds() - entryTimeStamp;
        public Vehicle Vehicle => vehicle;
        public string TicketId => ticketId;
        public ParkingSpot ParkingSpot => parkingSpot;
    }
}
