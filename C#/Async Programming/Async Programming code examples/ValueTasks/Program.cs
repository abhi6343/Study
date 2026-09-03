namespace ValueTasks
{
    internal class Program
    {
        public static Dictionary<int, string> cardDictionary = new()
        {
            { 1001, "1001 Card Info" },
            { 1002, "1002 Card Info" },
            { 1003, "1003 Card Info" },
            { 1004, "1004 Card Info" }
        };
        static void Main(string[] args)
        {
            //Synchronous Call
            var Card1001Result = GetCreditCard(1001);
            Console.WriteLine(Card1001Result);
            //Synchronous Call
            var Card1002Result = GetCreditCard(1002);
            Console.WriteLine(Card1002Result);
            //Asynchronous Call
            var Card1006Result = GetCreditCard(1006);
            Console.WriteLine(Card1006Result);
            Console.ReadKey();
        }
        public static async ValueTask<string> GetCreditCard(int Id)
        {
            if (cardDictionary.TryGetValue(Id, out var value))
            {
                //We return synchronously if we have the cards info in the dictionary
                return value;
            }
            //If not available in the dicitonary, look for the card info in the database
            //asynchronous operation
            var card = $"Card Info - {Id} From Database";
            cardDictionary[Id] = card;
            return await Task.FromResult(card);
        }
    }
}
