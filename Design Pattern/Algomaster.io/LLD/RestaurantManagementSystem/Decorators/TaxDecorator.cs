namespace RestaurantManagementSystem.Decorators
{
    internal class TaxDecorator(IBillComponent component, double taxRate) : BillDecorator(component)
    {
        public override double CalculateTotal()
        {
            return base.CalculateTotal() * (1 + taxRate);
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", Tax @{taxRate * 100}%";
        }
    }
}
