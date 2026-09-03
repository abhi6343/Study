using TicTacToe.Observer;
using TicTacToe.State;
using TicTacToe.Strategies;

namespace TicTacToe.Entities
{
    internal class Game : GameSubject
    {
        readonly Board board;
        readonly Player p1, p2;
        Player winner, currentPlayer;
        readonly List<IWinStrategy> winStrategies;
        public IGameState State { get; set; }
        public Player Winner { get { return winner; } }

        public Game(Player p1, Player p2)
        {
            board = new Board(3);
            this.p1 = p1;
            this.p2 = p2;
            currentPlayer = p1;
            winner = null;

            winStrategies =
            [
                new RowWinStrategy(),
                new ColumnWinStrategy(),
                new DiagonalWinStrategy()
            ];
            State = new InProgressState();
        }
        public void SwitchPlayer() => currentPlayer = currentPlayer == p1 ? p2 : p1;
        
        public void HandleMove(Player p, int row, int col)
        {
            State.Move(this, p, row, col);
        }

        public bool CheckWinner(Player p)
        {
            foreach (var strategy in winStrategies)
            {
                if (strategy.CheckWinner(board, p))
                {                    
                    return true;
                }
            }            
            return false;
        }
        public void SetWinner(Player p)
        {
            winner = p;
            NotifyObservers();
        }
        public Board Board => board;
        public Player CurrentPlayer => currentPlayer;
    }
}
