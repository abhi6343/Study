using ChessGame.Exceptions;

namespace ChessGame.Entities
{
    internal class Position
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col)
        {
            if (row < 0 || row > 7 || col < 0 || col > 7)
            {
                throw new ChessException($"Invalid position: ({row}, {col})");
            }
            Row = row;
            Col = col;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj is not Position p) return false;
            return Row == p.Row && Col == p.Col;
        }

        public override int GetHashCode()
        {
            return 31 * Row + Col;
        }

        public override string ToString()
        {
            char file = (char)('a' + Col);
            int rank = 8 - Row;
            return $"{file}{rank}";
        }
    }
}
