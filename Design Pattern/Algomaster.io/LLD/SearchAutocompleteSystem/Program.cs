// See https://aka.ms/new-console-template for more information
using SearchAutocompleteSystem.Builder;
using SearchAutocompleteSystem.Strategy;

Console.WriteLine("----------- SCENARIO 1: Frequency-based Ranking -----------");

// 1. Build the system with the default frequency-based strategy
var systemByFrequency = new AutocompleteSystemBuilder()
        .WithMaxSuggestions(5)        
        .Build();

// 2. Feed data into the system
// 'canada' is added most frequently, followed by 'car'
IEnumerable<string> dictionary = ["car", "cat", "cart", "cartoon", "canada", "candy", "car", "canada", "canada", "car", "canada", "canopy", "captain" ];
systemByFrequency.InsertWords(dictionary);

// 3. Get suggestions for a prefix
string prefix1 = "ca";
var suggestions1 = systemByFrequency.GetSuggestions(prefix1);
Console.WriteLine($"Suggestions for '{prefix1}': [{string.Join(", ", suggestions1)}]");

string prefix2 = "car";
var suggestions2 = systemByFrequency.GetSuggestions(prefix2);
Console.WriteLine($"Suggestions for '{prefix2}': [{string.Join(", ", suggestions2)}]");

Console.WriteLine("\n----------- SCENARIO 2: Alphabetical Ranking -----------");

// 1. Build a new system with the alphabetical strategy
var systemAlphabetical = new AutocompleteSystemBuilder()
        .WithRankingStrategy(new AlphabeticalRanking())
        .Build();

// 2. Feed the same data
systemAlphabetical.InsertWords(dictionary);

// 3. Get suggestions for the same prefix
var suggestions3 = systemAlphabetical.GetSuggestions(prefix1);
Console.WriteLine($"Suggestions for '{prefix1}' (alphabetical): [{string.Join(", ", suggestions3)}]");
