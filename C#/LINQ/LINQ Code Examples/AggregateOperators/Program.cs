using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AggregateOperators
{
    internal class Program
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            int countEven = numbers.Count(x => x % 2 == 0); // 2
            Console.WriteLine($"Event Number Count: {countEven}");

            var expenses = new List<double> { 100.50, 75.25, 50.0, 30.75 };
            double totalExpenses = expenses.Sum(); // 256.5
            Console.WriteLine($"Total Expenses: {totalExpenses}");

            var temperatures = new List<int> { 10, 5, 15, 0, -5 };
            int minTemperature = temperatures.Min(); // -5
            Console.WriteLine($"Min Temperature: {minTemperature}");

            var prices = new List<decimal> { 25.99m, 15.49m, 30.0m, 10.25m };
            decimal maxPrice = prices.Max(); // 30.0
            Console.WriteLine($"Max Price: {maxPrice}");

            var scores = new List<double> { 85.5, 92.0, 78.25, 95.75 };
            double averageScore = scores.Average(); // 87.625
            Console.WriteLine($"Average Score: {averageScore}");

            var nums = new List<int> { 1, 2, 3, 4, 5 };
            int product = numbers.Aggregate((accumulator, number) => accumulator * number);
            //Return 120 => 1 * 2 * 3 * 4 * 5
            Console.WriteLine($"Aggregate: {product}");

            Console.ReadKey();
        }
    }
}
