using RateLimiter.Facade;
using RateLimiter.Startegy;

var userId = "user123";

Console.WriteLine("=== Fixed Window Demo ===");
RunFixedWindowDemo(userId);

Console.WriteLine("\n=== Token Bucket Demo ===");
RunTokenBucketDemo(userId);
    

static void RunFixedWindowDemo(string userId)
{
    int maxRequests = 5;
    int windowSeconds = 10;

    IRateLimitingStrategy rateLimiter = new FixedWindowStrategy(maxRequests, windowSeconds);
    var service = RateLimiterService.Instance;
    service.SetRateLimitingStrategy(rateLimiter);

    ICollection<Task> tasks = [];

    for (var i = 0; i < 10; i++)
    {
        tasks.Add(Task.Run(() => service.HandleRequest(userId)));
        try
        {
            Thread.Sleep(500);
        }
        catch (ThreadInterruptedException)
        {
            Thread.CurrentThread.Interrupt();
        }
    }

    Task.WaitAll([.. tasks]);
}

static void RunTokenBucketDemo(string userId)
{
    int capacity = 5;
    int refillRate = 1; // 1 token per second

    IRateLimitingStrategy tokenBucketLimiter = new TokenBucketStrategy(capacity, refillRate);
    var service = RateLimiterService.Instance;
    service.SetRateLimitingStrategy(tokenBucketLimiter);

    ICollection<Task> tasks = [];

    // Simulate 10 rapid requests
    for (var i = 0; i < 10; i++)
    {
        tasks.Add(Task.Run(() => service.HandleRequest(userId)));
        try
        {
            Thread.Sleep(300); // faster than refill rate
        }
        catch (ThreadInterruptedException)
        {
            Thread.CurrentThread.Interrupt();
        }
    }

    Task.WaitAll([.. tasks]);
}