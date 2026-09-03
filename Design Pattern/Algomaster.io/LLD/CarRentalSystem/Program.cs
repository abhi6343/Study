using CarRentalSystem.DataClasses;
using CarRentalSystem.Enums;
using CarRentalSystem.Observers;
using CarRentalSystem.Strategies;

var system = CarRentalSystem.SingletonAndFacade.CarRentalSystem.Instance;

// Register observers
system.AddObserver(new EmailNotificationObserver());
system.AddObserver(new InvoiceObserver());

// Add locations
var jfk = new Location("L1", "JFK Airport", "JFK Airport, NY");
var downtown = new Location("L2", "Downtown Manhattan", "123 Main St, NY");
system.AddLocation(jfk);
system.AddLocation(downtown);

// Add vehicles
system.AddVehicle(new Vehicle("V1", "ABC-1234", VehicleType.ECONOMY, 40.0, "L1"));
system.AddVehicle(new Vehicle("V2", "DEF-5678", VehicleType.ECONOMY, 40.0, "L1"));
system.AddVehicle(new Vehicle("V3", "GHI-9012", VehicleType.SUV, 75.0, "L1"));
system.AddVehicle(new Vehicle("V4", "JKL-3456", VehicleType.LUXURY, 150.0, "L2"));

// Create customers
var alice = new Customer("C1", "Alice", "alice@email.com", "DL-001");
var bob = new Customer("C2", "Bob", "bob@email.com", "DL-002");

// Equipment options
var gps = new Equipment(EquipmentType.GPS, 10.0);
var childSeat = new Equipment(EquipmentType.CHILD_SEAT, 8.0);

// === Scenario 1: Standard reservation and pickup ===
Console.WriteLine("========== SCENARIO 1: Reserve + Pickup (Standard Pricing) ==========");
system.SetPricingStrategy(new StandardPricingStrategy());
var res1 = system.MakeReservation(alice, VehicleType.ECONOMY, "L1", "L1", new DateTime(2025, 3, 10), new DateTime(2025, 3, 13), [gps]);
Console.WriteLine("Reserved: " + res1);

var pickup1 = system.PickupVehicle(res1.Id);
Console.WriteLine("Picked up: " + pickup1);

// === Scenario 2: Return vehicle on time ===
Console.WriteLine("\n========== SCENARIO 2: Return On Time ==========");
var bill1 = system.ReturnVehicle(res1.Id, "L1", new DateTime(2025, 3, 13));
Console.WriteLine("Bill: " + bill1);

// === Scenario 3: Weekend pricing ===
Console.WriteLine("\n========== SCENARIO 3: Reserve with Weekend Pricing ==========");
system.SetPricingStrategy(new WeekendPricingStrategy(1.5));
var res2 = system.MakeReservation(bob, VehicleType.SUV, "L1", "L2", new DateTime(2025, 3, 15), new DateTime(2025, 3, 17), [gps, childSeat]);
Console.WriteLine("Reserved: " + res2);

var pickup2 = system.PickupVehicle(res2.Id);
Console.WriteLine("Picked up: " + pickup2);

// === Scenario 4: Late return ===
Console.WriteLine("\n========== SCENARIO 4: Late Return (1 day late) ==========");
var bill2 = system.ReturnVehicle(res2.Id, "L2", new DateTime(2025, 3, 18));
Console.WriteLine("Bill: " + bill2);

// === Scenario 5: Cancel a reservation ===
Console.WriteLine("\n========== SCENARIO 5: Cancel Reservation ==========");
var res3 = system.MakeReservation(alice, VehicleType.LUXURY, "L2", "L2", new DateTime(2025, 4, 1), new DateTime(2025, 4, 5), [gps]);
Console.WriteLine("Reserved: " + res3);
system.CancelReservation(res3.Id);
Console.WriteLine("Cancelled. Status: " + res3.Status);