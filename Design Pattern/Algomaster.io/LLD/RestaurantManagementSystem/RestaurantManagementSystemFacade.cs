using RestaurantManagementSystem.Commands;
using RestaurantManagementSystem.Decorators;
using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem
{
    internal class RestaurantManagementSystemFacade
    {
        private static RestaurantManagementSystemFacade instance;
        private static readonly Lock lockObject = new();
        private readonly Restaurant restaurant = Restaurant.GetInstance();
        private int orderIdCounter = 1;
        private readonly Dictionary<int, Order> orders = [];

        private RestaurantManagementSystemFacade() { }

        public static RestaurantManagementSystemFacade GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    instance ??= new RestaurantManagementSystemFacade();
                }
            }
            return instance;
        }

        public Table AddTable(int id, int capacity)
        {
            var table = new Table(id, capacity);
            restaurant.AddTable(table);
            return table;
        }

        public Waiter AddWaiter(string id, string name)
        {
            var waiter = new Waiter(id, name);
            restaurant.AddWaiter(waiter);
            return waiter;
        }

        public Chef AddChef(string id, string name)
        {
            var chef = new Chef(id, name);
            restaurant.AddChef(chef);
            return chef;
        }

        public MenuItem AddMenuItem(string id, string name, double price)
        {
            var item = new MenuItem(id, name, price);
            restaurant.Menu.AddItem(item);
            return item;
        }

        public Order TakeOrder(int tableId, string waiterId, List<string> menuItemIds)
        {
            var waiter = restaurant.GetWaiter(waiterId) ?? throw new ArgumentException("Invalid waiter ID.");
            var chefs = restaurant.Chefs;
            if (chefs.Count == 0)
            {
                throw new InvalidOperationException("No chefs available.");
            }
            var chef = chefs.First();

            var order = new Order(Interlocked.Increment(ref orderIdCounter) - 1, tableId);
            foreach (var itemId in menuItemIds)
            {
                var menuItem = restaurant.Menu.GetItem(itemId);
                var orderItem = new OrderItem(menuItem, order);
                orderItem.AddObserver(waiter);
                order.AddItem(orderItem);
            }

            ICommand prepareOrderCommand = new PrepareOrderCommand(order, chef);
            prepareOrderCommand.Execute();

            orders[order.OrderId] = order;
            return order;
        }

        public void MarkItemsAsReady(int orderId)
        {
            var order = orders[orderId];
            Console.WriteLine($"\nChef has finished preparing order {order.OrderId}");

            foreach (var item in order.OrderItems)
            {
                item.NextState();
                item.NextState();
            }
        }

        public void ServeOrder(string waiterId, int orderId)
        {
            var order = orders[orderId];
            var waiter = restaurant.GetWaiter(waiterId);

            ICommand serveOrderCommand = new ServeOrderCommand(order, waiter);
            serveOrderCommand.Execute();
        }

        public Bill GenerateBill(int orderId)
        {
            var order = orders[orderId];
            IBillComponent billComponent = new BaseBill(order);
            billComponent = new TaxDecorator(billComponent, 0.08);
            billComponent = new ServiceChargeDecorator(billComponent, 5.00);

            return new(billComponent);
        }
    }
}
