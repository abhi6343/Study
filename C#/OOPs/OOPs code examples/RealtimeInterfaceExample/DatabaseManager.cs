namespace RealtimeInterfaceExample
{
    //Step 3: Use the implementations in an application.
    internal class DatabaseManager
    {
        private IDatabase _database;
        public DatabaseManager(IDatabase database)
        {
            _database = database;
        }
        public void AddData(string data)
        {
            _database.Connect();
            _database.Insert(data);
            _database.Disconnect();
        }
    }
}
