using System.ComponentModel.DataAnnotations;

namespace ConcurrencyCheckAttributeDemo.Entities
{
    internal class Student
    {
        public int StudentId { get; set; }
        [ConcurrencyCheck]
        public int RegdNumber { get; set; }
        [ConcurrencyCheck]
        public string? Name { get; set; }
        public string? Branch { get; set; }
    }
}
