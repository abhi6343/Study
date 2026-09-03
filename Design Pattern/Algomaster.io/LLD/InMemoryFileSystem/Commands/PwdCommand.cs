using InMemoryFileSystem.Singletons;

namespace InMemoryFileSystem.Commands
{
    internal class PwdCommand(FileSystem fs) : ICommand // Print working directory
    {
        public void Execute()
        {
            Console.WriteLine(fs.GetWorkingDirectory());
        }
    }
}
