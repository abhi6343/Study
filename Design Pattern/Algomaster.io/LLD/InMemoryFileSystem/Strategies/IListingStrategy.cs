using Directory = InMemoryFileSystem.Entities.Composite.Directory;
namespace InMemoryFileSystem.Strategies
{
    internal interface IListingStrategy
    {
        void List(Directory directory);
    }
}
