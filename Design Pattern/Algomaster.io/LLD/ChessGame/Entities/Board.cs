using ChessGame.Enums;
using ChessGame.Exceptions;
using ChessGame.Pieces;

namespace ChessGame.Entities
{
    internal class Board
    {
        private readonly Piece?[,] grid;

        public Board()
        {
            grid = new Piece[8, 8];
            Initialize();
        }

        private void Initialize()
        {
            // Black pieces (row 0)
            grid[0, 0] = new Rook(Color.Black);
            grid[0, 1] = new Knight(Color.Black);
            grid[0, 2] = new Bishop(Color.Black);
            grid[0, 3] = new Queen(Color.Black);
            grid[0, 4] = new King(Color.Black);
            grid[0, 5] = new Bishop(Color.Black);
            grid[0, 6] = new Knight(Color.Black);
            grid[0, 7] = new Rook(Color.Black);

            // Black pawns (row 1)
            for (int col = 0; col < 8; col++)
            {
                grid[1, col] = new Pawn(Color.Black);
            }

            // White pawns (row 6)
            for (int col = 0; col < 8; col++)
            {
                grid[6, col] = new Pawn(Color.White);
            }

            // White pieces (row 7)
            grid[7, 0] = new Rook(Color.White);
            grid[7, 1] = new Knight(Color.White);
            grid[7, 2] = new Bishop(Color.White);
            grid[7, 3] = new Queen(Color.White);
            grid[7, 4] = new King(Color.White);
            grid[7, 5] = new Bishop(Color.White);
            grid[7, 6] = new Knight(Color.White);
            grid[7, 7] = new Rook(Color.White);
        }

        public Piece? GetPiece(Position position)
        {
            return grid[position.Row, position.Col];
        }

        public void SetPiece(Position position, Piece? piece)
        {
            grid[position.Row, position.Col] = piece;
        }

        public void MovePiece(Position from, Position to)
        {
            grid[to.Row, to.Col] = grid[from.Row, from.Col];
            grid[from.Row, from.Col] = null;
        }

        public static bool IsValidPosition(int row, int col) => row >= 0 && row < 8 && col >= 0 && col < 8;

        public Position FindKing(Color color)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece? piece = grid[row, col];
                    if (piece != null && piece.PieceType == PieceType.King && piece.Color == color)
                    {
                        return new Position(row, col);
                    }
                }
            }
            throw new ChessException("King not found for " + color);
        }
    }
}
