using ChessGame.Enums;

namespace ChessGame.Entities
{
    internal class Player(string name, Color color)
    {
        public string Name { get; } = name;
        public Color Color { get; } = color;

        public override string ToString() => $"{Name} ({Color})";
    }
}
