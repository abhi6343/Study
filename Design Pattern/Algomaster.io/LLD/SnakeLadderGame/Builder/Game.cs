using SnakeLadderGame.Entities;
using SnakeLadderGame.Entities.BoardEntities;
using SnakeLadderGame.Enums;

namespace SnakeLadderGame.Builder
{
    internal class Game
    {
        public class Builder
        {
            Board board;
            readonly Queue<Player> players = [];
            Dice dice;

            public Builder CreateBoard(int boardSize, IList<BoardEntity> boardEntities)
            {
                board = new(boardSize, boardEntities);
                return this;
            }
            public Builder SetPlayers(List<string> playerNames)
            {
                foreach (var name in playerNames)
                {
                    players.Enqueue(new(name));
                }
                return this;
            }
            public Builder SetDice(Dice dice)
            {
                this.dice = dice;
                return this;
            }
            public Game Build()
            {
                if(board == null || players == null || dice == null)
                {
                    throw new InvalidOperationException("Board, Players, and Dice must be set.");
                }
                return new(this);                
            }
            public Board Board => board;
            public Queue<Player> Players => players;
            public Dice Dice => dice;
        }

        readonly Dice dice;
        readonly Board board;
        readonly Queue<Player> players;
        GameStatus status;
        Player winner;

        public Game(Builder builder)
        {
            dice = builder.Dice;
            board = builder.Board;
            players = builder.Players;
            status = GameStatus.NOT_STARTED;
            winner = null;
        }

        public void Play()
        {
            if(players.Count < 2)
            {
                Console.WriteLine("Cannot start game. At least 2 players are required.");
                return;
            }

            status = GameStatus.RUNNING;
            Console.WriteLine("Game started!");

            while(status == GameStatus.RUNNING)
            {
                var currentPlayer = players.Dequeue();
                
                TakeTurn(currentPlayer);

                if (status == GameStatus.RUNNING)
                {
                    players.Enqueue(currentPlayer);
                }
            }

            Console.WriteLine("Game Finished!");
            if (winner != null)
            {
                Console.WriteLine("The winner is " + winner.Name + "!");
            }
        }
        public void TakeTurn(Player player)
        {
            int roll = dice.Roll();
            Console.WriteLine();
            Console.WriteLine(player.Name + "'s turn. Rolled a " + roll + ".");
            int nextPosition = player.Position + roll;

            if (nextPosition > board.Size)
            {
                Console.WriteLine("Oops, " + player.Name + " needs to land exactly on " + board.Size + ". Turn skipped.");
                return;
            }
            else if (nextPosition == board.Size)
            {
                player.Position = board.Size;
                status = GameStatus.FINISHED;
                winner = player;
                Console.WriteLine("Hooray! " + player.Name + " reached the final square " + board.Size + " and won!");
                return;
            }
            
            int finalPosition = board.GetFinalPosition(nextPosition);
            if(finalPosition > nextPosition)
            {
                Console.WriteLine("Wow! " + player.Name + " found a ladder 🪜 at " + nextPosition + " and climbed to " + finalPosition + ".");
            }
            else if(finalPosition < nextPosition)
            {
                Console.WriteLine("Oh no! " + player.Name + " was bitten by a snake 🐍 at " + nextPosition + " and slid down to " + finalPosition + ".");
            }
            else
            {
                Console.WriteLine(player.Name + " moved from " + player.Position + " to " + finalPosition + ".");
            }

            player.Position = finalPosition;

            if (roll == 6)
            {
                Console.WriteLine(player.Name + " rolled a 6 and gets another turn!");
                TakeTurn(player);
            }
        }
    }
}
