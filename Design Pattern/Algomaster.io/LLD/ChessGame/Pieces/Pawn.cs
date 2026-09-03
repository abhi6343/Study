using ChessGame.Entities;
using ChessGame.Enums;

namespace ChessGame.Pieces
{
    internal class Pawn(Color color) : Piece(color, PieceType.Pawn)
    {
        public override bool CanMove(Board board, Position from, Position to)
        {
            int direction = (Color == Color.White) ? -1 : 1;
            int rowDiff = to.Row - from.Row;
            int colDiff = to.Col - from.Col;

            // Forward one square
            if (colDiff == 0 && rowDiff == direction)
            {
                return board.GetPiece(to) == null;
            }

            // Forward two squares from starting position
            if (colDiff == 0 && rowDiff == 2 * direction && !HasMoved)
            {
                var intermediate = new Position(
                    from.Row + direction, from.Col);
                return board.GetPiece(intermediate) == null
                    && board.GetPiece(to) == null;
            }

            // Diagonal capture (including en passant)
            if (Math.Abs(colDiff) == 1 && rowDiff == direction)
            {
                Piece? target = board.GetPiece(to);
                if (target != null && target.Color != this.Color)
                {
                    return true;
                }
                // En passant: target square is empty but adjacent pawn just
                // made a two-square advance
                // (En passant validation is completed in Game.MakeMove()
                //  which checks the move history)
                return board.GetPiece(to) == null
                    && board.GetPiece(new Position(from.Row, to.Col)) != null;
            }

            return false;
        }
    }
}
