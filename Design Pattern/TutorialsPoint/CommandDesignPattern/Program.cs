// See https://aka.ms/new-console-template for more information
using CommandDesignPattern;

Stock_Request abcStock = new Stock_Request();   // Request
BuyStock_Command buyStockOrder = new BuyStock_Command(abcStock);    // Buy Command
SellStock_Command sellStockOrder = new SellStock_Command(abcStock); // Sell Command
Broker_CommandInvoker broker = new Broker_CommandInvoker();   // Command Invoker
broker.takeOrder(buyStockOrder);
broker.takeOrder(sellStockOrder);
broker.placeOrders();   // Execute command object based on type of command