namespace BloomFilter.Strategies
{
    internal interface IHashStrategy
    {
        long Hash(string data);
    }
}
