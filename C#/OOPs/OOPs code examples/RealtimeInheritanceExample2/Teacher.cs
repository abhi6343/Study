namespace RealtimeInheritanceExample2
{
    internal class Teacher : Person
    {
        public string EmployeeId { get; set; }
        public Teacher(string name, int age, string address, string employeeId)
            : base(name, age, address) // Calling base class constructor
        {
            EmployeeId = employeeId;
        }
        public void Teach(string courseName)
        {
            Console.WriteLine($"{Name} is teaching {courseName} course.");
        }
    }
}
