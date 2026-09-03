namespace GroupByMultipleKeys
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "John Doe", Department = "IT", JobTitle = "Developer" },
                new Employee { Name = "Jane Smith", Department = "IT", JobTitle = "Developer" },
                new Employee { Name = "Mary Johnson", Department = "IT", JobTitle = "QA Tester" },
                new Employee { Name = "James Brown", Department = "HR", JobTitle = "Recruiter" },
                new Employee { Name = "Sara Taylor", Department = "IT", JobTitle = "QA Tester" },
                new Employee { Name = "Steve Smith", Department = "HR", JobTitle = "Recruiter" },
                // Add more employees here
            };
            return employees;
        }
    }
}
