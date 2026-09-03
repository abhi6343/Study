using ElevatorSystem.Entities;
using ElevatorSystem.Enums;

namespace ElevatorSystem.Strategy
{
    internal interface IDispatchStrategy
    {
        Elevator SelectElevator(List<Elevator> elevators, int floor, Direction direction);
    }
}
