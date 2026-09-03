using InMemoryFileSystem.Commands;
using InMemoryFileSystem.Singletons;
using InMemoryFileSystem.Strategies;

namespace InMemoryFileSystem
{
    /// <summary>
    /// Acts as the command interpreter for the filesystem.
    /// </summary>
    internal class Shell
    {
        readonly FileSystem fs;

        public Shell()
        {
            fs = FileSystem.Instance;
        }

        public void ExecuteCommand(string input)
        {
            var parts = input.Trim().Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
            var commandName = parts[0];

            ICommand command;

            try
            {
                command = commandName switch
                {
                    "mkdir" => new MkdirCommand(fs, parts[1]),
                    "touch" => new TouchCommand(fs, parts[1]),
                    "cd" => new CdCommand(fs, parts[1]),
                    "ls" => new LsCommand(fs, GetPathArgumentForLs(parts), GetListingStrategy(parts)),
                    "pwd" => new PwdCommand(fs),
                    "cat" => new CatCommand(fs, parts[1]),
                    "echo" => new EchoCommand(fs, GetEchoContent(input), GetEchoFilePath(parts)),
                    _ => new NoOpCommand($"Error: Unknown command '{commandName}'.")
                };
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Error: Missing argument for command '{commandName}'.");
                command = new NoOpCommand("");
            }

            command.Execute();
        }

        private static IListingStrategy GetListingStrategy(string[] args)
        {
            if (args.Contains("-l"))
            {
                return new DetailedListingStrategy();
            }
            return new SimpleListingStrategy();
        }

        private static string? GetPathArgumentForLs(string[] parts)
        {
            // Find the first argument that is not an option flag.
            return parts.Skip(1) // Skip the command name itself
                       .FirstOrDefault(part => !part.StartsWith('-')); // Return null if no path argument is found
        }

        private static string GetEchoContent(string input)
        {
            // Simple parsing for "echo 'content' > file"
            try
            {
                var start = input.IndexOf('\'') + 1;
                var end = input.LastIndexOf('\'');
                if (start > 0 && end > start)
                {
                    return input[start..end];
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

        private static string GetEchoFilePath(string[] parts)
        {
            // The file path is the last argument after the redirection symbol '>'
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == ">" && i + 1 < parts.Length)
                {
                    return parts[i + 1];
                }
            }
            return string.Empty; // Should be handled by argument check
        }
    }
}
