using ATM.ChainOfResponsibility;

namespace ATM.Entities
{
    internal class CashDispenser(IDispenseChain chain)
    {
        readonly Lock dispenserLock = new();

        public void DispenseCash(int amount)
        {
            lock (dispenserLock)
            {
                chain.Dispense(amount);
            }
        }

        public bool CanDispenseCash(int amount)
        {
            lock (dispenserLock)
            {
                if (amount % 10 != 0)
                {
                    return false;
                }
                return chain.CanDispense(amount);
            }
        }
    }
}
