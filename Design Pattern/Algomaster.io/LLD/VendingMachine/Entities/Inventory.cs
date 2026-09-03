namespace VendingMachine.Entities
{
    internal class Inventory
    {
        private readonly Dictionary<string, Item> itemMap = [];
        private readonly Dictionary<string, int> stockMap = [];

        public void AddItem(string code, Item item, int quantity)
        {
            itemMap[code] = item;
            stockMap[code] = quantity;
        }

        public Item GetItem(string code)
        {
            return itemMap.GetValueOrDefault(code);
        }

        public bool IsAvailable(string code)
        {
            return stockMap.GetValueOrDefault(code, 0) > 0;
        }

        public void ReduceStock(string code)
        {
            if (stockMap.TryGetValue(code, out int value))
            {
                stockMap[code] = value - 1;
            }
        }
    }
}
