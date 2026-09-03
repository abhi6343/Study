namespace RealtimeInheritanceExample2
{
    //Derived Class (Child Class) - Student
    internal class Student : Person
    {
        public string StudentId { get; set; }
        public Student(string name, int age, string address, string studentId)
        : base(name, age, address) // Calling base class constructor
        {
            StudentId = studentId;
        }
        public void Enroll(string courseName)
        {
            Console.WriteLine($"{Name} has enrolled in {courseName} course.");
        }
    }
}
