using ElevatorSystem.Enums;

namespace ElevatorSystem.Entities
{
    internal class Door
    {
        DoorState _state = DoorState.Closed;
        readonly Lock _lock = new();

        public void Open()
        {
            lock (_lock)
            {
                _state = DoorState.Open;
            }
        }

        public void Close()
        {
            lock (_lock)
            {
                _state = DoorState.Closed;
            }
        }

        public bool IsOpen()
        {
            lock (_lock)
            {
                return _state == DoorState.Open;
            }
        }

        public DoorState GetState()
        {
            lock (_lock)
            {
                return _state;
            }
        }
    }
}
