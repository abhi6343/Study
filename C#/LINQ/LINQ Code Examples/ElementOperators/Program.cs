namespace ElementOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3 };
            var firstNumber = numbers.First(); // returns 1
            var firstEvenNumber = numbers.Where(n => n % 2 == 0).FirstOrDefault(); // returns 2
            var singleNumber = numbers.Single(n => n == 3); // returns 3
            var thirdNumber = numbers.ElementAtOrDefault(2); // returns 3
            var fourthNumber = numbers.ElementAtOrDefault(3); // returns 0, which is the default for int
            
            Console.ReadKey();
        }
    }
}
