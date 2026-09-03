namespace URLShortener.Strategy
{
    internal interface IKeyGenerationStrategy
    {
        string GenerateKey(long id);
    }
}
