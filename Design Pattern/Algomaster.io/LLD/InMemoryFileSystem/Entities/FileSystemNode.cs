using Directory = InMemoryFileSystem.Entities.Composite.Directory;
namespace InMemoryFileSystem.Entities
{
    internal class FileSystemNode(string name, Directory parent)
    {
        protected string name = name;
        protected Directory parent = parent;
        protected DateTime createdTime = DateTime.Now;

        public string GetPath()
        {
            if (parent == null) // This is the root directory
            {
                return name;
            }
            // Avoid double slash for root's children
            if (parent.Parent == null)
            {
                return parent.GetPath() + name;
            }
            return parent.GetPath() + "/" + name;
        }

        public string Name => name;
        public void SetName(string name) { this.name = name; }
        public Directory Parent => parent;
        public DateTime CreatedTime => createdTime;
    }
}
