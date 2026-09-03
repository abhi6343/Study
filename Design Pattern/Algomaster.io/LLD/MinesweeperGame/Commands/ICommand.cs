using MinesweeperGame.Entities;

namespace MinesweeperGame.Commands
{
    internal interface ICommand
    {
        List<Position> Execute(Position position);
    }
}
