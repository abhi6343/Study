namespace VersionControlSystem.Entities
{
    internal abstract class FileSystemNode(string name)
    {
        public string Name => name;

        public abstract FileSystemNode Clone();

        public abstract void Print(string indent);
    }
}
