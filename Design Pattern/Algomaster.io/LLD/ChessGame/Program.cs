using ChessGame.Entities;
using ChessGame.Enums;
using ChessGame.Exceptions;

var white = new Player("Alice", Color.White);
var black = new Player("Bob", Color.Black);
var game = new Game(white, black);

Console.WriteLine("========== CHESS GAME: Alice (White) vs Bob (Black) ==========\n");

// Scholar's Mate (4-move checkmate)
Console.WriteLine("--- Move 1: White Pawn e2 -> e4 ---");
game.MakeMove(new Position(6, 4), new Position(4, 4));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\n--- Move 2: Black Pawn e7 -> e5 ---");
game.MakeMove(new Position(1, 4), new Position(3, 4));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\n--- Move 3: White Bishop f1 -> c4 ---");
game.MakeMove(new Position(7, 5), new Position(4, 2));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\n--- Move 4: Black Knight b8 -> c6 ---");
game.MakeMove(new Position(0, 1), new Position(2, 2));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\n--- Move 5: White Queen d1 -> h5 ---");
game.MakeMove(new Position(7, 3), new Position(3, 7));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\n--- Move 6: Black Knight g8 -> f6 ---");
game.MakeMove(new Position(0, 6), new Position(2, 5));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\n--- Move 7: White Queen h5 -> f7 (Scholar's Mate!) ---");
game.MakeMove(new Position(3, 7), new Position(1, 5));
Console.WriteLine("Status: " + game.Status);

Console.WriteLine("\nGame Over! Final status: " + game.Status);
Console.WriteLine("Move history (" + game.MoveHistory.Count + " moves):");
foreach (var move in game.MoveHistory)
{
    Console.WriteLine("  " + move);
}

// Try making a move after checkmate
Console.WriteLine("\n--- Attempt move after checkmate ---");
try
{
    game.MakeMove(new Position(0, 3), new Position(1, 3));
}
catch (ChessException e)
{
    Console.WriteLine("Caught: " + e.Message);
}
