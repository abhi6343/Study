namespace RestaurantManagementSystem.Decorators
{
    internal abstract class BillDecorator(IBillComponent component) : IBillComponent
    {
        protected IBillComponent wrapped = component;

        public virtual double CalculateTotal()
        {
            return wrapped.CalculateTotal();
        }

        public virtual string GetDescription()
        {
            return wrapped.GetDescription();
        }
    }
}
