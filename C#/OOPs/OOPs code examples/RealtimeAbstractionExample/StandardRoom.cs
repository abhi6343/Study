namespace RealtimeAbstractionExample
{
    //Concrete Implementations
    //Implement the interface for each room type
    internal class StandardRoom : IRoom
    {
        public decimal Rate => 100.00M;
        public int Capacity => 2;
        public string Description => "Standard Room with basic amenities.";
        public void DisplayRoomDetails()
        {
            Console.WriteLine($"Type: Standard Room | Rate: {Rate:C} | Capacity: {Capacity} | Description: {Description}");
        }
    }
}
