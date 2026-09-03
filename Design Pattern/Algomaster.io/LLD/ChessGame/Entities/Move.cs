using ChessGame.Enums;
using ChessGame.Pieces;

namespace ChessGame.Entities
{
    internal class Move(Position source, Position destination, Piece piece)
    {
        public Position Source { get; } = source;
        public Position Destination { get; } = destination;
        public Piece Piece { get; } = piece;
        public Piece? CapturedPiece { get; set; }
        public bool IsPromotion { get; private set; }
        public PieceType? PromotedTo { get; private set; }

        public void SetPromotion(bool promotion, PieceType promotedTo)
        {
            IsPromotion = promotion;
            PromotedTo = promotedTo;
        }

        public override string ToString()
        {
            var pieceStr = $"{Piece.Color} {Piece.PieceType}";
            var moveStr = $"{Source} -> {Destination}";
            var extra = "";
            if (CapturedPiece != null)
            {
                extra += $" captures {CapturedPiece.PieceType}";
            }
            if (IsPromotion)
            {
                extra += $" (promoted to {PromotedTo})";
            }
            return $"{pieceStr} {moveStr}{extra}";
        }
    }
}
