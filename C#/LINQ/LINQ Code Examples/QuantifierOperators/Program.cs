namespace QuantifierOperators
{
    internal class Program
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            bool anyGreaterThanThree = numbers.Any(x => x > 3); // true, as at least one element is greater than 3
            bool anyEven = numbers.Any(x => x % 2 == 0); // true, as there are even numbers in the collection

            bool allGreaterThanZero = numbers.All(x => x > 0); // true, as all are greater than 0
            bool allEven = numbers.All(x => x % 2 == 0); // false, as not all are even

            bool containsFive = numbers.Contains(5); // checks if the sequence contains the number 5

            Console.ReadKey();
        }
    }
}
