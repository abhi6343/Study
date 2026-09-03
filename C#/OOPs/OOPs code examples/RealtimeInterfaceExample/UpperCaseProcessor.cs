namespace RealtimeInterfaceExample
{
    //Step 2: Create some implementations of the interface.
    // UpperCaseProcessor.cs
    internal class UpperCaseProcessor : IMessageProcessor
    {
        public string ProcessMessage(string input)
        {
            return input.ToUpper();
        }
    }
}
