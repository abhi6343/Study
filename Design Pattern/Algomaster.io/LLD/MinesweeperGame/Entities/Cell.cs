using MinesweeperGame.Enums;

namespace MinesweeperGame.Entities
{
    internal class Cell(Position position)
    {
        public Position Position { get; } = position;
        public bool HasMine { get; set; } = false;
        public int AdjacentMineCount { get; set; } = 0;
        public CellState State { get; private set; } = CellState.Hidden;

        public void Reveal()
        {
            State = CellState.Revealed;
        }

        public void Flag()
        {
            State = CellState.Flagged;
        }

        public void Unflag()
        {
            State = CellState.Hidden;
        }

        public bool IsHidden => State == CellState.Hidden;
        public bool IsRevealed => State == CellState.Revealed;
        public bool IsFlagged => State == CellState.Flagged;
    }
}
