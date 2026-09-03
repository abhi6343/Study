using ChessGame.Entities;
using ChessGame.Enums;

namespace ChessGame.Pieces
{
    internal class King(Color color) : Piece(color, PieceType.King)
    {
        public override bool CanMove(Board board, Position from, Position to)
        {
            int rowDiff = Math.Abs(to.Row - from.Row);
            int colDiff = Math.Abs(to.Col - from.Col);

            // Normal king move: one square in any direction
            if (rowDiff <= 1 && colDiff <= 1 && (rowDiff + colDiff > 0))
            {
                Piece? target = board.GetPiece(to);
                return target == null || target.Color != this.Color;
            }

            // Castling: king moves two squares horizontally
            if (rowDiff == 0 && colDiff == 2 && !HasMoved)
            {
                return CanCastle(board, from, to);
            }

            return false;
        }

        private bool CanCastle(Board board, Position from, Position to)
        {
            int row = from.Row;
            int direction = to.Col > from.Col ? 1 : -1;
            int rookCol = direction == 1 ? 7 : 0;

            // Check that the rook is in place and hasn't moved
            Piece? rook = board.GetPiece(new Position(row, rookCol));
            if (rook == null || rook.PieceType != PieceType.Rook
                    || rook.HasMoved)
            {
                return false;
            }

            // Check that all squares between king and rook are empty
            int startCol = Math.Min(from.Col, rookCol) + 1;
            int endCol = Math.Max(from.Col, rookCol);
            for (int col = startCol; col < endCol; col++)
            {
                if (board.GetPiece(new Position(row, col)) != null)
                {
                    return false;
                }
            }

            // Note: checking that the king doesn't pass through or land in check
            // is handled by the Game class during move validation
            return true;
        }
    }
}
