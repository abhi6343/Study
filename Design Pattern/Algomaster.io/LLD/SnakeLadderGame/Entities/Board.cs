using SnakeLadderGame.Entities.BoardEntities;

namespace SnakeLadderGame.Entities
{
    internal class Board
    {
        readonly int size;
        readonly Dictionary<int, int> snakesAndLadders = [];
        
        public Board(int size, IList<BoardEntity> entities)
        {
            this.size = size;
            foreach(var entity in entities)
            {
                snakesAndLadders[entity.Start] = entity.End;
            }
        }
        public int GetFinalPosition(int position)
        {
            if (snakesAndLadders.TryGetValue(position, out var value))
            {
                return value;
            }
            return position; 
        }
        public int Size => size;
    }
}
