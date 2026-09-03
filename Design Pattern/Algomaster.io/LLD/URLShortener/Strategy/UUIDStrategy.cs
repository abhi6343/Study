namespace URLShortener.Strategy
{
    internal class UUIDStrategy : IKeyGenerationStrategy
    {
        private const int KEY_LENGTH = 6;

        public string GenerateKey(long id)
        {
            // Generate a new UUID, remove the hyphens, and take a substring.
            string uuid = Guid.NewGuid().ToString().Replace("-", "");
            // Return the first part of the UUID.
            return uuid[..KEY_LENGTH];
        }
    }
}
