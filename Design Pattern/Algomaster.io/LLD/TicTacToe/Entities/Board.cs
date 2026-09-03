using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    internal class Board
    {
        readonly int size;
        readonly Cell[][] cells;
        public Board(int size)
        {
            this.size = size;
            cells = new Cell[size][];
            for (int i = 0; i < size; i++)
            {
                cells[i] = new Cell[size];
                for (int j = 0; j < size; j++)
                {
                    cells[i][j] = new();
                }
            }
        }

        public bool IsEmptyCell(int row, int col) => cells[row][col].Symbol == Symbol._;
        public Symbol GetCellSymbol(int row, int col) => cells[row][col].Symbol;
        public void SetCellSymbol(Symbol symbol, int row, int col)
        {
            try
            {
                if (row < 0 || col < 0 || row >= size || col >= size)
                {
                    throw new ArgumentOutOfRangeException($"Invalid position [{row}][{col}]: out of bounds.");
                }
                if (!IsEmptyCell(row, col))
                {
                    throw new ArgumentException("Invalid move: cell already occupied.");
                }
                cells[row][col].Symbol = symbol;
            }
            catch { }
        }        
        public bool IsFull()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[i][j].Symbol == Symbol._)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < size; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(cells[i][j].Symbol + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }
    }
}
