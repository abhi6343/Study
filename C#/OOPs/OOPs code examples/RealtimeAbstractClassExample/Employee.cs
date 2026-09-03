namespace RealtimeAbstractClassExample
{
    //Employee.cs (Abstract Class)
    internal abstract class Employee
    {
        public string Name { get; set; }
        public string EmployeeID { get; set; }
        // Constructor
        public Employee(string name, string employeeID)
        {
            Name = name;
            EmployeeID = employeeID;
        }
        // Abstract method with no body
        public abstract void PerformTask();
        // Virtual method with a default implementation
        public virtual void AttendMeeting()
        {
            Console.WriteLine($"{Name} is attending a general meeting.");
        }
    }
}
