using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.Observers
{
    internal interface IOrderObserver
    {
        void Update(OrderItem item);
    }
}
