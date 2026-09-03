using ElevatorSystem.Enums;

namespace ElevatorSystem.Entities
{
    internal class Request(int floor, Direction direction, RequestType type)
    {
        public int Floor => floor;
        public Direction Direction => direction;
        public RequestType Type => type;
        public long Timestamp { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public override string ToString() => $"Request{{Floor={Floor}, Direction={Direction}, Type={Type}}}";
    }
}
