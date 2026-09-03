using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.States
{
    internal interface IOrderItemState
    {
        void Next(OrderItem item);
        void Prev(OrderItem item);
        string GetStatus();
    }
}
