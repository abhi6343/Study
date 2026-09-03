namespace URLShortener.Strategy
{
    internal class RandomStrategy : IKeyGenerationStrategy
    {
        private const string CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int KEY_LENGTH = 6;
        private readonly Random random = new();

        public string GenerateKey(long id)
        {
            var result = new char[KEY_LENGTH];
            for (int i = 0; i < KEY_LENGTH; i++)
            {
                result[i] = CHARACTERS[random.Next(CHARACTERS.Length)];
            }
            return new(result);
        }
    }
}
