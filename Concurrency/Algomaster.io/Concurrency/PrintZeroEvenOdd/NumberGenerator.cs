namespace PrintZeroEvenOdd
{
    internal static class NumberGenerator
    {
        public static IEnumerable<int> GetNumbers(this int number)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero<int>(number);
            foreach (var i in Enumerable.Range(1, number))
            {
                yield return i;
            }
        }
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? source) => source ?? [];
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
}
