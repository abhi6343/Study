using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.Decorators
{
    internal class BaseBill(Order order) : IBillComponent
    {
        public double CalculateTotal() => order.GetTotalPrice();
        public string GetDescription() => "Order Items";
    }
}
