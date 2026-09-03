using System.ComponentModel.DataAnnotations.Schema;

namespace ForeignKeyAttributeDemo.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //// Navigation property
        //public Department Department { get; set; }
        //// Foreign key property
        //public int DepartmentId { get; set; }


        ////To Create a Foreign Key pointing to the Id column of the Departments table
        ////it should have the Department Navigation Property
        //public Department Department { get; set; }
        ////In this case, EF Core automatically create the DepartmentId Foreign Key in the Employees table
        

        //[ForeignKey("Department")]
        //public int DepartmentReferenceId { get; set; }
        ////Related Standard Navigational Property
        //public Department Department { get; set; }


        public int DepartmentReferenceId { get; set; }
        [ForeignKey("DepartmentReferenceId")]
        public Department Department { get; set; }
    }
}
