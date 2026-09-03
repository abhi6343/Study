using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndexAttributeDemo.Entities
{
    [Table("StudentIndexDB", Schema = "Admin")]
    //[Index(nameof(RegistrationNumber))] // Index on the RegistrationNumber column
    //[Index(nameof(RegistrationNumber), Name = "Index_RegistrationNumber")]
    //[Index(nameof(RegistrationNumber), nameof(RollNumber), Name = "Index_RegistrationNumber_RollNumber")]
    //[Index(nameof(RegistrationNumber), Name = "Index_RegistrationNumber", IsUnique = true)]
    //[Index(nameof(RegistrationNumber), nameof(RollNumber), AllDescending = true, Name = "Index_RegistrationNumber_RollNumber")]
    //[Index(nameof(RegistrationNumber), nameof(RollNumber), IsDescending = new[] { false, true }, Name = "Index_RegistrationNumber_RollNumber")]


    [Index(nameof(FirstName), nameof(LastName), Name = "Index_FirstName_LastName")]
    [Index(nameof(RegistrationNumber), nameof(RollNumber), Name = "Index_RegistrationNumber_RollNumber")]
    internal class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RegistrationNumber { get; set; }
        public int RollNumber { get; set; }
    }
}
