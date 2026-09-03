using RestaurantManagementSystem.Observers;
using RestaurantManagementSystem.States;

namespace RestaurantManagementSystem.Entities
{
    internal class Waiter(string id, string name) : Staff(id, name), IOrderObserver
    {
        public void ServeOrder(Order order)
        {
            Console.WriteLine($"Waiter {name} is serving order {order.OrderId}");
            foreach (var item in order.OrderItems)
            {
                item.ChangeState(new ServedState());
            }
        }

        public void Update(OrderItem item)
        {
            Console.WriteLine($">>> WAITER {name} NOTIFIED: Item '{item.MenuItem.Name}' " +
                             $"for table {item.Order.TableId} is READY FOR PICKUP.");
        }
    
    }
}
