using BloomFilter.Enums;
using BloomFilter.Strategies;

namespace BloomFilter.Factory
{
    internal class HashStrategyFactory
    {
        public static IHashStrategy Create(HashType hashType)
        {
            return hashType switch
            {
                HashType.FNV1A => new FNV1aHashStrategy(),
                HashType.DJB2 => new DJB2HashStrategy(),
                _ => throw new ArgumentException("Unsupported hash type: " + hashType),
            };
        }
    }
}
