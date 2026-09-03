namespace Paging
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee() {ID = 1, Name = "Pranaya", Department = "IT" },
                new Employee() {ID = 2, Name = "Priyanka", Department = "IT" },
                new Employee() {ID = 3, Name = "Preety", Department = "IT" },
                new Employee() {ID = 4, Name = "Sambit", Department = "IT" },
                new Employee() {ID = 5, Name = "Sudhanshu", Department = "HR" },
                new Employee() {ID = 6, Name = "Santosh", Department = "HR" },
                new Employee() {ID = 7, Name = "Happy", Department = "HR" },
                new Employee() {ID = 8, Name = "Raja", Department = "IT" },
                new Employee() {ID = 9, Name = "Tarun", Department = "IT" },
                new Employee() {ID = 10, Name = "Bablu", Department = "IT" },
                new Employee() {ID = 11, Name = "Hina", Department = "HR" },
                new Employee() {ID = 12, Name = "Anurag", Department = "HR" },
                new Employee() {ID = 13, Name = "Dillip", Department = "HR" },
                new Employee() {ID = 14, Name = "Manoj", Department = "HR" },
                new Employee() {ID = 15, Name = "Lima", Department = "IT" },
                new Employee() {ID = 16, Name = "Sona", Department = "IT" },
            };
        }
    }
}
