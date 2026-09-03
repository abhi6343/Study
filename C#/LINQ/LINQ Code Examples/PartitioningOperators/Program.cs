namespace PartitioningOperators
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Take the first 5 numbers
            IEnumerable<int> firstFive = numbers.Take(5);

            // Take numbers while they are less than 6
            IEnumerable<int> lessThanSix = numbers.TakeWhile(n => n < 6);

            // Skip the first 5 numbers
            IEnumerable<int> skipFirstFive = numbers.Skip(5);

            // Skip numbers while they are less than 6
            IEnumerable<int> skipLessThanSix = numbers.SkipWhile(n => n < 6);

            // Display the results
            Console.WriteLine("First Five: " + string.Join(", ", firstFive));
            Console.WriteLine("Less Than Six: " + string.Join(", ", lessThanSix));
            Console.WriteLine("Skip First Five: " + string.Join(", ", skipFirstFive));
            Console.WriteLine("Skip Less Than Six: " + string.Join(", ", skipLessThanSix));
            Console.ReadKey();
        }
    }
}
