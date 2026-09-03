using ATM.Enums;
using ATM.Singleton;

namespace ATM.States
{
    internal class AuthenticatedState : IATMMachineState
    {
        public void InsertCard(ATMMachine atm, string cardNumber)
        {
            Console.WriteLine("Error: A card is already inserted and a session is active.");
        }

        public void EnterPin(ATMMachine atm, string pin)
        {
            Console.WriteLine("Error: PIN has already been entered and authenticated.");
        }

        public void SelectOperation(ATMMachine atmMachine, OperationType op, int amount = 0)
        {
            switch (op)
            {
                case OperationType.CHECK_BALANCE:
                    atmMachine.CheckBalance();
                    break;

                case OperationType.WITHDRAW_CASH:
                    if (amount <= 0)
                    {
                        Console.WriteLine("Error: Invalid withdrawal amount specified.");
                        break;
                    }

                    if (amount > atmMachine.BankService.GetBalance(atmMachine.CurrentCard))
                    {
                        Console.WriteLine("Error: Insufficient balance.");
                        break;
                    }

                    Console.WriteLine($"Processing withdrawal for ${amount}");
                    atmMachine.WithdrawCash(amount);
                    break;

                case OperationType.DEPOSIT_CASH:
                    if (amount <= 0)
                    {
                        Console.WriteLine("Error: Invalid deposit amount specified.");
                        break;
                    }
                    Console.WriteLine($"Processing deposit for ${amount}");
                    atmMachine.DepositCash(amount);
                    break;

                default:
                    Console.WriteLine("Error: Invalid operation selected.");
                    break;
            }

            // End the session after one transaction
            Console.WriteLine("Transaction complete.");
            EjectCard(atmMachine);
        }

        public void EjectCard(ATMMachine atmMachine)
        {
            Console.WriteLine("Ending session. Card has been ejected. Thank you for using our ATM.");
            atmMachine.CurrentCard = null;
            atmMachine.CurrentState = new IdleState();
        }
    }
}
