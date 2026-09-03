namespace RealtimeAbstractClassExample
{
    //Developer.cs (Concrete Class)
    internal class Developer : Employee
    {
        public Developer(string name, string employeeID) : base(name, employeeID) { }
        // Concrete implementation of the PerformTask method for Developer
        public override void PerformTask()
        {
            Console.WriteLine($"{Name} is writing code.");
        }
    }
}
