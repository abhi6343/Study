using ElevatorSystem.Enums;

namespace ElevatorSystem.Observer
{
    internal class Display(int elevatorId) : IElevatorObserver
    {
        readonly int _elevatorId = elevatorId;
        int _currentFloor = 1;
        Direction _currentDirection = Direction.Idle;

        public void OnElevatorStateChanged(int elevatorId, int floor, Direction direction)
        {
            // Only update if this notification is for our elevator
            if (_elevatorId == elevatorId)
            {
                _currentFloor = floor;
                _currentDirection = direction;
                Show();
            }
        }

        void Show()
        {
            Console.WriteLine($"Display [Elevator {_elevatorId}]: Floor {_currentFloor} | Direction: {_currentDirection}");
        }

        public int ElevatorId => _elevatorId;
    }
}
