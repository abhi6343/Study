using System.Collections.Concurrent;

namespace RateLimiter.Startegy
{
    internal class FixedWindowStrategy(int maxRequests, long windowSizeInSeconds) : IRateLimitingStrategy
    {
        private readonly int maxRequests = maxRequests;
        private readonly long windowSizeInMillis = windowSizeInSeconds * 1000;
        private readonly ConcurrentDictionary<string, UserRequestInfo> userRequestMap = [];

        public bool AllowRequest(string userId)
        {
            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            userRequestMap.TryAdd(userId, new(currentTime));

            var requestInfo = userRequestMap[userId];

            lock (requestInfo)
            {
                if (currentTime - requestInfo.WindowStart >= windowSizeInMillis)
                {
                    requestInfo.Reset(currentTime);
                }

                if (requestInfo.RequestCount < maxRequests)
                {
                    requestInfo.RequestCount++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private class UserRequestInfo(long startTime)
        {
            public long WindowStart { get; set; } = startTime;
            public int RequestCount { get; set; } = 0;

            public void Reset(long newStart)
            {
                this.WindowStart = newStart;
                this.RequestCount = 0;
            }
        }
    }
}
