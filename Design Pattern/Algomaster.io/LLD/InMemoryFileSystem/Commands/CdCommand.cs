using InMemoryFileSystem.Singletons;

namespace InMemoryFileSystem.Commands
{
    internal class CdCommand(FileSystem fs, string path) : ICommand
    {
        public void Execute()
        {
            fs.ChangeDirectory(path);
        }
    }
}
