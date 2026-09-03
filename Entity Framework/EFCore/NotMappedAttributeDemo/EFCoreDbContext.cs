using Microsoft.EntityFrameworkCore;
using NotMappedAttributeDemo.Entities;

namespace NotMappedAttributeDemo
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NotMappedAttributeDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Seeding Department data
        //    modelBuilder.Entity<Department>().HasData(
        //        new Department { DepartmentId = 1, Name = "Human Resources" },
        //        new Department { DepartmentId = 2, Name = "IT" }
        //    );
        //    // Seeding Employee data
        //    modelBuilder.Entity<Employee>().HasData(
        //        new Employee
        //        {
        //            EmployeeId = 1,
        //            FirstName = "Hina",
        //            LastName = "Sharma",
        //            DateOfJoining = new DateTime(2015, 6, 1),
        //            DateOfBirth = new DateTime(1990, 5, 15),
        //            DepartmentId = 1 // Human Resources
        //        },
        //        new Employee
        //        {
        //            EmployeeId = 2,
        //            FirstName = "Pranaya",
        //            LastName = "Rout",
        //            DateOfJoining = new DateTime(2018, 4, 10),
        //            DateOfBirth = new DateTime(1992, 8, 20),
        //            DepartmentId = 2 // IT
        //        },
        //        new Employee
        //        {
        //            EmployeeId = 3,
        //            FirstName = "Rakesh",
        //            LastName = "Singh",
        //            DateOfJoining = new DateTime(2020, 3, 15),
        //            DateOfBirth = new DateTime(1985, 12, 5),
        //            DepartmentId = 2 // IT
        //        },
        //        new Employee
        //        {
        //            EmployeeId = 4,
        //            FirstName = "Priyanka",
        //            LastName = "Tiwary",
        //            DateOfJoining = new DateTime(2017, 11, 20),
        //            DateOfBirth = new DateTime(1995, 3, 10),
        //            DepartmentId = 1 // Human Resources
        //        }
        //    );
        //}
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for the Expense entity
            modelBuilder.Entity<Expense>().HasData(
                new Expense { ExpenseId = 1, Department = "HR", Purpose = "Office Supplies", Amount = 1500, Date = new DateTime(2024, 9, 15) },
                new Expense { ExpenseId = 2, Department = "IT", Purpose = "Software License", Amount = 3500, Date = new DateTime(2024, 9, 16) },
                new Expense { ExpenseId = 3, Department = "IT", Purpose = "Team Lunch", Amount = 800, Date = new DateTime(2024, 9, 17) },
                new Expense { ExpenseId = 4, Department = "HR", Purpose = "Training", Amount = 2500, Date = new DateTime(2024, 9, 18) },
                new Expense { ExpenseId = 5, Department = "IT", Purpose = "Hardware Upgrade", Amount = 5500, Date = new DateTime(2024, 9, 19) }
            );
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<DepartmentExpenseReport> DepartmentExpenseReports { get; set; }
    }
}
