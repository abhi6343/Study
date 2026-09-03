namespace VersionControlSystem.Entities
{
    internal class File(string name, string content) : FileSystemNode(name)
    {
        public string Content { get; set; } = content;

        public override FileSystemNode Clone()
        {
            return new File(Name, Content);
        }

        public override void Print(string indent)
        {
            Console.WriteLine(indent + "- " + Name + " (File)");
        }
    }
}
