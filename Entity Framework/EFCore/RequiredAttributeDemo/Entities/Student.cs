using System.ComponentModel.DataAnnotations;

namespace RequiredAttributeDemo.Entities
{
    internal class Student
    {
        public int StudentId { get; set; }  // This will create a NOT NULL column
        //public string? Name { get; set; }   // This will create a NULL column


        //[Required]
        // Allows empty strings, but disallows NULL. It will still accept sempty string in database
        //[Required(AllowEmptyStrings = false)]
        //public string? Name { get; set; }   // Name is now NOT NULL due to Required Attribute



        //[MaxLength(50)]
        [MaxLength(10)]
        [MinLength(5)]
        public string? FirstName { get; set; }
        [MinLength(5)]
        public string? LastName { get; set; }



        public string? Address { get; set; } // This will create a NULL column
        public int RollNumber { get; set; }  // This will create a NOT NULL column

        public byte[]? Photo { get; set; }
    }
}
