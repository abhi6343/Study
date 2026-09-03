using ElevatorSystem.Enums;
using ElevatorSystem.Exceptions;
using ElevatorSystem.Observer;

namespace ElevatorSystem.Entities
{
    internal class Elevator
    {
        readonly int _id;
        int _currentFloor;
        Direction _direction;
        ElevatorState _state;
        readonly Door _door;
        readonly Display _display;
        // Ascending order: LINQ Min where >= current gives us the next floor above
        readonly SortedSet<int> _upRequests;
        // Descending order: LINQ Max where <= current gives us the next floor below
        readonly SortedSet<int> _downRequests;
        // Thread-safe list for observers that may be modified during iteration
        readonly List<IElevatorObserver> _observers;
        readonly Lock _observerLock = new();
        private readonly int _totalFloors;
        private readonly Lock _lock = new();

        public Elevator(int id, int totalFloors)
        {
            _id = id;
            _currentFloor = 1;
            _direction = Direction.Idle;
            _state = ElevatorState.Idle;
            _door = new();
            _display = new(id);
            _upRequests = [];
            // Reverse order so we can efficiently find the next floor BELOW current
            _downRequests = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            _observers = [];
            _totalFloors = totalFloors;
            AddObserver(_display);
        }

        public void AddRequest(int floor, Direction direction)
        {
            lock (_lock)
            {
                if (_state == ElevatorState.OutOfService)
                {
                    throw new ElevatorException($"Elevator {_id} is out of service");
                }
                if (floor < 1 || floor > _totalFloors)
                {
                    throw new ElevatorException($"Invalid floor: {floor}");
                }
                if (floor == _currentFloor)
                {
                    return; // Already at the requested floor
                }

                // Add to the appropriate request set based on direction
                if (direction == Direction.Up || floor > _currentFloor)
                {
                    _upRequests.Add(floor);
                }
                else
                {
                    _downRequests.Add(floor);
                }

                Console.WriteLine($"Elevator {_id} received request for floor {floor}");
            }
        }

        public int GetNextStop()
        {
            lock (_lock)
            {
                if (_direction == Direction.Up)
                {
                    // Find the next floor at or above current position
                    var above = _upRequests.GetViewBetween(_currentFloor, int.MaxValue);
                    if (above.Count > 0) return above.Min;
                    // No more up requests, check down requests
                    if (_downRequests.Count > 0) return -1; // Signal to reverse
                }
                else if (_direction == Direction.Down)
                {
                    // Find the next floor at or below current position
                    // downRequests is in descending order, so GetViewBetween needs reversed bounds
                    var below = _downRequests.GetViewBetween(_currentFloor, int.MaxValue);
                    if (below.Count > 0) return below.Min; // Min in reversed set = highest value <= current
                    // No more down requests, check up requests
                    if (_upRequests.Count > 0) return -1; // Signal to reverse
                }
                return -1; // No requests
            }
        }

        public void MoveToFloor(int floor)
        {
            lock (_lock)
            {
                _currentFloor = floor;
                if (_direction == Direction.Up)
                {
                    _state = ElevatorState.MovingUp;
                }
                else if (_direction == Direction.Down)
                {
                    _state = ElevatorState.MovingDown;
                }
            }
            NotifyObservers();
        }

        public void OpenDoor()
        {
            _door.Open();
            lock (_lock)
            {
                _state = ElevatorState.DoorOpen;
            }
            Console.WriteLine($"Elevator {_id} arrived at floor {_currentFloor}, opening door");
        }

        public void CloseDoor()
        {
            _door.Close();
            Console.WriteLine($"Elevator {_id} door closed");
        }

        public void RemoveCurrentFloorFromRequests()
        {
            lock (_lock)
            {
                _upRequests.Remove(_currentFloor);
                _downRequests.Remove(_currentFloor);
            }
        }

        public void AddObserver(IElevatorObserver observer)
        {
            lock (_observerLock)
            {
                _observers.Add(observer);
            }
        }

        public void NotifyObservers()
        {
            IEnumerable<IElevatorObserver> snapshot;
            lock (_observerLock)
            {
                snapshot = [.. _observers];
            }
            foreach (var observer in snapshot)
            {
                observer.OnElevatorStateChanged(_id, _currentFloor, _direction);
            }
        }

        public bool HasRequests()
        {
            lock (_lock)
            {
                return _upRequests.Count > 0 || _downRequests.Count > 0;
            }
        }

        public bool HasUpRequests()
        {
            lock (_lock)
            {
                return _upRequests.Count > 0;
            }
        }

        public bool HasDownRequests()
        {
            lock (_lock)
            {
                return _downRequests.Count > 0;
            }
        }

        public int Id => _id;

        public int CurrentFloor
        {
            get { lock (_lock) { return _currentFloor; } }
        }

        public Direction Direction
        {
            get { lock (_lock) { return _direction; } }
            set { lock (_lock) { _direction = value; } }
        }

        public ElevatorState State
        {
            get { lock (_lock) { return _state; } }
            set { lock (_lock) { _state = value; } }
        }

        public int TotalFloors => _totalFloors;

        public Display Display => _display;
    }
}
