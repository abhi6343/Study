using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableAttributeDemo
{
    //[Table("StudentInfo")]  // Mapping the entity to StudentInfo table in dbo schema
    //[Table("StudentInfo", Schema = "Admin")]  // Mapping the entity to the StudentInfo table in Admin schema
    //[PrimaryKey(nameof(RegdNo), nameof(SerialNo))]
    public class Student
    {
        //Primary Key: Order Must be 0
        //[Column(Order = 0)]
        //public int StudentId { get; set; }
        //[Key]
        //public int StudentRegdNo { get; set; }
        //public int RegdNo { get; set; }
        //public int SerialNo { get; set; }
        //public string StudentId { get; set; }
        //public string RegdNo { get; set; }
        //public string SerialNo { get; set; }
        [Key]
        public Guid StudentId { get; set; }
        // Default column name will be FirstName
        [Column(Order = 2)]
        public string? FirstName { get; set; }
        // Column name will be LName in the database
        [Column("LName", Order = 4)]
        public string? LastName { get; set; }
        //This ensures that the DateOfBirth property is stored as DateTime2 in SQL Server
        [Column("DOB", Order = 3, TypeName = "DateTime2")]
        public DateTime DateOfBirth { get; set; }
        [Column(Order = 1)]
        public string? Mobile { get; set; }
    }
}
