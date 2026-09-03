namespace RealtimeInterfaceExample
{
    //Step 1: Define the IDatabase interface.
    internal interface IDatabase
    {
        void Connect();
        void Insert(string data);
        void Disconnect();
    }
}
