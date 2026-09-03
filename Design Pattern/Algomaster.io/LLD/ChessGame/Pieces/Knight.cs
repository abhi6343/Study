using ChessGame.Entities;
using ChessGame.Enums;

namespace ChessGame.Pieces
{
    internal class Knight(Color color) : Piece(color, PieceType.Knight)
    {
        public override bool CanMove(Board board, Position from, Position to)
        {
            int rowDiff = Math.Abs(to.Row - from.Row);
            int colDiff = Math.Abs(to.Col - from.Col);

            // L-shape: (2,1) or (1,2)
            bool isLShape = (rowDiff == 2 && colDiff == 1)
                         || (rowDiff == 1 && colDiff == 2);

            if (!isLShape)
            {
                return false;
            }

            // Knight can jump over pieces, so no path clearance check needed
            Piece? target = board.GetPiece(to);
            return target == null || target.Color != this.Color;
        }
    }
}
