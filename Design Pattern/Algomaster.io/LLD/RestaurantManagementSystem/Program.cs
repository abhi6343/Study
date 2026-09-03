using RestaurantManagementSystem;
using RestaurantManagementSystem.Entities;

Console.WriteLine("=== Initializing Restaurant System ===");
var rmsFacade = RestaurantManagementSystemFacade.GetInstance();

var table1 = rmsFacade.AddTable(1, 4);
var chef1 = rmsFacade.AddChef("CHEF01", "Gordon");
var waiter1 = rmsFacade.AddWaiter("W01", "Alice");

MenuItem pizza = rmsFacade.AddMenuItem("PIZZA01", "Margherita Pizza", 12.50);
MenuItem pasta = rmsFacade.AddMenuItem("PASTA01", "Carbonara Pasta", 15.00);
MenuItem coke = rmsFacade.AddMenuItem("DRINK01", "Coke", 2.50);
Console.WriteLine("Initialization Complete.\n");

Console.WriteLine("=== SCENARIO 1: Taking an order ===");
var order1 = rmsFacade.TakeOrder(table1.Id, waiter1.Id, [pizza.Id, coke.Id]);
Console.WriteLine($"Order taken successfully. Order ID: {order1.OrderId}");

Console.WriteLine("\n=== SCENARIO 2: Chef prepares, Waiter gets notified ===");
rmsFacade.MarkItemsAsReady(order1.OrderId);
rmsFacade.ServeOrder(waiter1.Id, order1.OrderId);

Console.WriteLine("\n=== SCENARIO 3: Generating the bill ===");
var finalBill = rmsFacade.GenerateBill(order1.OrderId);
finalBill.PrintBill();