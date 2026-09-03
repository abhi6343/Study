using System.Text;

namespace BloomFilter.Strategies
{
    internal class FNV1aHashStrategy : IHashStrategy
    {
        private const ulong FNV_PRIME = 0x100000001b3;
        private const ulong FNV_OFFSET_BASIS = 0xcbf29ce484222325;

        public long Hash(string data)
        {
            ulong hash = FNV_OFFSET_BASIS;
            foreach (var b in Encoding.UTF8.GetBytes(data))
            {
                hash ^= b;
                hash *= FNV_PRIME;
            }
            return (long)hash;
        }
    }
}
