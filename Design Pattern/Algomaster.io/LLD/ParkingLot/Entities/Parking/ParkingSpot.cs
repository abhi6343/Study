using ParkingLot.Entities.Vechicle;
using ParkingLot.Enums;

namespace ParkingLot.Entities.Parking
{
    internal class ParkingSpot(string spotId, VehicleSize size)
    {       
        bool isOccupied = false;
        Vehicle? parkedVehicle = null;
        readonly Lock lockObj = new();

        public void ParkVehicle(Vehicle vehicle)
        {
            lock (lockObj)
            {                
                this.parkedVehicle = vehicle;
                this.isOccupied = true;
            }
        }
        public void UnparkVehicle()
        {
            lock (lockObj)
            {                
                this.parkedVehicle = null;
                this.isOccupied = false;
            }
        }
        public bool IsOccupied { get { return isOccupied; } }
        public VehicleSize Size { get { return size; } }
        public string SpotId { get { return spotId; } }
    }
}
