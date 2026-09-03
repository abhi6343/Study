using System.Collections.Concurrent;
using URLShortener.Builder;
using URLShortener.Enums;

namespace URLShortener.Observer
{
    internal class AnalyticsService : IObserver
    {
        private readonly ConcurrentDictionary<string, long> clickCounts = [];

        public void Update(EventType type, ShortenedURL? url)
        {
            if (url is null)
            {
                Console.WriteLine("[Analytics] Received null ShortenedURL.");
                return;
            }

            switch (type)
            {
                case EventType.URL_CREATED:
                    clickCounts[url.ShortKey] = 0;
                    Console.WriteLine($"[Analytics] URL Created: Key={url.ShortKey}, Original={url.LongURL}");
                    break;
                case EventType.URL_ACCESSED:
                    long count = clickCounts.AddOrUpdate(url.ShortKey, 1, (key, oldValue) => oldValue + 1);
                    Console.WriteLine($"[Analytics] URL Accessed: Key={url.ShortKey}, Clicks={count}");
                    break;
            }
        }
    }
}
