using MinesweeperGame.Enums;

namespace MinesweeperGame.Extensions
{
    internal static class DifficultyExtensions
    {
        public static int GetRows(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => 9,
                Difficulty.Medium => 16,
                Difficulty.Hard => 30,
                Difficulty.Expert => 24,  // New!
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty))
            };
        }

        public static int GetCols(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => 9,
                Difficulty.Medium => 16,
                Difficulty.Hard => 16,
                Difficulty.Expert => 30,  // New!
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty))
            };
        }

        public static int GetMineCount(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => 10,
                Difficulty.Medium => 40,
                Difficulty.Hard => 99,
                Difficulty.Expert => 130,  // New!
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty))
            };
        }
    }
}
