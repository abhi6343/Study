using RestaurantManagementSystem.States;

namespace RestaurantManagementSystem.Entities
{
    internal class Chef(string id, string name) : Staff(id, name)
    {
        public void PrepareOrder(Order order)
        {
            Console.WriteLine($"Chef {name} received order {order.OrderId} and is starting preparation.");
            foreach (var item in order.OrderItems)
            {
                item.ChangeState(new PreparingState());
            }
        }
    }
}
