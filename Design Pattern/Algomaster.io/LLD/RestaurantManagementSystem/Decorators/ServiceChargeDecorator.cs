namespace RestaurantManagementSystem.Decorators
{
    internal class ServiceChargeDecorator(IBillComponent component, double charge) : BillDecorator(component)
    {
        public override double CalculateTotal()
        {
            return base.CalculateTotal() + charge;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Service Charge";
        }
    }
}
