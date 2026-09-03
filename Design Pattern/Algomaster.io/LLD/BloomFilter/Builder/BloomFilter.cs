using BloomFilter.Strategies;
using System.Collections;

namespace BloomFilter.Builder
{
    internal class BloomFilter(BloomFilter.Builder builder)
    {
        public class Builder
        {
            public int bitSetSize, numHashFunctions;
            public List<IHashStrategy> hashStrategies;
            
            public Builder SetBitSetSize(int bitSetSize)
            {
                if (bitSetSize <= 0)
                {
                    throw new ArgumentException("Bit set size must be positive.");
                }
                this.bitSetSize = bitSetSize;
                return this;
            }
            public Builder SetNumHashFunctions(int numHashFunctions)
            {
                if (numHashFunctions <= 0)
                {
                    throw new ArgumentException("Number of hash functions must be positive.");
                }
                this.numHashFunctions = numHashFunctions;
                return this;
            }
            public Builder AddHashStrategy(List<IHashStrategy> hashStrategies)
            {
                if (hashStrategies == null || hashStrategies.Count == 0)
                {
                    throw new ArgumentException("At least one hash strategy must be provided.");
                }
                this.hashStrategies = hashStrategies;
                return this;
            }
            public BloomFilter Build()
            {
                if (bitSetSize == 0 || numHashFunctions == 0 || hashStrategies == null)
                {
                    throw new InvalidOperationException("Must set bit set size, number of hash functions, and strategies.");
                }

                if (hashStrategies.Count < numHashFunctions)
                {
                    throw new InvalidOperationException("The number of provided hash strategies (" + hashStrategies.Count + ") " +
                        "must be at least equal to the number of hash functions required (" + numHashFunctions + ").");
                }

                Console.WriteLine("Creating Bloom Filter with specified parameters:");
                Console.WriteLine("  - Bit set size (m): " + bitSetSize);
                Console.WriteLine("  - Hash functions (k): " + numHashFunctions);
                return new(this);
            }
        }

        readonly BitArray bitSet = new(builder.bitSetSize);
        readonly int bitSetSize = builder.bitSetSize, numHashFunctions = builder.numHashFunctions;
        readonly List<IHashStrategy> hashStrategies = [.. builder.hashStrategies];

        public void Add(string item)
        {
            for (int i = 0; i < numHashFunctions; i++)
            {
                long hash = hashStrategies[i].Hash(item);
                int index = (int)(Math.Abs(hash) % bitSetSize);
                bitSet.Set(index, true);
            }
        }

        public bool MightContain(string item)
        {
            for (int i = 0; i < numHashFunctions; i++)
            {
                long hash = hashStrategies[i].Hash(item);
                int index = (int)(Math.Abs(hash) % bitSetSize);
                if (!bitSet.Get(index))
                {
                    return false;
                }
            }
            return true;
        }
        //public void Add(string element)
        //{
        //    lock (_lock)
        //    {
        //        for (var i = 0; i < _config.NumHashFunctions; i++)
        //        {
        //            var position = _hashStrategy.Hash(element, i, _config.BitArraySize);
        //            _bitArray.Set(position);
        //        }
        //    }
        //}

        //public bool MightContain(string element)
        //{
        //    lock (_lock)
        //    {
        //        for (var i = 0; i < _config.NumHashFunctions; i++)
        //        {
        //            var position = _hashStrategy.Hash(element, i, _config.BitArraySize);
        //            if (!_bitArray.Get(position))
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //}
    }
}
