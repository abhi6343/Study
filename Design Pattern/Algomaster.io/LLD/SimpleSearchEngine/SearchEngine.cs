using SimpleSearchEngine.Entities;
using SimpleSearchEngine.Strategy;
using System.Text.RegularExpressions;

namespace SimpleSearchEngine
{
    internal class SearchEngine
    {
        private static SearchEngine? instance;
        private readonly InvertedIndex invertedIndex = new();
        private readonly DocumentStore documentStore = new();
        private IScoringStrategy scoringStrategy;
        private IRankingStrategy rankingStrategy;

        private SearchEngine() { }

        public static SearchEngine Instance
        {
            get
            {
                instance ??= new SearchEngine();
                return instance;
            }
        }

        public void SetScoringStrategy(IScoringStrategy scoringStrategy)
        {
            this.scoringStrategy = scoringStrategy;
        }

        public void SetRankingStrategy(IRankingStrategy rankingStrategy)
        {
            this.rankingStrategy = rankingStrategy;
        }

        public void IndexDocuments(List<Document> documents)
        {
            foreach (var doc in documents)
            {
                IndexDocument(doc);
            }
        }

        public void IndexDocument(Document doc)
        {
            documentStore.AddDocument(doc);
            var termFrequencies = new Dictionary<string, int>();

            var text = (doc.Title + " " + doc.Content).ToLower();
            var tokens = Regex.Split(text, @"\W+");

            foreach (var token in tokens)
            {
                if (!string.IsNullOrEmpty(token))
                {
                    if (termFrequencies.TryGetValue(token, out int value))
                    {
                        termFrequencies[token] = ++value;
                    }
                    else
                    {
                        termFrequencies[token] = 1;
                    }
                }
            }

            foreach (var entry in termFrequencies)
            {
                invertedIndex.Add(entry.Key, doc.Id, entry.Value);
            }
        }

        public List<SearchResult> Search(string query)
        {
            var processedQuery = query.ToLower();

            var postings = invertedIndex.GetPostings(processedQuery);

            var results = new List<SearchResult>();
            foreach (var posting in postings)
            {
                var doc = documentStore.GetDocument(posting.DocumentId);
                if (doc != null)
                {
                    double score = scoringStrategy.CalculateScore(processedQuery, posting, doc);
                    results.Add(new(doc, score));
                }
            }

            rankingStrategy.Rank(results);

            return results;
        }
    }
}
