using Directory = InMemoryFileSystem.Entities.Composite.Directory;
namespace InMemoryFileSystem.Strategies
{
    internal class DetailedListingStrategy : IListingStrategy
    {
        public void List(Directory directory)
        {
            var children = directory.GetChildren();
            foreach (var node in children.Values)
            {
                char type = (node is Directory) ? 'd' : 'f';
                Console.WriteLine($"{type}\t{node.Name}\t{node.CreatedTime}");
            }
        }
    }
}
