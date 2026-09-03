using VendingMachine.Entities;

namespace VendingMachine.State
{
    internal abstract class VendingMachineState(VendingMachine machine)
    {
        protected VendingMachine machine = machine;

        public abstract void InsertCoin(Coin coin);
        public abstract void SelectItem(string code);
        public abstract void Dispense();
        public abstract void Refund();
    }
}
