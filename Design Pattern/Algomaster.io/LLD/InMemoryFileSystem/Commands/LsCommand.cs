using InMemoryFileSystem.Singletons;
using InMemoryFileSystem.Strategies;

namespace InMemoryFileSystem.Commands
{
    internal class LsCommand(FileSystem fs, string? path, IListingStrategy strategy) : ICommand
    {
        public void Execute()
        {
            if (path == null)
            {
                fs.ListContents(strategy);
            }
            else
            {
                fs.ListContentsPath(path, strategy);
            }
        }
    }
}
