namespace StackOverflow.Entities
{
    internal class User(string name)
    {
        private readonly string id = Guid.NewGuid().ToString();
        private int reputation = 0;
        private readonly Lock reputationLock = new();

        public void UpdateReputation(int change)
        {
            lock (reputationLock)
            {
                reputation += change;
            }
        }

        public string Id { get { return id; } }
        public string Name { get { return name; } }
        public int Reputation
        {
            get
            {
                lock (reputationLock)
                {
                    return reputation;
                }
            }
        }
    }
}
