// See https://aka.ms/new-console-template for more information
// --- 1. Manually define parameters ---
using BloomFilter.Enums;
using BloomFilter.Factory;
using BloomFilter.Strategies;

int bitSetSize = 10000;
int numHashFunctions = 2;
int expectedInsertions = 1000;

// --- 2. Create a list of hash strategies at runtime ---
var strategies = new List<IHashStrategy>
    {
        HashStrategyFactory.Create(HashType.FNV1A),
        HashStrategyFactory.Create(HashType.DJB2)
    };

// --- 3. Build the filter using the new Builder syntax ---
BloomFilter.Builder.BloomFilter filter = new BloomFilter.Builder.BloomFilter.Builder()
    .SetBitSetSize(bitSetSize)
    .SetNumHashFunctions(numHashFunctions)
    .AddHashStrategy(strategies)
    .Build();

// --- 4. Add elements to the filter ---
Console.WriteLine("\n--- Adding elements to the filter ---");
List<string> insertedElements = new List<string>();
for (int i = 0; i < expectedInsertions; i++)
{
    string element = "user" + i + "@example.com";
    insertedElements.Add(element);
    filter.Add(element);
}
Console.WriteLine(expectedInsertions + " elements have been added.");

// --- 5. Test for presence (no false negatives) ---
Console.WriteLine("\n--- Verifying no false negatives ---");
bool hasFalseNegatives = false;
foreach (string element in insertedElements)
{
    if (!filter.MightContain(element))
    {
        Console.Error.WriteLine("FALSE NEGATIVE DETECTED FOR: " + element);
        hasFalseNegatives = true;
        break;
    }
}
if (!hasFalseNegatives)
{
    Console.WriteLine("Success! No false negatives found. All inserted elements were detected.");
}

// --- 6. Test for false positives ---
Console.WriteLine("\n--- Testing for false positives ---");
int testSetSize = 10000;
int falsePositivesCount = 0;
for (int i = 0; i < testSetSize; i++)
{
    string randomElement = Guid.NewGuid().ToString();
    if (filter.MightContain(randomElement))
    {
        falsePositivesCount++;
    }
}
Console.WriteLine("Number of false positives found: " + falsePositivesCount + " out of " + testSetSize + " random items.");
