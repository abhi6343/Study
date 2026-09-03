using VersionControlSystem.Entities;
using VersionControlSystem.Memento;
using Directory = VersionControlSystem.Entities.Composite.Directory;
namespace VersionControlSystem.Singletons
{
    internal class VersionControlSystem
    {
        static VersionControlSystem instance;
        readonly CommitManager commitManager;
        readonly BranchManager branchManager;
        public Directory WorkingDirectory { get; private set; }

        private VersionControlSystem()
        {
            commitManager = new();
            WorkingDirectory = new("root");
            var initialCommit = commitManager.CreateCommit("system", "Initial commit", default, (Directory)WorkingDirectory.Clone());
            branchManager = new(initialCommit);
        }

        public static VersionControlSystem Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }        

        public string Commit(string author, string message)
        {
            var parentCommit = branchManager.CurrentBranch.Head;
            var snapshot = (Directory)WorkingDirectory.Clone();

            var newCommit = commitManager.CreateCommit(author, message, parentCommit, snapshot);
            branchManager.UpdateHead(newCommit);

            Console.WriteLine("Committed " + newCommit.Id + " to branch " + branchManager.CurrentBranch.Name);
            return newCommit.Id;
        }

        public void CreateBranch(string name)
        {
            var head = branchManager.CurrentBranch.Head;
            branchManager.CreateBranch(name, head);
        }

        public void CheckoutBranch(string name)
        {
            bool success = branchManager.SwitchBranch(name);
            if (success)
            {
                var newHead = branchManager.CurrentBranch.Head;
                WorkingDirectory = (Directory)newHead.RootSnapshot.Clone();
            }
        }

        public void Revert(string commitId)
        {
            var targetCommit = commitManager.GetCommit(commitId);
            if (targetCommit == null)
            {
                Console.WriteLine("Error: Commit '" + commitId + "' not found.");
                return;
            }
            WorkingDirectory = (Directory)targetCommit.RootSnapshot.Clone();
            branchManager.UpdateHead(targetCommit);

            Console.WriteLine("Repository state reverted to commit " + commitId);
        }

        public void Log()
        {
            Console.WriteLine("\n--- Commit History for branch '" + branchManager.CurrentBranch.Name + "' ---");
            var headCommit = branchManager.CurrentBranch.Head;
            CommitManager.PrintHistory(headCommit);
        }

        public void PrintCurrentState()
        {
            Console.WriteLine("\n--- Current Working Directory State ---");
            WorkingDirectory.Print("");
        }
    }
}
