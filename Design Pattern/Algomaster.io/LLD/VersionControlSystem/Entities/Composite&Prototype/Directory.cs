namespace VersionControlSystem.Entities.Composite
{
    internal class Directory(string name) : FileSystemNode(name)
    {
        readonly Dictionary<string, FileSystemNode> children = [];

        public void AddChild(FileSystemNode node)
        {
            children[node.Name] = node;
        }

        public FileSystemNode GetChild(string name)
        {
            if (children.TryGetValue(name, out var node))
            {
                return node;
            }
            return default;
        }

        public Dictionary<string, FileSystemNode> Children => children;

        public override FileSystemNode Clone()
        {
            var newDir = new Directory(Name);
            foreach (var child in children.Values)
            {
                newDir.AddChild(child.Clone());
            }
            return newDir;
        }

        public override void Print(string indent)
        {
            Console.WriteLine(indent + "+ " + Name + " (Directory)");
            foreach (var child in children.Values)
            {
                child.Print(indent + "  ");
            }
        }
    }
}
