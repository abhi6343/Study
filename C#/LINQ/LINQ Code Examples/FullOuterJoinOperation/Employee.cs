namespace FullOuterJoinOperation
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", DepartmentId = 10},
                new Employee { ID = 2, Name = "Priyanka", DepartmentId =20},
                new Employee { ID = 3, Name = "Anurag", DepartmentId = 0},
                new Employee { ID = 4, Name = "Pranaya", DepartmentId = 0},
                new Employee { ID = 5, Name = "Hina", DepartmentId = 10},
                new Employee { ID = 6, Name = "Sambit", DepartmentId = 30},
                new Employee { ID = 7, Name = "Mahesh", DepartmentId = 30}
            };
        }
    }
}
