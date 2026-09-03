using Directory = InMemoryFileSystem.Entities.Composite.Directory;
namespace InMemoryFileSystem.Entities
{
    internal class File(string name, Directory parent) : FileSystemNode(name, parent)
    {
        public string? Content { get; set; }
    }
}
