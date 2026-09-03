using RateLimiter.Startegy;

namespace RateLimiter.Facade
{
    internal class RateLimiterService
    {
        private static RateLimiterService? instance;
        private static readonly Lock lockObject = new();
        private IRateLimitingStrategy rateLimitingStrategy;

        private RateLimiterService() { }

        public static RateLimiterService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new RateLimiterService();
                    }
                }
                return instance;
            }
        }

        public void SetRateLimitingStrategy(IRateLimitingStrategy rateLimitingStrategy)
        {
            this.rateLimitingStrategy = rateLimitingStrategy;
        }

        public void HandleRequest(string userId)
        {
            if (rateLimitingStrategy.AllowRequest(userId))
            {
                Console.WriteLine($"Request from user {userId} is allowed");
            }
            else
            {
                Console.WriteLine($"Request from user {userId} is rejected: Rate limit exceeded");
            }
        }
    }
}
