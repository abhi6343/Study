namespace RestaurantManagementSystem.Entities
{
    internal class Menu
    {
        readonly Dictionary<string, MenuItem> items = [];

        public void AddItem(MenuItem item)
        {
            items[item.Id] = item;
        }

        public MenuItem GetItem(string id)
        {
            if (!items.TryGetValue(id, out var item))
            {
                throw new ArgumentException($"Menu item with ID {id} not found.");
            }
            return item;
        }
    }
}
