namespace RealtimeInterfaceExample
{
    // CensorshipProcessor.cs
    internal class CensorshipProcessor : IMessageProcessor
    {
        private string[] forbiddenWords = { "badword1", "badword2" };  // Example censored words
        public string ProcessMessage(string input)
        {
            foreach (var word in forbiddenWords)
            {
                input = input.Replace(word, "****");
            }
            return input;
        }
    }
}
