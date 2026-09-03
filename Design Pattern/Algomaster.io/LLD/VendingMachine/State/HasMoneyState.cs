using VendingMachine.Entities;

namespace VendingMachine.State
{
    internal class HasMoneyState(VendingMachine machine) : VendingMachineState(machine)
    {
        public override void InsertCoin(Coin coin)
        {
            Console.WriteLine("Already received full amount.");
        }

        public override void SelectItem(string code)
        {
            Console.WriteLine("Item already selected.");
        }

        public override void Dispense()
        {
            machine.SetState(new DispensingState(machine));
            machine.DispenseItem();
        }

        public override void Refund()
        {
            machine.RefundBalance();
            machine.Reset();
            machine.SetState(new IdleState(machine));
        }
    }
}
