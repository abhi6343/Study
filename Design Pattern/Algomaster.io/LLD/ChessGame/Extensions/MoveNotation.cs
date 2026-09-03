using ChessGame.Entities;
using ChessGame.Enums;
using ChessGame.Pieces;

namespace ChessGame.Extensions
{
    internal static class MoveNotation
    {
        public static string ToAlgebraic(Move move)
        {
            Piece piece = move.Piece;
            string destination = move.Destination.ToString();
            string capture = move.CapturedPiece != null ? "x" : "";

            // Castling
            if (piece.PieceType == PieceType.King
                    && Math.Abs(move.Destination.Col
                        - move.Source.Col) == 2)
            {
                return move.Destination.Col > move.Source.Col
                    ? "O-O" : "O-O-O";
            }

            // Pawn moves don't include piece symbol
            if (piece.PieceType == PieceType.Pawn)
            {
                if (capture.Length == 0) return destination;
                return move.Source.ToString()[0] + capture + destination;
            }

            return GetPieceSymbol(piece.PieceType) + capture + destination;
        }

        private static string GetPieceSymbol(PieceType type)
        {
            return type switch
            {
                PieceType.King => "K",
                PieceType.Queen => "Q",
                PieceType.Rook => "R",
                PieceType.Bishop => "B",
                PieceType.Knight => "N",
                _ => ""
            };
        }
    }
}
