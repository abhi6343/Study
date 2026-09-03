// See https://aka.ms/new-console-template for more information
using LRUCache;

LRUCache<string, int> cache = new(3);

cache.Put("a", 1);
cache.Put("b", 2);
cache.Put("c", 3);

// Accessing 'a' makes it the most recently used
Console.WriteLine(cache.GetV("a")); // 1

// Adding 'd' will cause 'b' (the current LRU item) to be evicted
cache.Put("d", 4);

// Trying to get 'b' should now return null
Console.WriteLine(cache.GetV("b")); // 0 (default for int when null)
