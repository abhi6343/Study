using ElevatorSystem.Enums;

namespace ElevatorSystem.Observer
{
    internal interface IElevatorObserver
    {
        void OnElevatorStateChanged(int elevatorId, int floor, Direction direction);
    }
}
