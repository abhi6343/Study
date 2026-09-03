namespace InMemoryFileSystem.Commands
{
    internal class NoOpCommand(string v) : ICommand
    {
        public void Execute()
        {
            if (!string.IsNullOrEmpty(v))
            {
                Console.WriteLine(v);
            }
        }
    }
}
