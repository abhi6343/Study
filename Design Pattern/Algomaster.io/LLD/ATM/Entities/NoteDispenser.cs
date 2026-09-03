using ATM.ChainOfResponsibility;

namespace ATM.Entities
{
    internal abstract class NoteDispenser(int noteValue, int numNotes) : IDispenseChain
    {
        public IDispenseChain? NextChain { get; set; }
        private readonly Lock dispenserLock = new();

        public void Dispense(int amount)
        {
            lock (dispenserLock)
            {
                if (amount >= noteValue)
                {
                    int numToDispense = Math.Min(amount / noteValue, numNotes);
                    int remainingAmount = amount - (numToDispense * noteValue);

                    if (numToDispense > 0)
                    {
                        Console.WriteLine($"Dispensing {numToDispense} x ${noteValue} note(s)");
                        numNotes -= numToDispense;
                    }

                    if (remainingAmount > 0 && NextChain != null)
                    {
                        NextChain.Dispense(remainingAmount);
                    }
                }
                else
                {
                    NextChain?.Dispense(amount);
                }
            }
        }

        public bool CanDispense(int amount)
        {
            lock (dispenserLock)
            {
                if (amount < 0) return false;
                if (amount == 0) return true;

                int numToUse = Math.Min(amount / noteValue, numNotes);
                int remainingAmount = amount - (numToUse * noteValue);

                if (remainingAmount == 0) return true;
                if (NextChain != null)
                {
                    return NextChain.CanDispense(remainingAmount);
                }
                return false;
            }
        }
    }
}
