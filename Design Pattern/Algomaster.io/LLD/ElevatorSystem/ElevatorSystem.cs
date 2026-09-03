using ElevatorSystem.Entities;
using ElevatorSystem.Enums;
using ElevatorSystem.Exceptions;
using ElevatorSystem.Strategy;

namespace ElevatorSystem
{
    internal class ElevatorSystem
    {
        // volatile ensures visibility of the fully constructed instance across threads
        static volatile ElevatorSystem? _instance;
        static readonly Lock _singletonLock = new();
        readonly List<Elevator> _elevators = [];
        readonly ICollection<ElevatorController> _controllers = [];
        readonly ICollection<Thread> _controllerThreads = [];
        readonly List<Floor> _floors = [];
        IDispatchStrategy _dispatchStrategy;
        readonly Lock _lock = new();

        ElevatorSystem(int numElevators, int numFloors)
        {
            // Create floors
            for (int i = 1; i <= numFloors; i++)
            {
                _floors.Add(new(i));
            }

            // Create elevators and their controllers
            for (int i = 1; i <= numElevators; i++)
            {
                var elevator = new Elevator(i, numFloors);
                _elevators.Add(elevator);

                var controller = new ElevatorController(elevator);
                _controllers.Add(controller);

                var thread = new Thread(controller.Run)
                {
                    Name = $"Elevator-{i}",
                    // Background threads won't prevent process exit
                    IsBackground = true
                };
                _controllerThreads.Add(thread);
                thread.Start();
            }

            // Default dispatch strategy
            _dispatchStrategy = new NearestElevatorStrategy(numFloors);
        }

        public static ElevatorSystem GetInstance(int numElevators, int numFloors)
        {
            if (_instance == null)
            {
                lock (_singletonLock)
                {
                    _instance ??= new(numElevators, numFloors);
                }
            }
            return _instance;
        }

        public void RequestElevator(int floor, Direction direction)
        {
            lock (_lock)
            {
                if (floor < 1 || floor > _floors.Count)
                {
                    throw new ElevatorException($"Invalid floor: {floor}. Building has floors 1 to {_floors.Count}");
                }
                if (direction == Direction.Idle)
                {
                    throw new ElevatorException("External request must specify Up or Down direction");
                }

                var selected = _dispatchStrategy.SelectElevator(_elevators, floor, direction);
                selected.AddRequest(floor, direction);
                Console.WriteLine($"Dispatching Elevator {selected.Id} to floor {floor} ({direction})");
            }
        }

        public void SetDispatchStrategy(IDispatchStrategy strategy)
        {
            _dispatchStrategy = strategy;
        }

        public void Shutdown()
        {
            foreach (var controller in _controllers)
            {
                controller.Stop();
            }
            foreach (var thread in _controllerThreads)
            {
                thread.Join(2000); // Wait up to 2 seconds for each thread
            }
        }

        public IReadOnlyList<Elevator> Elevators => _elevators.AsReadOnly();
    }
}
