using ElevatorSystem.Entities;
using ElevatorSystem.Enums;

namespace ElevatorSystem
{
    internal class ElevatorController(Elevator elevator)
    {
        volatile bool _running = true;

        public void Run()
        {
            while (_running)
            {
                if (elevator.HasRequests())
                {
                    ProcessRequests();
                }
                else
                {
                    // No requests, go idle and wait
                    elevator.Direction = Direction.Idle;
                    elevator.State = ElevatorState.Idle;
                    Thread.Sleep(100); // Avoid busy-waiting
                }
            }
        }

        public void Stop()
        {
            _running = false;
        }

        private void ProcessRequests()
        {
            var dir = elevator.Direction;

            if (dir == Direction.Idle)
            {
                // Starting fresh: pick a direction based on available requests
                if (elevator.HasUpRequests())
                {
                    elevator.Direction = Direction.Up;
                }
                else if (elevator.HasDownRequests())
                {
                    elevator.Direction = Direction.Down;
                }
                return;
            }

            int nextStop = elevator.GetNextStop();

            if (nextStop == -1)
            {
                // No more requests in current direction, try reversing
                if (dir == Direction.Up && elevator.HasDownRequests())
                {
                    elevator.Direction = Direction.Down;
                }
                else if (dir == Direction.Down && elevator.HasUpRequests())
                {
                    elevator.Direction = Direction.Up;
                }
                else
                {
                    elevator.Direction = Direction.Idle;
                    elevator.State = ElevatorState.Idle;
                }
                return;
            }

            // Move toward the next stop, one floor at a time
            int currentFloor = elevator.CurrentFloor;
            if (nextStop > currentFloor)
            {
                elevator.MoveToFloor(currentFloor + 1);
            }
            else if (nextStop < currentFloor)
            {
                elevator.MoveToFloor(currentFloor - 1);
            }

            // Check if we've arrived at a requested floor
            if (elevator.CurrentFloor == nextStop)
            {
                ServeFloor();
            }

            // Simulate travel time between floors
            Thread.Sleep(500);
        }

        void ServeFloor()
        {
            elevator.OpenDoor();
            // Simulate passengers entering/exiting
            Thread.Sleep(1000);
            elevator.CloseDoor();
            elevator.RemoveCurrentFloorFromRequests();
        }
    }
}
