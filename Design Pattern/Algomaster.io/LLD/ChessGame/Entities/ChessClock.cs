using ChessGame.Enums;

namespace ChessGame.Entities
{
    internal class ChessClock(long timePerPlayerMillis)
    {
        private long lastMoveTimestamp;
        private Color activeColor;

        public void StartTurn(Color color)
        {
            activeColor = color;
            lastMoveTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public void EndTurn()
        {
            long elapsed = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - lastMoveTimestamp;
            if (activeColor == Color.White)
            {
                timePerPlayerMillis -= elapsed;
            }
            else
            {
                timePerPlayerMillis -= elapsed;
            }
        }

        public bool IsTimeUp(Color color)
        {
            return (color == Color.White ? timePerPlayerMillis : timePerPlayerMillis) <= 0;
        }

        public long GetRemainingTime(Color color)
        {
            return color == Color.White ? timePerPlayerMillis : timePerPlayerMillis;
        }
    }
}
