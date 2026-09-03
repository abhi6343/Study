using MinesweeperGame.Entities;
using MinesweeperGame.Enums;
using MinesweeperGame.Singleton_Facade;
using MinesweeperGame.Strategies;

MinesweeperSystem system = MinesweeperSystem.Instance;

// Game 1: Win scenario with custom mine placement
Console.WriteLine("========== GAME 1: WIN SCENARIO ==========");

// 4x4 board with 3 mines at known positions
var mines1 = new List<Position>
        {
            new(0, 0),
            new(2, 3),
            new(3, 0)
        };
system.CreateGame(Difficulty.Easy, new CustomMinePlacement(mines1));

// First click is safe (mines placed after this)
system.RevealCell(1, 1);

// Reveal all non-mine cells
system.RevealCell(0, 1);
system.RevealCell(0, 2);
system.RevealCell(0, 3);
system.RevealCell(1, 0);
system.RevealCell(1, 2);
system.RevealCell(1, 3);
system.RevealCell(2, 0);
system.RevealCell(2, 1);
system.RevealCell(2, 2);
system.RevealCell(3, 1);
system.RevealCell(3, 2);
system.RevealCell(3, 3);

Console.WriteLine($"Game 1 Result: {system.GameStatus}");

// Game 2: Loss scenario
Console.WriteLine("\n========== GAME 2: LOSS SCENARIO ==========");

var mines2 = new List<Position>
        {
            new(0, 1),
            new(1, 0),
            new(2, 2)
        };
system.CreateGame(Difficulty.Easy, new CustomMinePlacement(mines2));

system.RevealCell(0, 0);  // Safe first click
system.RevealCell(0, 1);  // Hit a mine!

Console.WriteLine($"Game 2 Result: {system.GameStatus}");

// Final statistics
system.PrintStatistics();
