using TicTacToe.Enums;

namespace TicTacToe.Entities
{
    internal class Player(string name, Symbol symbol)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public Symbol Symbol { get; set; } = symbol;
    }
}
