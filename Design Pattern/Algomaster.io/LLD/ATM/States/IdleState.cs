using ATM.Enums;
using ATM.Singleton;

namespace ATM.States
{
    internal class IdleState : IATMMachineState
    {
        public void InsertCard(ATMMachine atmMachine, string cardNumber)
        {
            Console.WriteLine("\nCard has been inserted.");
            var card = atmMachine.BankService.IsCardPresentInCardsDict(cardNumber);

            if (card == null)
            {
                EjectCard(atmMachine);
            }
            else
            {
                atmMachine.CurrentCard = card;
                atmMachine.CurrentState = new HasCardState();
            }
        }

        public void EnterPin(ATMMachine atm, string pin)
        {
            Console.WriteLine("Error: Please insert a card first.");
        }

        public void SelectOperation(ATMMachine atm, OperationType op, int amount = 0)
        {
            Console.WriteLine("Error: Please insert a card first.");
        }

        public void EjectCard(ATMMachine atmMachine)
        {
            Console.WriteLine("Error: Card not found.");
            atmMachine.CurrentCard = null;
        }
    }
}
