using System.Collections.Concurrent;

namespace RateLimiter.Startegy
{
    internal class TokenBucketStrategy(int capacity, int refillRatePerSecond) : IRateLimitingStrategy
    {
        private readonly ConcurrentDictionary<string, TokenBucket> userBuckets = [];

        public bool AllowRequest(string userId)
        {
            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            userBuckets.TryAdd(userId, new(capacity, refillRatePerSecond, currentTime));
            var bucket = userBuckets[userId];

            lock (bucket)
            {
                bucket.Refill(currentTime);
                if (bucket.Tokens > 0)
                {
                    bucket.Tokens--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private class TokenBucket(int capacity, int refillRatePerSecond, long currentTimeMillis)
        {
            public int Tokens { get; set; } = capacity;
            public int Capacity { get; } = capacity;
            public int RefillRatePerSecond { get; } = refillRatePerSecond;
            public long LastRefillTimestamp { get; set; } = currentTimeMillis;

            public void Refill(long currentTime)
            {
                var elapsedTime = currentTime - LastRefillTimestamp;
                var tokensToAdd = (int)((elapsedTime / 1000.0) * RefillRatePerSecond);

                if (tokensToAdd > 0)
                {
                    Tokens = Math.Min(Capacity, Tokens + tokensToAdd);
                    LastRefillTimestamp = currentTime;
                }
            }
        }
    }
}
