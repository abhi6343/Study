using Newtonsoft.Json;
using System.Diagnostics;

namespace SemaphoreSlim
{
    internal class Program
    {
        //#region Limit number of concurrent tasks
        ////Allowing Maximum 3 tasks to be executed at a time
        //static System.Threading.SemaphoreSlim semaphoreSlim = new System.Threading.SemaphoreSlim(3);
        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"Main Thread Started");
        //    //Generating 15 Credit Cards
        //    List<CreditCard> creditCards = CreditCard.GenerateCreditCards(15);
        //    Console.WriteLine($"Credit Card Generated : {creditCards.Count}");
        //    ProcessCreditCards(creditCards);
        //    Console.WriteLine($"Main Thread Completed");
        //    Console.ReadKey();
        //}
        //public static async void ProcessCreditCards(List<CreditCard> creditCards)
        //{
        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    var tasks = new List<Task<string>>();
        //    //Need to use async lambda expression
        //    tasks = creditCards.Select(async card =>
        //    {
        //        //This will tell if we have more than 4000 tasks are running,
        //        //we are going to wait until the semaphore gets released.
        //        await semaphoreSlim.WaitAsync();
        //        //Need to use await operator here as we are using asynchronous WaitAsync
        //        try
        //        {
        //            return await ProcessCard(card);
        //        }
        //        finally
        //        {
        //            //Release the semaphore
        //            semaphoreSlim.Release();
        //        }
        //    }).ToList();
        //    //It will execute a maximum of 3 tasks at a time
        //    await Task.WhenAll(tasks);
        //    stopwatch.Stop();
        //    Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in { stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        //}
        //public static async Task<string> ProcessCard(CreditCard creditCard)
        //{
        //    await Task.Delay(1000);
        //    string message = $"Credit Card Number: {creditCard.CardNumber} Name: { creditCard.Name} Processed";
        //    Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
        //    return message;
        //}
        //#endregion

        //#region Return string
        ////Allowing Maximum 3 tasks to be executed at a time
        //static System.Threading.SemaphoreSlim semaphoreSlim = new System.Threading.SemaphoreSlim(3);
        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"Main Thread Started");
        //    //Generating 15 Credit Cards
        //    List<CreditCard> creditCards = CreditCard.GenerateCreditCards(15);
        //    Console.WriteLine($"Credit Card Generated : {creditCards.Count}");

        //    ProcessCreditCards(creditCards);

        //    Console.WriteLine($"Main Thread Completed");
        //    Console.ReadKey();
        //}
        //public static async void ProcessCreditCards(List<CreditCard> creditCards)
        //{
        //    var stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    var tasks = new List<Task<string>>();
        //    //Need to use async lambda expression
        //    tasks = creditCards.Select(async (card) =>
        //    {
        //        //This will tell if we have more than 4000 tasks are running, 
        //        //we're going to wait until the semaphore gets released.
        //        await semaphoreSlim.WaitAsync();
        //        //Need to use await operator here as we are using asynchronous WaitAsync
        //        try
        //        {
        //            return await ProcessCard(card);
        //        }
        //        finally
        //        {
        //            //Release the semaphore
        //            semaphoreSlim.Release();
        //        }

        //    }).ToList();

        //    //It will execute a maximum of 3 tasks at a time
        //    //await Task.WhenAll(tasks);
        //    string[] Responses = await Task.WhenAll(tasks);
        //    //var Responses = await Task.WhenAll(tasks);
        //    foreach (var response in Responses)
        //    {
        //        Console.WriteLine(response);
        //    }
        //    stopwatch.Stop();
        //    Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        //}

        //public static async Task<string> ProcessCard(CreditCard creditCard)
        //{
        //    await Task.Delay(1000);
        //    string message = $"Credit Card Number: {creditCard.CardNumber} Name: {creditCard.Name} Processed";
        //    //Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
        //    return message;
        //}
        //#endregion

        #region Return JSON data
        //Allowing Maximum 3 tasks to be executed at a time
        static System.Threading.SemaphoreSlim semaphoreSlim = new System.Threading.SemaphoreSlim(3);
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine($"Main Thread Started");
            //Generating 15 Credit Cards
            List<CreditCard> creditCards = CreditCard.GenerateCreditCards(15);
            Console.WriteLine($"Credit Card Generated : {creditCards.Count}");
            ProcessCreditCards(creditCards);
            Console.WriteLine($"Main Thread Completed");
            Console.ReadKey();
        }
        public static async void ProcessCreditCards(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task<string>>();
            //Need to use async lambda expression
            tasks = creditCards.Select(async card =>
            {
                await semaphoreSlim.WaitAsync();
                try
                {
                    return await ProcessCard(card);
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }).ToList();
            //Return the response as string array
            var Responses = await Task.WhenAll(tasks);
            //Creating a collection to hold the responses
            List<CreditCardResponse> creditCardResponses = new List<CreditCardResponse>();
            //Looping through the string array
            foreach (var response in Responses)
            {
                //Here, the string response is a JSON string
                //Converting the JSON string to .NET object (CreditCardResponse) using
                //JsonConvert class DeserializeObject method
                CreditCardResponse creditCardResponse = JsonConvert.DeserializeObject<CreditCardResponse>(response);
                //Adding the .NET Object into the resposne collection
                creditCardResponses.Add(creditCardResponse);
            }
            //Printing all the approved credit cards using a foreach loop
            Console.WriteLine("\nApproved Credit Cards");
            foreach (var item in creditCardResponses.Where(card => card.IsProcessed == true))
            {
                Console.WriteLine($"Card Number: {item.CardNumber}, Name: {item.Name}");
            }
            //Printing all the rejected credit cards using a foreach loop
            Console.WriteLine("\nRejected Credit Cards");
            foreach (var item in creditCardResponses.Where(card => card.IsProcessed == false))
            {
                Console.WriteLine($"Card Number: {item.CardNumber}, Name: {item.Name}");
            }
        }
        public static async Task<string> ProcessCard(CreditCard creditCard)
        {
            await Task.Delay(1000);

            var creditCardResponse = new CreditCardResponse
            {
                CardNumber = creditCard.CardNumber,
                Name = creditCard.Name,
                //Logic to Decide whether the card is processed or rejected
                //If modulus 2 is 0, the processed else rejected
                IsProcessed = creditCard.CardNumber % 2 == 0 ? true : false
            };
            //Converting the .NET object to JSON string
            string jsonString = JsonConvert.SerializeObject(creditCardResponse);
            //Return the JSON string
            return jsonString;
        }
        #endregion
    }
}
