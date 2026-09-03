namespace GroupByMethod
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "Alice", Department = "IT", Role = "Developer" },
                new Employee { Name = "Bob", Department = "IT", Role = "Tester" },
                new Employee { Name = "Charlie", Department = "HR", Role = "Recruiter" },
                new Employee { Name = "David", Department = "IT", Role = "Developer" },
                new Employee { Name = "Eve", Department = "HR", Role = "Manager" },
                new Employee { Name = "Frank", Department = "IT", Role = "Developer" }
            };
            return employees;
        }
    }
}
