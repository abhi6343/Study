using URLShortener.Builder;
using URLShortener.Enums;

namespace URLShortener.Observer
{
    internal interface IObserver
    {
        void Update(EventType type, ShortenedURL? url);
    }
}
