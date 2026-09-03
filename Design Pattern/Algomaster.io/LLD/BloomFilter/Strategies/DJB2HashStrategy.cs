using System.Text;

namespace BloomFilter.Strategies
{
    internal class DJB2HashStrategy : IHashStrategy
    {
        public long Hash(string data)
        {
            long hash = 5381L;
            foreach (var b in Encoding.UTF8.GetBytes(data))
            {
                hash = ((hash << 5) + hash) + b;
            }
            return hash;
        }
    }
}
