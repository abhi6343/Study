using System.ComponentModel.DataAnnotations.Schema;

namespace NotMappedAttributeDemo.Entities
{
    [NotMapped]
    internal class DepartmentExpenseReport
    {
        public string DepartmentName { get; set; }
        public decimal TotalExpenses { get; set; }
        public int NumberOfTransactions { get; set; }
    }
}
