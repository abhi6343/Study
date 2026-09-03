namespace EntityConfigurationFluentAPI.Entities
{
    internal class Customer
    {
        public int CustomerId { get; set; } // Primary Key
        public string Email { get; set; } // Alternate Key (Unique)        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; } // Owned Entity
        public ICollection<Order> Orders { get; set; }
    }
}
