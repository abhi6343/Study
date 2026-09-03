using SnakeLadderGame.Builder;
using SnakeLadderGame.Entities.BoardEntities;

var boardEntities = new List<BoardEntity>
    {
        new Snake(17, 7), new Snake(54, 34),
        new Snake(62, 19), new Snake(98, 79),
        new Ladder(3, 38), new Ladder(24, 33),
        new Ladder(42, 93), new Ladder(72, 84)
    };

var players = new List<string> { "Alice", "Bob", "Charlie" };

var game = new Game.Builder()
    .CreateBoard(100, boardEntities)
    .SetPlayers(players)
    .SetDice(new(1, 6))
    .Build();

game.Play();
