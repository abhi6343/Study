using URLShortener.Builder;
using URLShortener.Enums;
using URLShortener.Observer;
using URLShortener.Repository;
using URLShortener.Strategy;

namespace URLShortener.Facade
{
    internal class URLShortenerService
    {
        private static URLShortenerService? instance;
        private static readonly Lock lockObject = new();

        private IURLRepository urlRepository;
        private IKeyGenerationStrategy keyGenerationStrategy;
        private string domain;
        private const int MAX_RETRIES = 10;
        private readonly List<IObserver> observers = [];

        private URLShortenerService() { }

        public static URLShortenerService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new();
                    }
                }
                return instance; 
            }
        }

        public void Configure(string domain, IURLRepository repository, IKeyGenerationStrategy strategy)
        {
            this.domain = domain;
            this.urlRepository = repository;
            this.keyGenerationStrategy = strategy;
        }

        public string Shorten(string longURL)
        {
            // Check if we've already shortened this URL
            var existingKey = urlRepository.FindKeyByLongURL(longURL);
            if (!string.IsNullOrEmpty(existingKey))
            {
                return domain + existingKey;
            }

            // Generate a new key, handling potential collisions
            var shortKey = GenerateUniqueKey();

            var shortenedURL = new ShortenedURL.Builder(longURL, shortKey).Build();
            urlRepository.Save(shortenedURL);

            NotifyObservers(EventType.URL_CREATED, shortenedURL);

            return domain + shortKey;
        }

        private string GenerateUniqueKey()
        {
            for (var i = 0; i < MAX_RETRIES; i++)
            {
                // The ID is passed but may be ignored by some strategies (like random)
                var potentialKey = keyGenerationStrategy.GenerateKey(urlRepository.GetNextId());
                if (!urlRepository.ExistsByShortKey(potentialKey))
                {
                    return potentialKey; // Found a unique key
                }
            }
            // If we reach here, we failed to generate a unique key after several attempts.
            throw new InvalidOperationException($"Failed to generate a unique short key after {MAX_RETRIES} attempts.");
        }

        public string? Resolve(string shortURL)
        {
            if (!shortURL.StartsWith(domain))
            {
                return null;
            }
            var shortKey = shortURL.Replace(domain, "");

            if (urlRepository.ExistsByShortKey(shortKey))
            {
                var shortenedURL = urlRepository.FindByShortKey(shortKey);
                NotifyObservers(EventType.URL_ACCESSED, shortenedURL);
                return shortKey;
            }

            return null;
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(EventType type, ShortenedURL? url)
        {
            foreach (var observer in observers)
            {
                observer.Update(type, url);
            }
        }
    }
}
