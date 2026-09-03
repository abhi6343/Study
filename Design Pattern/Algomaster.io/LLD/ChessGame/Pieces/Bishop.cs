using ChessGame.Entities;
using ChessGame.Enums;

namespace ChessGame.Pieces
{
    internal class Bishop(Color color) : Piece(color, PieceType.Bishop)
    {
        public override bool CanMove(Board board, Position from, Position to)
        {
            int rowDiff = to.Row - from.Row;
            int colDiff = to.Col - from.Col;

            // Must move diagonally (equal row and column distance)
            if (Math.Abs(rowDiff) != Math.Abs(colDiff) || rowDiff == 0)
            {
                return false;
            }

            // Check path is clear
            if (!IsPathClear(board, from, to))
            {
                return false;
            }

            Piece? target = board.GetPiece(to);
            return target == null || target.Color != this.Color;
        }

        private bool IsPathClear(Board board, Position from, Position to)
        {
            int rowDir = Math.Sign(to.Row - from.Row);
            int colDir = Math.Sign(to.Col - from.Col);

            int currentRow = from.Row + rowDir;
            int currentCol = from.Col + colDir;

            while (currentRow != to.Row || currentCol != to.Col)
            {
                if (board.GetPiece(new Position(currentRow, currentCol)) != null)
                {
                    return false;
                }
                currentRow += rowDir;
                currentCol += colDir;
            }
            return true;
        }
    }
}
