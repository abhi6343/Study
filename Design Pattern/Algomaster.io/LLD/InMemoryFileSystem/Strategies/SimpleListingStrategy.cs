using Directory = InMemoryFileSystem.Entities.Composite.Directory;
namespace InMemoryFileSystem.Strategies
{
    internal class SimpleListingStrategy : IListingStrategy
    {
        public void List(Directory directory)
        {
            var children = directory.GetChildren();
            foreach (var name in children.Keys)
            {
                Console.Write(name + "  ");
            }
            Console.WriteLine();
        }
    }
}
