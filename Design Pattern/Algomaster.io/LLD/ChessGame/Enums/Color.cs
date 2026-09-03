namespace ChessGame.Enums
{
    internal enum Color
    {
        White,
        Black
    }
    static class ColorExtensions
    {
        public static Color Opposite(this Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }
    }
}
