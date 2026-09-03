namespace PubSubSystem.Entities
{
    internal class Message(string payload)
    {
        private readonly DateTime timestamp = DateTime.Now;

        public string Payload { get { return payload; } }

        public override string ToString()
        {
            return $"Message{{payload = '{payload}'}}";
        }
    }
}
