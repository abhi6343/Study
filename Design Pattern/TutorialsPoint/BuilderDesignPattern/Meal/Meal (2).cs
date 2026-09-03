namespace BuilderDesignPattern
{
    public class Meal
    {
        private List<IItem> items = new List<IItem>();
        public void addItem(IItem item)
        {
            items.Add(item);
        }
        public float getCost()
        {
            float cost = 0.0f;
            foreach(IItem item in items)
            {
                cost += item.price();
            }
            return cost;
        }
        public void showItems()
        {
            foreach (IItem item in items)
            {
                Console.Write("Item : "+item.name());
                Console.Write(", Packing : "+item.packing().pack());
                Console.WriteLine(", Price : "+item.price());
            }
        }
    }
}
