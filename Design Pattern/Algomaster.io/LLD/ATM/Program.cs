using ATM.Enums;
using ATM.Singleton;

var atmMachine = ATMMachine.Instance;

// Perform Check Balance operation
atmMachine.InsertCard("1234-5678-9012-3456");
atmMachine.EnterPin("1234");
atmMachine.SelectOperation(OperationType.CHECK_BALANCE); // $1000

// Perform Withdraw Cash operation
atmMachine.InsertCard("1234-5678-9012-3456");
atmMachine.EnterPin("1234");
atmMachine.SelectOperation(OperationType.WITHDRAW_CASH, 570);

// Perform Deposit Cash operation
atmMachine.InsertCard("1234-5678-9012-3456");
atmMachine.EnterPin("1234");
atmMachine.SelectOperation(OperationType.DEPOSIT_CASH, 200);

// Perform Check Balance operation
atmMachine.InsertCard("1234-5678-9012-3456");
atmMachine.EnterPin("1234");
atmMachine.SelectOperation(OperationType.CHECK_BALANCE); // $630

// Perform Withdraw Cash more than balance
atmMachine.InsertCard("1234-5678-9012-3456");
atmMachine.EnterPin("1234");
atmMachine.SelectOperation(OperationType.WITHDRAW_CASH, 700); // Insufficient balance

// Insert Incorrect PIN
atmMachine.InsertCard("1234-5678-9012-3456");
atmMachine.EnterPin("3425");
