using ATM.Enums;
using ATM.Singleton;

namespace ATM.States
{
    internal class HasCardState : IATMMachineState
    {
        public void InsertCard(ATMMachine atm, string cardNumber)
        {
            Console.WriteLine("Error: A card is already inserted. Cannot insert another card.");
        }

        public void EnterPin(ATMMachine atmMachine, string pin)
        {
            Console.WriteLine("Authenticating PIN...");

            if (Services.BankService.AuthenticateCard(atmMachine.CurrentCard, pin))
            {
                Console.WriteLine("Authentication successful.");
                atmMachine.CurrentState = new AuthenticatedState();
            }
            else
            {
                Console.WriteLine("Authentication failed: Incorrect PIN.");
                EjectCard(atmMachine);
            }
        }

        public void SelectOperation(ATMMachine atm, OperationType op, int amount = 0)
        {
            Console.WriteLine("Error: Please enter your PIN first to select an operation.");
        }

        public void EjectCard(ATMMachine atmMachine)
        {
            Console.WriteLine("Card has been ejected. Thank you for using our ATM.");
            atmMachine.CurrentCard = null;
            atmMachine.CurrentState = new IdleState();
        }
    }
}
