using ChessGame.Enums;
using ChessGame.Exceptions;
using ChessGame.Pieces;

namespace ChessGame.Entities
{
    internal class Game(Player whitePlayer, Player blackPlayer)
    {
        readonly Board board = new();
        readonly Player[] players = [whitePlayer, blackPlayer];
        Color currentTurn = Color.White;
        readonly List<Move> moveHistory = [];
        GameStatus status = GameStatus.Active;

        public bool MakeMove(Position from, Position to)
        {
            // Check game is not over
            if (status == GameStatus.Checkmate || status == GameStatus.Stalemate || status == GameStatus.Resigned)
            {
                throw new ChessException("Game is already over: " + status);
            }

            // Validate piece exists and belongs to current player
            var piece = board.GetPiece(from) ?? throw new ChessException("No piece at " + from);
            if (piece.Color != currentTurn)
            {
                throw new ChessException("Not your turn. Current turn: " + currentTurn);
            }

            // Validate the piece can make this move
            if (!piece.CanMove(board, from, to))
            {
                throw new ChessException("Illegal move for " + piece.PieceType + " from " + from + " to " + to);
            }

            // Record move info before executing
            var move = new Move(from, to, piece);
            var capturedPiece = board.GetPiece(to);

            // Handle en passant capture
            if (piece.PieceType == PieceType.Pawn && Math.Abs(to.Col - from.Col) == 1 && capturedPiece == null)
            {
                // Diagonal pawn move to empty square = en passant
                var capturedPawnPos = new Position(from.Row, to.Col);
                var capturedPawn = board.GetPiece(capturedPawnPos);
                if (capturedPawn != null && capturedPawn.PieceType == PieceType.Pawn && capturedPawn.Color != currentTurn)
                {
                    // Verify the captured pawn just made a two-square advance
                    if (IsValidEnPassant(from, to, capturedPawnPos))
                    {
                        capturedPiece = capturedPawn;
                        board.SetPiece(capturedPawnPos, null);
                    }
                    else
                    {
                        throw new ChessException("Invalid en passant");
                    }
                }
            }

            move.CapturedPiece = capturedPiece;

            // Execute the move
            board.MovePiece(from, to);
            piece.HasMoved = true;

            // Handle castling rook movement
            if (piece.PieceType == PieceType.King && Math.Abs(to.Col - from.Col) == 2)
            {
                ExecuteCastlingRookMove(from, to);
            }

            // Handle pawn promotion (auto-promote to queen for simplicity)
            if (piece.PieceType == PieceType.Pawn)
            {
                int promotionRow = (piece.Color == Color.White) ? 0 : 7;
                if (to.Row == promotionRow)
                {
                    var promotedQueen = new Queen(piece.Color);
                    promotedQueen.HasMoved = true;
                    board.SetPiece(to, promotedQueen);
                    move.SetPromotion(true, PieceType.Queen);
                }
            }

            // Check if the move leaves our own king in check (illegal)
            if (IsInCheck(currentTurn))
            {
                // Undo the move
                UndoMove(move, from, to, piece, capturedPiece);
                throw new ChessException(
                    "Move leaves your king in check");
            }

            // Move is valid, record it
            moveHistory.Add(move);

            // Switch turns
            currentTurn = currentTurn.Opposite();

            // Update game status for the new current player
            UpdateGameStatus();

            return true;
        }

        private bool IsValidEnPassant(Position from, Position to,
                                       Position capturedPawnPos)
        {
            if (moveHistory.Count == 0) return false;
            Move lastMove = moveHistory[moveHistory.Count - 1];
            // The last move must have been a pawn moving two squares
            return lastMove.Piece.PieceType == PieceType.Pawn
                && Math.Abs(lastMove.Destination.Row
                    - lastMove.Source.Row) == 2
                && lastMove.Destination.Equals(capturedPawnPos);
        }

        private void ExecuteCastlingRookMove(Position kingFrom, Position kingTo)
        {
            int row = kingFrom.Row;
            if (kingTo.Col > kingFrom.Col)
            {
                // Kingside castling: move rook from h-file to f-file
                var rookFrom = new Position(row, 7);
                var rookTo = new Position(row, 5);
                Piece? rook = board.GetPiece(rookFrom);
                board.MovePiece(rookFrom, rookTo);
                rook!.HasMoved = true;
            }
            else
            {
                // Queenside castling: move rook from a-file to d-file
                var rookFrom = new Position(row, 0);
                var rookTo = new Position(row, 3);
                Piece? rook = board.GetPiece(rookFrom);
                board.MovePiece(rookFrom, rookTo);
                rook!.HasMoved = true;
            }
        }

        private void UndoMove(Move move, Position from, Position to,
                               Piece piece, Piece? capturedPiece)
        {
            board.SetPiece(from, piece);
            board.SetPiece(to, capturedPiece);

            // If it was en passant, restore the captured pawn
            if (piece.PieceType == PieceType.Pawn
                    && Math.Abs(to.Col - from.Col) == 1
                    && board.GetPiece(to) == null && capturedPiece != null)
            {
                var capturedPawnPos = new Position(from.Row, to.Col);
                board.SetPiece(capturedPawnPos, capturedPiece);
                board.SetPiece(to, null);
            }

            // If it was castling, undo the rook move too
            if (piece.PieceType == PieceType.King
                    && Math.Abs(to.Col - from.Col) == 2)
            {
                UndoCastlingRookMove(from, to);
            }

            // If it was a promotion, the piece reference is already correct
            // since we use the original pawn piece for undo
        }

        private void UndoCastlingRookMove(Position kingFrom, Position kingTo)
        {
            int row = kingFrom.Row;
            if (kingTo.Col > kingFrom.Col)
            {
                board.MovePiece(new Position(row, 5), new Position(row, 7));
            }
            else
            {
                board.MovePiece(new Position(row, 3), new Position(row, 0));
            }
        }

        public bool IsInCheck(Color color)
        {
            var kingPos = board.FindKing(color);
            var opponent = color.Opposite();

            // Check if any opponent piece can capture the king
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var piece = board.GetPiece(new Position(row, col));
                    if (piece != null && piece.Color == opponent)
                    {
                        if (piece.CanMove(board, new Position(row, col), kingPos))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsCheckmate(Color color)
        {
            if (!IsInCheck(color)) return false;
            return !HasAnyLegalMove(color);
        }

        public bool IsStalemate(Color color)
        {
            if (IsInCheck(color)) return false;
            return !HasAnyLegalMove(color);
        }

        private bool HasAnyLegalMove(Color color)
        {
            for (int fromRow = 0; fromRow < 8; fromRow++)
            {
                for (int fromCol = 0; fromCol < 8; fromCol++)
                {
                    var piece = board.GetPiece(new Position(fromRow, fromCol));
                    if (piece == null || piece.Color != color) continue;

                    // Try every destination square
                    for (int toRow = 0; toRow < 8; toRow++)
                    {
                        for (int toCol = 0; toCol < 8; toCol++)
                        {
                            var from = new Position(fromRow, fromCol);
                            var to = new Position(toRow, toCol);

                            if (from.Equals(to)) continue;

                            if (piece.CanMove(board, from, to))
                            {
                                // Simulate the move and check if it leaves
                                // our king in check
                                var captured = board.GetPiece(to);
                                board.MovePiece(from, to);

                                bool stillInCheck = IsInCheck(color);

                                // Undo simulation
                                board.SetPiece(from, piece);
                                board.SetPiece(to, captured);

                                if (!stillInCheck)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void UpdateGameStatus()
        {
            if (IsCheckmate(currentTurn))
            {
                status = GameStatus.Checkmate;
            }
            else if (IsStalemate(currentTurn))
            {
                status = GameStatus.Stalemate;
            }
            else if (IsInCheck(currentTurn))
            {
                status = GameStatus.Check;
            }
            else
            {
                status = GameStatus.Active;
            }
        }

        public void Resign(Color color)
        {
            if (status == GameStatus.Checkmate || status == GameStatus.Stalemate
                    || status == GameStatus.Resigned)
            {
                throw new ChessException("Game is already over");
            }
            status = GameStatus.Resigned;
        }
        private readonly Stack<Move> undoStack = new Stack<Move>();

        public void UndoLastMove()
        {
            if (moveHistory.Count == 0)
            {
                throw new ChessException("No moves to undo");
            }
            Move lastMove = moveHistory[moveHistory.Count - 1];
            moveHistory.RemoveAt(moveHistory.Count - 1);

            // Reverse the move
            board.SetPiece(lastMove.Source, lastMove.Piece);
            board.SetPiece(lastMove.Destination, lastMove.CapturedPiece);
            lastMove.Piece.HasMoved = false; // simplified; real impl tracks previous state

            // Handle un-promotion
            if (lastMove.IsPromotion)
            {
                board.SetPiece(lastMove.Source, lastMove.Piece);
            }

            undoStack.Push(lastMove);
            currentTurn = currentTurn.Opposite();
            UpdateGameStatus();
        }

        public void Redo()
        {
            if (undoStack.Count == 0)
            {
                throw new ChessException("No moves to redo");
            }
            Move move = undoStack.Pop();
            MakeMove(move.Source, move.Destination);
        }
        public bool CanClaimFiftyMoveRule()
        {
            if (moveHistory.Count < 100) return false; // 50 moves = 100 half-moves
            for (int i = moveHistory.Count - 100; i < moveHistory.Count; i++)
            {
                Move m = moveHistory[i];
                if (m.Piece.PieceType == PieceType.Pawn || m.CapturedPiece != null)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsInsufficientMaterial()
        {
            var whitePieces = new List<Piece>();
            var blackPieces = new List<Piece>();

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var p = board.GetPiece(new Position(r, c));
                    if (p == null) continue;
                    if (p.Color == Color.White) whitePieces.Add(p);
                    else blackPieces.Add(p);
                }
            }

            // King vs King
            if (whitePieces.Count == 1 && blackPieces.Count == 1) return true;

            // King+Bishop vs King or King+Knight vs King
            if (whitePieces.Count == 1 && blackPieces.Count == 2)
            {
                PieceType type = blackPieces
                    .Find(p => p.PieceType != PieceType.King)!.PieceType;
                return type == PieceType.Bishop || type == PieceType.Knight;
            }
            if (blackPieces.Count == 1 && whitePieces.Count == 2)
            {
                PieceType type = whitePieces
                    .Find(p => p.PieceType != PieceType.King)!.PieceType;
                return type == PieceType.Bishop || type == PieceType.Knight;
            }

            return false;
        }
        public GameStatus Status => status;
        public Board Board => board;
        public Color CurrentTurn => currentTurn;
        public IReadOnlyList<Move> MoveHistory => moveHistory.AsReadOnly();
    }
}
