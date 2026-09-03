using URLShortener.Builder;

namespace URLShortener.Repository
{
    internal interface IURLRepository
    {
        void Save(ShortenedURL url);
        ShortenedURL? FindByShortKey(string key);
        string? FindKeyByLongURL(string longURL);
        long GetNextId();
        bool ExistsByShortKey(string key);
    }
}
