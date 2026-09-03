namespace RealtimeInterfaceExample
{
    //Step 2: Implement the interface for different databases.
    // SqlDatabase.cs
    internal class SqlDatabase : IDatabase
    {
        public void Connect()
        {
            Console.WriteLine("Connected to SQL Database.");
        }
        public void Insert(string data)
        {
            Console.WriteLine($"Inserted '{data}' into SQL Database.");
        }
        public void Disconnect()
        {
            Console.WriteLine("Disconnected from SQL Database.");
        }
    }
}
