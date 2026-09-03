namespace RealtimeAbstractClassExample
{
    //Manager.cs (Concrete Class)
    internal class Manager : Employee
    {
        public Manager(string name, string employeeID) : base(name, employeeID) { }
        // Concrete implementation of the PerformTask method for Manager
        public override void PerformTask()
        {
            Console.WriteLine($"{Name} is assigning tasks to team members.");
        }
        // Overriding the AttendMeeting method for Manager
        public override void AttendMeeting()
        {
            Console.WriteLine($"{Name} is attending a managerial meeting.");
        }
    }
}
