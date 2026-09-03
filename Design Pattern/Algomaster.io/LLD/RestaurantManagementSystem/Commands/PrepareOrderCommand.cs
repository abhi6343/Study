using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.Commands
{
    internal class PrepareOrderCommand(Order order, Chef chef) : ICommand
    {
        public void Execute()
        {
            chef.PrepareOrder(order);
        }
    }
}
