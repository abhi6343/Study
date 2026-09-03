using MinesweeperGame.Entities;
using MinesweeperGame.Enums;

namespace MinesweeperGame.Commands
{
    internal class RevealCommand(Board board) : ICommand
    {
        List<Position> _revealedPositions = [];
        readonly Dictionary<Position, CellState> _previousStates = [];

        public List<Position> Execute(Position position)
        {
            // Snapshot current states before revealing
            var candidates = new Queue<Position>();
            var visited = new HashSet<Position>();
            candidates.Enqueue(position);
            while (candidates.Count > 0)
            {
                var current = candidates.Dequeue();
                if (!visited.Add(current)) continue;
                var cell = board.GetCell(current);
                if (!cell.IsRevealed)
                {
                    _previousStates[current] = cell.State;
                }
            }
            // Delegate actual reveal to board
            _revealedPositions = board.RevealCell(position);
            return _revealedPositions;
        }

        public void Undo()
        {
            foreach (var pos in _revealedPositions)
            {
                if (_previousStates.TryGetValue(pos, out var previous)
                    && previous == CellState.Hidden)
                {
                    board.GetCell(pos).Unflag(); //(CellState.Hidden);
                }
            }
            _revealedPositions.Clear();
            _previousStates.Clear();
        }
    }
}
