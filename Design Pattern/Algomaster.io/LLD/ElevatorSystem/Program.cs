using ElevatorSystem.Enums;

int numElevators = 3;
int numFloors = 10;

var system = ElevatorSystem.ElevatorSystem.GetInstance(numElevators, numFloors);

Console.WriteLine("========== ELEVATOR SYSTEM STARTED ==========");
Console.WriteLine($"Building: {numFloors} floors, {numElevators} elevators\n");

// Scenario 1: Basic hall button requests
Console.WriteLine("--- Scenario 1: Hall Button Requests ---");
system.RequestElevator(3, Direction.Up);
system.RequestElevator(7, Direction.Down);
system.RequestElevator(5, Direction.Up);

Thread.Sleep(5000);

// Scenario 2: Internal cabin requests (passenger inside elevator 1 presses floor 8)
Console.WriteLine("\n--- Scenario 2: Cabin Button Requests ---");
var elevators = system.Elevators;
elevators[0].AddRequest(8, Direction.Up);
elevators[1].AddRequest(1, Direction.Down);

Thread.Sleep(5000);

// Scenario 3: Rush hour - multiple simultaneous requests
Console.WriteLine("\n--- Scenario 3: Rush Hour ---");
system.RequestElevator(1, Direction.Up);
system.RequestElevator(2, Direction.Up);
system.RequestElevator(9, Direction.Down);
system.RequestElevator(10, Direction.Down);

Thread.Sleep(5000);

// Shutdown
Console.WriteLine("\n========== SHUTTING DOWN ==========");
system.Shutdown();
Console.WriteLine("Elevator system stopped.");