using InMemoryFileSystem;

var shell = new Shell();
string[] commands = [
            "pwd",                          // /
            "mkdir /home",
            "mkdir /home/user",
            "touch /home/user/file1.txt",
            "ls -l /home",                  // d user
            "cd /home/user",
            "pwd",                          // /home/user
            "ls",                           // file1.txt
            "echo 'Hello World!' > file1.txt",
            "cat file1.txt",                // Hello World!
            "echo 'Overwriting content' > file1.txt",
            "cat file1.txt",                // Overwriting content
            "mkdir documents",
            "cd documents",
            "pwd",                          // /home/user/documents
            "touch report.docx",
            "ls",                           // report.docx
            "cd ..",
            "pwd",                          // /home/user
            "ls -l",                        // d documents, f file1.txt
            "cd /",
            "pwd",                          // /
            "ls -l",                        // d home
            "cd /nonexistent/path"          // Error: not a directory
        ];

foreach (var command in commands)
{
    Console.WriteLine($"\n$ {command}");
    shell.ExecuteCommand(command);
}