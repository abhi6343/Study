using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.Commands
{
    internal class ServeOrderCommand(Order order, Waiter waiter) : ICommand
    {
        public void Execute()
        {
            waiter.ServeOrder(order);
        }
    }
}
