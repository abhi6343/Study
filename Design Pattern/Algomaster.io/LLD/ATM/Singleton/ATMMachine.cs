using ATM.ChainOfResponsibility;
using ATM.Entities;
using ATM.Enums;
using ATM.Services;
using ATM.States;

namespace ATM.Singleton
{
    internal class ATMMachine
    {
        static ATMMachine? instance;
        static readonly Lock lockObject = new();
        readonly CashDispenser cashDispenser;

        private ATMMachine()
        {
            // Setup the dispenser chain
            var c1 = new NoteDispenser100(10); // 10 x $100 notes
            var c2 = new NoteDispenser50(20);  // 20 x $50 notes
            var c3 = new NoteDispenser20(30);  // 30 x $20 notes
            c1.NextChain = c2;
            c2.NextChain = c3;
            cashDispenser = new(c1);
        }

        public static ATMMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new ATMMachine();
                    }
                }
                return instance;
            }
        }

        public void InsertCard(string cardNumber) => CurrentState.InsertCard(this, cardNumber);

        public void EnterPin(string pin) => CurrentState.EnterPin(this, pin);

        public void SelectOperation(OperationType op, int amount = 0) => CurrentState.SelectOperation(this, op, amount);

        public void CheckBalance() => Console.WriteLine($"Your current account balance is: ${BankService.GetBalance(CurrentCard):F2}");

        public void WithdrawCash(int amount)
        {
            if (!cashDispenser.CanDispenseCash(amount))
            {
                throw new InvalidOperationException("Insufficient cash available in the ATM.");
            }

            BankService.WithdrawMoney(CurrentCard, amount);

            try
            {
                cashDispenser.DispenseCash(amount);
            }
            catch (Exception)
            {
                BankService.DepositMoney(CurrentCard, amount); // Deposit back if dispensing fails
                throw;
            }
        }

        public void DepositCash(int amount) => BankService.DepositMoney(CurrentCard, amount);

        public Card? CurrentCard { get; set; }
        public BankService BankService { get; } = new();
        public IATMMachineState CurrentState { get; set; } = new IdleState();
    }
}
