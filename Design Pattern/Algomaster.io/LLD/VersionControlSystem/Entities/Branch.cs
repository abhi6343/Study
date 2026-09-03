using VersionControlSystem.Memento;

namespace VersionControlSystem.Entities
{
    internal class Branch(string name, Commit head)
    {
        Commit head = head;

        public string Name => name;

        public Commit Head
        {
            get { return head; }
            set { head = value; }
        }
    }
}
