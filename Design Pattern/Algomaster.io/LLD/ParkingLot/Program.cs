// See https://aka.ms/new-console-template for more information
using ParkingLot.Entities.Parking;
using ParkingLot.Entities.Vechicle;
using ParkingLot.Enums;
using ParkingLot.Strategy.FeeStrategy;

var parkingLot = ParkingLot.Singleton.ParkingLot.GetInstance();

// 1. Initialize the parking lot with floors and spots
var floor1 = new ParkingFloor(1);
floor1.AddSpot(new("F1-S1", VehicleSize.SMALL));
floor1.AddSpot(new("F1-M1", VehicleSize.MEDIUM));
floor1.AddSpot(new("F1-L1", VehicleSize.LARGE));

var floor2 = new ParkingFloor(2);
floor2.AddSpot(new("F2-M1", VehicleSize.MEDIUM));
floor2.AddSpot(new("F2-M2", VehicleSize.MEDIUM));

parkingLot.AddFloor(floor1);
parkingLot.AddFloor(floor2);

parkingLot.SetFeeStrategy(new VehicleBasedFeeStrategy());

// 2. Simulate vehicle entries
Console.WriteLine("\n--- Vehicle Entries ---");
floor1.DisplayAvailability();
floor2.DisplayAvailability();

var bike = new Vehicle("B-123", VehicleSize.SMALL);
var car = new Vehicle("C-456", VehicleSize.MEDIUM);
var truck = new Vehicle("T-789", VehicleSize.LARGE);

var bikeTicket = parkingLot.ParkVehicle(bike);
var carTicket = parkingLot.ParkVehicle(car);
var truckTicket = parkingLot.ParkVehicle(truck);

Console.WriteLine("\n--- Availability after parking ---");
floor1.DisplayAvailability();
floor2.DisplayAvailability();

// 3. Simulate another car entry (should go to floor 2)
var car2 = new Vehicle("C-999", VehicleSize.MEDIUM);
var car2Ticket = parkingLot.ParkVehicle(car2);

// 4. Simulate a vehicle entry that fails (no available spots)
var bike2 = new Vehicle("B-000", VehicleSize.SMALL);
var failedBikeTicket = parkingLot.ParkVehicle(bike2);

// 5. Simulate vehicle exits and fee calculation
Console.WriteLine("\n--- Vehicle Exits ---");

if (carTicket != null)
{
    var fee = parkingLot.UnparkVehicle(car.LicenseNumber);
    if (fee.HasValue)
    {
        Console.WriteLine($"Car C-456 unparked. Fee: ${fee.Value:F2}");
    }
}

Console.WriteLine("\n--- Availability after one car leaves ---");
floor1.DisplayAvailability();
floor2.DisplayAvailability();
