using RestaurantManagementSystem.Observers;
using RestaurantManagementSystem.States;

namespace RestaurantManagementSystem.Entities
{
    internal class OrderItem(MenuItem menuItem, Order order)
    {
        IOrderItemState state = new OrderedState();
        readonly List<IOrderObserver> observers = [];

        public void ChangeState(IOrderItemState newState)
        {
            this.state = newState;
            Console.WriteLine($"Item '{menuItem.Name}' state changed to: {newState.GetStatus()}");
        }

        public void NextState()
        {
            state.Next(this);
        }

        public void SetState(IOrderItemState state)
        {
            this.state = state;
        }

        public void AddObserver(IOrderObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        public MenuItem MenuItem => menuItem;
        public Order Order => order;
    }
}
