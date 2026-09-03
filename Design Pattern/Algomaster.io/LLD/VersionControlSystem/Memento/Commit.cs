using Directory = VersionControlSystem.Entities.Composite.Directory;
namespace VersionControlSystem.Memento
{
    internal class Commit(string author, string message, Commit parent, Directory rootSnapshot)
    {
        readonly string id = Guid.NewGuid().ToString()[..8];
        readonly DateTime timestamp = DateTime.Now;

        public string Id => id;
        public string Message => message;
        public string Author => author;
        public DateTime Timestamp => timestamp;
        public Commit Parent => parent;
        public Directory RootSnapshot => rootSnapshot;
    }
}
