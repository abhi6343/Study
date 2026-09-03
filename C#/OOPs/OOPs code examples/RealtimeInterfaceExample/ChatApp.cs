namespace RealtimeInterfaceExample
{
    //Step 3: In your chat application, implement the use of these processors.
    internal class ChatApp
    {
        private List<IMessageProcessor> messageProcessors = new List<IMessageProcessor>();
        public ChatApp()
        {
            // Add processors to the chat application
            messageProcessors.Add(new UpperCaseProcessor());
            messageProcessors.Add(new CensorshipProcessor());
        }
        public void SendMessage(string message)
        {
            foreach (var processor in messageProcessors)
            {
                message = processor.ProcessMessage(message);
            }
            Console.WriteLine("Sending Message: " + message);
            // Here, you'd typically send the message to the server or another client.
        }
    }
}
