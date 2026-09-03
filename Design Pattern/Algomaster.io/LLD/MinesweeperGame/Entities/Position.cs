namespace MinesweeperGame.Entities
{
    internal class Position(int row, int col)
    {
        public int Row { get; } = row;
        public int Col { get; } = col;

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Position position = (Position)obj;
            return Row == position.Row && Col == position.Col;
        }

        public override int GetHashCode()
        {
            return 31 * Row + Col;
        }

        public override string ToString()
        {
            return $"({Row}, {Col})";
        }
    }
}
