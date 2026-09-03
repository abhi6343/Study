using ElevatorSystem.Entities;
using ElevatorSystem.Enums;
using ElevatorSystem.Exceptions;

namespace ElevatorSystem.Strategy
{
    internal class ZoneBasedStrategy : IDispatchStrategy
    {
        readonly Dictionary<int, int> _zoneAssignments = [];

        public ZoneBasedStrategy(int totalFloors, int numElevators)
        {
            int floorsPerZone = totalFloors / numElevators;
            int remainder = totalFloors % numElevators;

            int floorStart = 1;
            for (int i = 0; i < numElevators; i++)
            {
                int zoneSize = floorsPerZone + (i < remainder ? 1 : 0);
                for (int f = floorStart; f < floorStart + zoneSize; f++)
                {
                    _zoneAssignments[f] = i;
                }
                floorStart += zoneSize;
            }
        }

        public Elevator SelectElevator(List<Elevator> elevators, int floor, Direction direction)
        {
            if (_zoneAssignments.TryGetValue(floor, out var assignedIndex) && assignedIndex < elevators.Count)
            {
                var assigned = elevators[assignedIndex];
                if (assigned.State != ElevatorState.OutOfService)
                {
                    return assigned;
                }
            }

            // Fallback: find nearest available elevator
            Elevator? fallback = null;
            int minDistance = int.MaxValue;
            foreach (var elevator in elevators)
            {
                if (elevator.State != ElevatorState.OutOfService)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - floor);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        fallback = elevator;
                    }
                }
            }

            if (fallback == null)
            {
                throw new ElevatorException($"No available elevator for floor {floor}");
            }

            return fallback;
        }
    }
}
