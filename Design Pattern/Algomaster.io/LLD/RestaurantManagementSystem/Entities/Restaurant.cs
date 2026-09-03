namespace RestaurantManagementSystem.Entities
{
    internal class Restaurant
    {
        static Restaurant instance;
        static readonly Lock lockObject = new();
        readonly Dictionary<string, Waiter> waiters = [];
        readonly Dictionary<string, Chef> chefs = [];
        readonly Dictionary<int, Table> tables = [];
        readonly Menu menu = new();

        private Restaurant() { }

        public static Restaurant GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    instance ??= new Restaurant();
                }
            }
            return instance;
        }

        public void AddWaiter(Waiter waiter) => waiters[waiter.Id] = waiter;
        public Waiter GetWaiter(string id) => waiters.TryGetValue(id, out Waiter waiter) ? waiter : default;

        public void AddChef(Chef chef) => chefs[chef.Id] = chef;
        public Chef GetChef(string id) => chefs.TryGetValue(id, out Chef chef) ? chef : default;

        public List<Chef> Chefs => [.. chefs.Values];
        public List<Waiter> Waiters => [.. waiters.Values];

        public void AddTable(Table table) => tables[table.Id] = table;
        public Menu Menu => menu;
    }
}
