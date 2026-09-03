using System.Collections.Concurrent;

namespace InMemoryFileSystem.Entities.Composite
{
    internal class Directory(string name, Directory parent) : FileSystemNode(name, parent)
    {
        readonly ConcurrentDictionary<string, FileSystemNode> children = new();

        public void AddChild(FileSystemNode node)
        {
            children[node.Name] = node;
        }

        public Dictionary<string, FileSystemNode> GetChildren()
        {
            return new(children);
        }

        public FileSystemNode GetChild(string name)
        {
            if (children.TryGetValue(name, out var node)) {
                return node;
            }
            return default;
        }
    }
}
