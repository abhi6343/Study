namespace RealtimeAbstractionExample
{
    //Abstraction Layer
    //Define a common interface for all messaging platforms
    internal interface IMessagingService
    {
        void SendMessage(string recipient, string message);
    }
}
