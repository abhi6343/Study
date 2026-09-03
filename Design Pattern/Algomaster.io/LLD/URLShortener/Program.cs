using URLShortener.Facade;
using URLShortener.Observer;
using URLShortener.Repository;
using URLShortener.Strategy;

// --- 1. Setup Phase ---
// Get the Singleton instance of our service
var shortener = URLShortenerService.Instance;

// Configure the service with the chosen strategy and repository
shortener.Configure("http://short.ly/", new InMemoryURLRepository(), new RandomStrategy());
shortener.AddObserver(new AnalyticsService());

Console.WriteLine("--- URL Shortener Service Initialized ---\n");

// --- 2. Usage Phase ---
var originalUrl1 = "https://www.verylongurl.com/with/lots/of/path/segments/and/query/params?id=123&user=test";
Console.WriteLine("Shortening: " + originalUrl1);
var shortUrl1 = shortener.Shorten(originalUrl1);
Console.WriteLine("Generated Short URL: " + shortUrl1);
Console.WriteLine();

// Shorten the same URL again
Console.WriteLine("Shortening the same URL again...");
var shortUrl2 = shortener.Shorten(originalUrl1);
Console.WriteLine("Generated Short URL: " + shortUrl2);
if (shortUrl1.Equals(shortUrl2))
{
    Console.WriteLine("SUCCESS: The system correctly returned the existing short URL.\n");
}

// Shorten a different URL
var originalUrl2 = "https://www.anotherdomain.com/page.html";
Console.WriteLine("Shortening: " + originalUrl2);
var shortUrl3 = shortener.Shorten(originalUrl2);
Console.WriteLine("Generated Short URL: " + shortUrl3);
Console.WriteLine();

// --- 3. Resolution Phase ---
Console.WriteLine("--- Resolving and Tracking Clicks ---");

// Resolve the first URL multiple times
ResolveAndPrint(shortener, shortUrl1);
ResolveAndPrint(shortener, shortUrl1);
ResolveAndPrint(shortener, shortUrl3);

// Try to resolve a non-existent URL
Console.WriteLine("\nResolving a non-existent URL...");
ResolveAndPrint(shortener, "http://short.ly/nonexistent");

static void ResolveAndPrint(URLShortenerService shortener, string shortUrl)
{
    var resolvedUrl = shortener.Resolve(shortUrl);
    if (!string.IsNullOrEmpty(resolvedUrl))
    {
        Console.WriteLine($"Resolved {shortUrl} -> {resolvedUrl}");
    }
    else
    {
        Console.WriteLine($"No original URL found for {shortUrl}");
    }
}