namespace RateLimiter.Startegy
{
    internal interface IRateLimitingStrategy
    {
        bool AllowRequest(string userId);
    }
}
