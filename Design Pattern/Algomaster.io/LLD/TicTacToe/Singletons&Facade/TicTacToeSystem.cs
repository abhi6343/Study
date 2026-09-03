using TicTacToe.Entities;
using TicTacToe.Exceptions;
using TicTacToe.Observer;

namespace TicTacToe.SingletonsAndFacade
{
    internal class TicTacToeSystem
    {
        readonly ScoreBoard scoreBoard = new();
        Game game;
        static volatile TicTacToeSystem instance;
        static readonly Lock lockObj = new();
        TicTacToeSystem() { }

        public static TicTacToeSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        instance ??= new();
                    }
                }
                return instance; 
            }
        }

        public void StartNewGame(Player p1, Player p2)
        {
            game = new(p1, p2);
            game.Attach(scoreBoard);
            Console.WriteLine("Game started between " + p1.Name + " (X) and " + p2.Name + " (O).");
        }
        public void MakeMove(Player player, int row, int col)
        {
            if (game == null)
            {
                Console.WriteLine("No game in progress. Please create a game first.");
                return;
            }

            try
            {
                Console.WriteLine(player.Name + " plays at (" + row + ", " + col + ")");
                game.HandleMove(player, row, col);
                PrintBoard();
                
                if (game.Winner != null)
                {
                    Console.WriteLine("Winner: " + game.Winner.Name);
                }
            }
            catch (InvalidMoveException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void PrintBoard() => game.Board.PrintBoard();
        public void PrintScoreBoard() => scoreBoard.PrintScoreBoard();
    }
}
