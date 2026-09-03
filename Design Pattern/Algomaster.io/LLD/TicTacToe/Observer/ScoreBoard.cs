using System.Collections.Concurrent;
using TicTacToe.Entities;

namespace TicTacToe.Observer
{
    internal class ScoreBoard : IGameObserver
    {
        readonly ConcurrentDictionary<string, int> scores = [];        

        public void Update(Game game)
        {
            if (game.Winner != null)
            {
                scores.AddOrUpdate(game.Winner.Name, 1, (key, value) => value + 1);
                Console.WriteLine("[Scoreboard] " + game.Winner.Name + " (" + game.Winner.Symbol + ")" + " wins! Their new score is " + scores[game.Winner.Name] + ".");
            }
        }

        public void PrintScoreBoard()
        {
            Console.WriteLine("\n--- Overall Scoreboard ---");
            if (scores.IsEmpty)
            {
                Console.WriteLine("No games with a winner have been played yet.");
                return;
            }

            foreach (var kvp in scores)
            {
                Console.WriteLine("Player: " + kvp.Key + " | Wins: " + kvp.Value);
            }
            Console.WriteLine("--------------------------\n");
        }
    }
}
