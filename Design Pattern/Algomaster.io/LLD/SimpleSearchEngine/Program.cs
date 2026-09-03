using SimpleSearchEngine;
using SimpleSearchEngine.Entities;
using SimpleSearchEngine.Strategy;

var engine = SearchEngine.Instance;

var documents = new List<Document>
    {
        new("doc1", "Java Performance", "Java is a high-performance language. Tuning Java applications is key."),
        new("doc2", "Introduction to Python", "Python is a versatile language, great for beginners."),
        new("doc3", "Advanced Java Concepts", "This document covers advanced topics in Java programming."),
        new("doc4", "Python vs. Java", "A document comparing Python and Java for web development. Java is faster.")
    };

Console.WriteLine("Indexing documents...");
engine.IndexDocuments(documents);
Console.WriteLine("Indexing complete.\n");

Console.WriteLine("====== TermFrequency Scoring + ScoreBased Ranking ======");
engine.SetScoringStrategy(new TermFrequencyScoringStrategy());
engine.SetRankingStrategy(new ScoreBasedRankingStrategy());

PerformSearch(engine, "java");
PerformSearch(engine, "language");
PerformSearch(engine, "performance");

Console.WriteLine("\n====== TitleBoost Scoring + Score-then-Alphabetical Ranking ======");
engine.SetScoringStrategy(new TitleBoostScoringStrategy());
engine.SetRankingStrategy(new ScoreThenAlphabeticalRankingStrategy());

PerformSearch(engine, "java");
PerformSearch(engine, "language");
PerformSearch(engine, "performance");

PerformSearch(engine, "paint");

static void PerformSearch(SearchEngine engine, string query)
{
    Console.WriteLine("--- Searching for: '" + query + "' ---");
    var results = engine.Search(query);

    if (results.Count == 0)
    {
        Console.WriteLine("  No results found.");
    }
    else
    {
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine("Rank " + (i + 1) + ":" + results[i]);
        }    
    }
    Console.WriteLine();
}