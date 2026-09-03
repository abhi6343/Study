using System.Diagnostics;

namespace MultipleTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine($"Main Thread Started");
            List<CreditCard> creditCards = CreditCard.GenerateCreditCards(100000);
            Console.WriteLine($"Credit Card Generated : {creditCards.Count}");
            ProcessCreditCards(creditCards);
            Console.WriteLine($"Main Thread Completed");
            stopwatch.Stop();
            Console.WriteLine($"Main Thread Execution Time { stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
            Console.ReadKey();
        }
        public static async void ProcessCreditCards(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var tasks = new List<Task<string>>();
            //await Task.Run(() =>
            //{

                foreach (var creditCard in creditCards)
                {
                    var response = ProcessCard(creditCard);
                    tasks.Add(response);
                }

            //});
            //It will execute all the tasks concurrently
            await Task.WhenAll(tasks);


            //foreach (var creditCard in creditCards)
            //{
            //    var response = await ProcessCard(creditCard);
            //}

            stopwatch.Stop();
            Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }
        public static async Task<string> ProcessCard(CreditCard creditCard)
        {
            await Task.Delay(1000);
            string message = $"Credit Card Number: {creditCard.CardNumber} Name: {creditCard.Name} Processed";
            //Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
            return message;
        }
    }
}
