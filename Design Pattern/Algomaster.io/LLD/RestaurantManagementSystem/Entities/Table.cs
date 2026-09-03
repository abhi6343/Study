using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem.Entities
{
    internal class Table(int id, int capacity)
    {
        public int Id => id;
        public int Capacity => capacity;
        public TableStatus Status { get; set; } = TableStatus.AVAILABLE;
    }
}
