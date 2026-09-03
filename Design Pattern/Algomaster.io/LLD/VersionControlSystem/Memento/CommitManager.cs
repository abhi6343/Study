using Directory = VersionControlSystem.Entities.Composite.Directory;
namespace VersionControlSystem.Memento
{
    internal class CommitManager
    {
        readonly Dictionary<string, Commit> commits = [];

        public Commit CreateCommit(string author, string message, Commit parent, Directory rootSnapshot)
        {
            var newCommit = new Commit(author, message, parent, rootSnapshot);
            commits[newCommit.Id] = newCommit;
            return newCommit;
        }

        public Commit GetCommit(string commitId)
        {
            if (commits.TryGetValue(commitId, out var commit))
            {
                return commit;
            }
            return default;
        }

        public static void PrintHistory(Commit headCommit)
        {
            if (headCommit == null)
            { 
                Console.WriteLine("No commits in history.");
                return;
            }

            var current = headCommit;
            while (current != null)
            {
                Console.WriteLine("Commit: " + current.Id);
                Console.WriteLine("Author: " + current.Author);
                Console.WriteLine("Date: " + current.Timestamp);
                Console.WriteLine("Message: " + current.Message);
                Console.WriteLine("--------------------");
                current = current.Parent;
            }
        }
    }
}
