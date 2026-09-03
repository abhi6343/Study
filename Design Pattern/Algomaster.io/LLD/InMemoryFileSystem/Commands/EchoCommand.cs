using InMemoryFileSystem.Singletons;

namespace InMemoryFileSystem.Commands
{
    internal class EchoCommand(FileSystem fs, string content, string filePath) : ICommand
    {
        public void Execute()
        {
            // The '>' redirection character is handled implicitly by the command's nature.
            // In a more complex shell, this would be more sophisticated.
            fs.WriteToFile(filePath, content);
        }
    }
}
