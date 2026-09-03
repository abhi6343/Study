namespace RestaurantManagementSystem.Decorators
{
    internal class Bill(IBillComponent component)
    {
        public void PrintBill()
        {
            Console.WriteLine("\n--- BILL ---");
            Console.WriteLine($"Description: {component.GetDescription()}");
            Console.WriteLine($"Total: ${component.CalculateTotal():F2}");
            Console.WriteLine("------------");
        }
    }
}
