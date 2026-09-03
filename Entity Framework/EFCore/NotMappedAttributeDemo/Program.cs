using Microsoft.EntityFrameworkCore;
using NotMappedAttributeDemo.Entities;

namespace NotMappedAttributeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using var context = new EFCoreDbContext();
            //// Fetch and display departments with their employees
            //var departments = context.Departments.Include(d => d.Employees).ToList();
            //Console.WriteLine("Departments and Employees:");
            //foreach (var department in departments)
            //{
            //    Console.WriteLine($"Department: {department.Name}");
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine($"\tEmployee: {employee.FullName}");
            //        Console.WriteLine($"\tTenure: {employee.Tenure} years and Date of Joining: {employee.DateOfJoining:yyyy-MM-dd}");
            //        Console.WriteLine($"\tAge: {employee.Age} years and Date of Birth: {employee.DateOfBirth:yyyy-MM-dd}");
            //        Console.WriteLine(); //Line Break
            //    }
            //}



            using var context = new EFCoreDbContext();
            // Ensure the database is created and seed data is loaded
            context.Database.EnsureCreated();
            // Generate the report
            var report = GenerateDepartmentExpenseReport(context);
            // Display the report
            DisplayExpenseSummary(report);
        }
        public static List<DepartmentExpenseReport> GenerateDepartmentExpenseReport(EFCoreDbContext context)
        {
            // Group expenses by department and calculate the report data
            var expenseReports = context.Expenses
                .GroupBy(e => e.Department)
                .Select(group => new DepartmentExpenseReport
                {
                    DepartmentName = group.Key,
                    TotalExpenses = group.Sum(e => e.Amount),
                    NumberOfTransactions = group.Count()
                })
                .ToList();
            return expenseReports;
        }
        public static void DisplayExpenseSummary(List<DepartmentExpenseReport> expenseReports)
        {
            Console.WriteLine("Department Expense Summary Report");
            Console.WriteLine("----------------------------------");
            foreach (var report in expenseReports)
            {
                Console.WriteLine($"Department: {report.DepartmentName}");
                Console.WriteLine($"\tTotal Expenses: {report.TotalExpenses}");
                Console.WriteLine($"\tNumber of Transactions: {report.NumberOfTransactions}");
                Console.WriteLine(); //Line Break
            }
        }
    }
}
