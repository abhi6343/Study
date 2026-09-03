using VersionControlSystem.Memento;

namespace VersionControlSystem.Entities
{
    internal class BranchManager
    {
        readonly Dictionary<string, Branch> branches = [];
        public Branch CurrentBranch { get; private set; }
        public BranchManager(Commit initialCommit)
        {
            var mainBranch = new Branch("main", initialCommit);
            branches["main"] = mainBranch;
            CurrentBranch = mainBranch;
        }

        public void CreateBranch(string name, Commit head)
        {
            if (branches.ContainsKey(name))
            {
                Console.WriteLine("Error: Branch '" + name + "' already exists.");
                return;
            }
            var newBranch = new Branch(name, head);
            branches[name] = newBranch;
            Console.WriteLine("Created branch '" + name + "'.");
        }

        public bool SwitchBranch(string name)
        {
            if (!branches.TryGetValue(name, out Branch? value))
            {
                Console.WriteLine("Error: Branch '" + name + "' not found.");
                return false;
            }
            CurrentBranch = value;
            Console.WriteLine("Switched to branch '" + name + "'.");
            return true;
        }

        public void UpdateHead(Commit newHead)
        {
            CurrentBranch.Head = newHead;
        }        
    }
}
