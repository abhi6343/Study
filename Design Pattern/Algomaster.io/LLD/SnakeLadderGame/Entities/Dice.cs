namespace SnakeLadderGame.Entities
{
    internal class Dice(int minVal, int maxVal)
    {
        readonly Random random = new();

        public int Roll() => random.Next(minVal, maxVal + 1);
    }
}
