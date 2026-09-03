using ElevatorSystem.Entities;
using ElevatorSystem.Enums;
using ElevatorSystem.Exceptions;

namespace ElevatorSystem.Strategy
{
    internal class NearestElevatorStrategy(int totalFloors) : IDispatchStrategy
    {
        public Elevator SelectElevator(List<Elevator> elevators, int floor, Direction direction)
        {
            Elevator? bestElevator = null;
            int bestScore = -1;

            foreach (var elevator in elevators)
            {
                if (elevator.State == ElevatorState.OutOfService)
                {
                    continue; // Skip out-of-service elevators
                }

                int distance = Math.Abs(elevator.CurrentFloor - floor);
                int score = 0;

                var elevatorDir = elevator.Direction;

                if (elevatorDir == Direction.Idle)
                {
                    // Idle elevator: score based on proximity
                    score = totalFloors - distance;
                }
                else if (elevatorDir == direction)
                {
                    // Same direction: check if it hasn't passed the floor yet
                    bool hasPassed;
                    if (direction == Direction.Up)
                    {
                        hasPassed = elevator.CurrentFloor > floor;
                    }
                    else
                    {
                        hasPassed = elevator.CurrentFloor < floor;
                    }

                    if (!hasPassed)
                    {
                        // Best case: heading toward us in the right direction
                        score = totalFloors - distance + totalFloors;
                    }
                    else
                    {
                        // Already passed, would need to come back
                        score = 1;
                    }
                }
                else
                {
                    // Opposite direction: low priority
                    score = 1;
                }

                if (score > bestScore)
                {
                    bestScore = score;
                    bestElevator = elevator;
                }
            }

            if (bestElevator == null)
            {
                throw new ElevatorException($"No available elevator for floor {floor}");
            }

            return bestElevator;
        }
    }
}
