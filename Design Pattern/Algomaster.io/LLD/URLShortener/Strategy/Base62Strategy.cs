namespace URLShortener.Strategy
{
    internal class Base62Strategy : IKeyGenerationStrategy
    {
        private const string BASE62_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int BASE = 62;

        // This is the smallest number that will produce a 6-character Base62 string.
        // It's calculated as 62^5.
        private const long MIN_6_CHAR_ID_OFFSET = 916132832L;

        public string GenerateKey(long id)
        {
            if (id == 0)
            {
                return BASE62_CHARS[0].ToString();
            }

            var idWithOffset = id + MIN_6_CHAR_ID_OFFSET;

            List<char> result = [];
            while (idWithOffset > 0)
            {
                result.Add(BASE62_CHARS[(int)(idWithOffset % BASE)]);
                idWithOffset /= BASE;
            }

            result.Reverse();
            return new([.. result]);
        }
    }
}
