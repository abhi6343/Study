using InMemoryFileSystem.Entities;
using InMemoryFileSystem.Strategies;
using File = InMemoryFileSystem.Entities.File;
using Directory = InMemoryFileSystem.Entities.Composite.Directory;

namespace InMemoryFileSystem.Singletons
{
    internal class FileSystem
    {
        static volatile FileSystem instance;
        static readonly Lock lockObject = new();

        readonly Directory root;
        Directory currentDirectory;

        private FileSystem()
        {
            root = new("/", null);
            currentDirectory = root;
        }

        public static FileSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new FileSystem();
                    }
                }
                return instance;
            }
        }

        public void CreateDirectory(string path)
        {
            CreateNode(path, isDirectory : true);
        }

        public void CreateFile(string path)
        {
            CreateNode(path, isDirectory : false);
        }

        public void ChangeDirectory(string path)
        {
            var node = GetNode(path);
            if (node is Directory directory)
            {
                currentDirectory = directory;
            }
            else
            {
                Console.WriteLine($"Error: '{path}' is not a directory.");
            }
        }

        public void ListContents(IListingStrategy strategy)
        {
            strategy.List(currentDirectory);
        }

        public void ListContentsPath(string path, IListingStrategy strategy)
        {
            var node = GetNode(path);
            if (node == null)
            {
                Console.Error.WriteLine($"ls: cannot access '{path}': No such file or directory");
                return;
            }

            if (node is Directory directory)
            {
                strategy.List(directory);
            }
            else
            {
                // Mimic Unix behavior: if ls is pointed at a file, it just prints the file name.
                Console.WriteLine(node.Name);
            }
        }

        public string GetWorkingDirectory()
        {
            return currentDirectory.GetPath();
        }

        public void WriteToFile(string path, string content)
        {
            var node = GetNode(path);
            if (node is File file)
            {
                file.Content = content;
            }
            else
            {
                Console.WriteLine($"Error: Cannot write to '{path}'. It is not a file or does not exist.");
            }
        }

        public string ReadFile(string path)
        {
            var node = GetNode(path);
            if (node is File file)
            {
                return file.Content;
            }
            Console.WriteLine($"Error: Cannot read from '{path}'. It is not a file or does not exist.");
            return string.Empty;
        }

        void CreateNode(string path, bool isDirectory)
        {
            string name;
            Directory parent;

            Console.WriteLine(currentDirectory.Name);

            if (path.Contains('/'))
            {
                // Path has directory components (e.g., "/a/b/c" or "b/c")
                var lastSlashIndex = path.LastIndexOf('/');
                name = path[(lastSlashIndex + 1)..];
                var parentPath = path[..lastSlashIndex];

                // Handle creating in root, e.g., "/testfile"
                if (string.IsNullOrEmpty(parentPath))
                {
                    parentPath = "/";
                }

                var parentNode = GetNode(parentPath);
                if (parentNode is not Directory parentDirectory)
                {
                    Console.WriteLine($"Error: Invalid path. Parent '{parentPath}' is not a directory or does not exist.");
                    return;
                }
                parent = parentDirectory;
            }
            else
            {
                // Path is a simple name in the current directory (e.g., "c")
                name = path;
                parent = currentDirectory;
            }

            if (string.IsNullOrEmpty(name))
            {
                Console.Error.WriteLine("Error: File or directory name cannot be empty.");
                return;
            }

            // --- Common logic from here ---
            if (parent.GetChild(name) != null)
            {
                Console.WriteLine($"Error: Node '{name}' already exists in '{parent.GetPath()}'.");
                return;
            }

            FileSystemNode newNode = isDirectory ? new Directory(name, parent) : new File(name, parent);
            parent.AddChild(newNode);
        }

        FileSystemNode GetNode(string path)
        {
            if (path == "/") return root;

            var startDir = path.StartsWith('/') ? root : currentDirectory;
            var parts = path.Split('/');

            FileSystemNode current = startDir;
            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part) || part == ".")
                {
                    continue;
                }

                if (current is not Directory currentDir)
                {
                    return null; // Part of the path is a file, so it's invalid
                }

                if (part == "..")
                {
                    current = currentDir.Parent;
                    current ??= root; // Can't go above root
                }
                else
                {
                    current = currentDir.GetChild(part);
                }

                if (current == null) return null; // Path component does not exist
            }
            return current;
        }
    }
}
