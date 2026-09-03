using InMemoryFileSystem.Singletons;

namespace InMemoryFileSystem.Commands
{
    internal class CatCommand(FileSystem fs, string path) : ICommand
    {
        public void Execute()
        {
            var content = fs.ReadFile(path);
            if (!string.IsNullOrEmpty(content))
            {
                Console.WriteLine(content);
            }
        }
    }
}
