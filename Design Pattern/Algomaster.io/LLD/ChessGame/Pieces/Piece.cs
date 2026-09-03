using ChessGame.Entities;
using ChessGame.Enums;

namespace ChessGame.Pieces
{
    internal abstract class Piece(Color color, PieceType pieceType)
    {
        public Color Color { get; } = color;
        public PieceType PieceType { get; } = pieceType;
        public bool HasMoved { get; set; } = false;

        public abstract bool CanMove(Board board, Position from, Position to);
    }
}
