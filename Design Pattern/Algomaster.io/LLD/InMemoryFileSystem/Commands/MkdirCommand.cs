using InMemoryFileSystem.Singletons;

namespace InMemoryFileSystem.Commands
{
    internal class MkdirCommand(FileSystem fs, string path) : ICommand
    {
        public void Execute()
        {
            fs.CreateDirectory(path);
        }
    }
}
