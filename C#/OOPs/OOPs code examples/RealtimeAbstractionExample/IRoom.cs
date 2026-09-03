namespace RealtimeAbstractionExample
{
    //Abstraction Layer
    //Define an abstract class or interface that encapsulates the common behavior of all room types
    internal interface IRoom
    {
        decimal Rate { get; }
        int Capacity { get; }
        string Description { get; }
        void DisplayRoomDetails();
    }
}
