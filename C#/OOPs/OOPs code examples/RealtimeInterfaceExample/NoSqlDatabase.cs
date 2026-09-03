namespace RealtimeInterfaceExample
{
    // NoSqlDatabase.cs
    internal class NoSqlDatabase : IDatabase
    {
        public void Connect()
        {
            Console.WriteLine("Connected to NoSQL Database.");
        }
        public void Insert(string data)
        {
            Console.WriteLine($"Inserted '{data}' into NoSQL Database.");
        }
        public void Disconnect()
        {
            Console.WriteLine("Disconnected from NoSQL Database.");
        }
    }
}
