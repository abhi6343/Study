using Microsoft.EntityFrameworkCore;

namespace EntityConfigurationFluentAPI.Entities
{
    [Owned]
    internal class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
}
