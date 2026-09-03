using System.Collections.Concurrent;
using URLShortener.Builder;

namespace URLShortener.Repository
{
    internal class InMemoryURLRepository : IURLRepository
    {
        private readonly ConcurrentDictionary<string, ShortenedURL> shortKeyToShortUrlMap = [];
        private readonly ConcurrentDictionary<string, string> longUrlToShortKeyMap = [];
        private long idCounter = 1; // Start from 1

        public void Save(ShortenedURL url)
        {
            shortKeyToShortUrlMap[url.ShortKey] = url;
            longUrlToShortKeyMap[url.LongURL] = url.ShortKey;
        }

        public ShortenedURL? FindByShortKey(string shortKey)
        {
            shortKeyToShortUrlMap.TryGetValue(shortKey, out var url);
            return url;
        }

        public string? FindKeyByLongURL(string longURL)
        {
            longUrlToShortKeyMap.TryGetValue(longURL, out var key);
            return key;
        }

        public long GetNextId()
        {
            return Interlocked.Increment(ref idCounter);
        }

        public bool ExistsByShortKey(string shortKey)
        {
            return shortKeyToShortUrlMap.ContainsKey(shortKey);
        }
    }
}
