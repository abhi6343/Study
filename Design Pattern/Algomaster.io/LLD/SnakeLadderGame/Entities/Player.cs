namespace SnakeLadderGame.Entities
{
    internal class Player(string name)
    {
        public string Name => name;
        public int Position { get; set; }
    }
}
