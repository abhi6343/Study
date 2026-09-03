using Directory = VersionControlSystem.Entities.Composite.Directory;
using File = VersionControlSystem.Entities.File;


Console.WriteLine("Initializing Version Control System...");
var vcs = VersionControlSystem.Singletons.VersionControlSystem.Instance;

// --- Initial State on 'main' branch ---
vcs.PrintCurrentState();

// --- First Commit ---
Console.WriteLine("\n1. Making initial changes and committing...");
var root = vcs.WorkingDirectory;
root.AddChild(new File("README.md", "This is a simple VCS."));
var srcDir = new Directory("src");
root.AddChild(srcDir);
srcDir.AddChild(new File("Main.cs", "public class Main {}"));
var firstCommitId = vcs.Commit("Alice", "Add README and initial source structure");
vcs.PrintCurrentState();

// --- Second Commit ---
Console.WriteLine("\n2. Modifying a file and committing again...");
var readme = (File)root.GetChild("README.md");
readme.Content = "This is an in-memory version control system.";
var secondCommitId = vcs.Commit("Alice", "Update README documentation");
vcs.PrintCurrentState();

// --- View History ---
vcs.Log();

// --- Branching ---
Console.WriteLine("\n3. Creating a new branch 'feature/add-tests'...");
vcs.CreateBranch("feature/add-tests");
vcs.CheckoutBranch("feature/add-tests");

Console.WriteLine("\n4. Working on the new branch...");
var testDir = new Directory("tests");
root.AddChild(testDir);
testDir.AddChild(new File("VCS_Test.cs", "using Microsoft.VisualStudio.TestTools.UnitTesting;"));
var featureCommitId = vcs.Commit("Bob", "Add test directory and initial test file");
vcs.PrintCurrentState();

// --- View history on feature branch ---
vcs.Log();

// --- Switch back to main ---
Console.WriteLine("\n5. Switching back to 'main' branch...");
vcs.CheckoutBranch("main");
vcs.PrintCurrentState();
vcs.Log();

// --- Reverting ---
Console.WriteLine("\n6. Reverting 'main' branch to the first commit...");
vcs.Revert(firstCommitId);
vcs.PrintCurrentState();

// --- View history after revert ---
Console.WriteLine("\nHistory of 'main' after reverting:");
vcs.Log();