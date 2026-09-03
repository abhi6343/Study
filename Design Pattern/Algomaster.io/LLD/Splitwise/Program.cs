using Splitwise;
using Splitwise.Entities;
using Splitwise.Enums;
using Splitwise.Observer;

var service = SplitwiseService.Instance;

// Register observer
service.AddObserver(new EmailNotificationObserver());

// Create users
var alice = new User("u1", "Alice", "alice@email.com", "1111111111");
var bob = new User("u2", "Bob", "bob@email.com", "2222222222");
var charlie = new User("u3", "Charlie", "charlie@email.com", "3333333333");

service.AddUser(alice);
service.AddUser(bob);
service.AddUser(charlie);

// Create a group
var _ = service.CreateGroup("g1", "Trip to Goa");
service.AddMemberToGroup("g1", "u1");
service.AddMemberToGroup("g1", "u2");
service.AddMemberToGroup("g1", "u3");

// ===== SCENARIO 1: Equal Split =====
Console.WriteLine("===== SCENARIO 1: Equal Split =====");
var equalSplits = new List<Split> {
            new EqualSplit("u1"),
            new EqualSplit("u2"),
            new EqualSplit("u3")
        };
service.AddExpense("e1", 300.00, "Dinner", "u1",
                  SplitType.Equal, equalSplits, "g1");

Console.WriteLine("\nBalances after dinner:");
Console.WriteLine($"  Bob owes Alice: ${service.GetBalance("u2", "u1"):F2}");
Console.WriteLine($"  Charlie owes Alice: ${service.GetBalance("u3", "u1"):F2}");

// ===== SCENARIO 2: Exact Split =====
Console.WriteLine("\n===== SCENARIO 2: Exact Split =====");
var exactSplits = new List<Split> {
            new ExactSplit("u1", 100.00),
            new ExactSplit("u2", 200.00),
            new ExactSplit("u3", 200.00)
        };
service.AddExpense("e2", 500.00, "Hotel", "u2",
                  SplitType.Exact, exactSplits, "g1");

Console.WriteLine("\nBalances after hotel:");
Console.WriteLine($"  Alice owes Bob: ${service.GetBalance("u1", "u2"):F2}");
Console.WriteLine($"  Charlie owes Bob: ${service.GetBalance("u3", "u2"):F2}");

// ===== SCENARIO 3: Percentage Split =====
Console.WriteLine("\n===== SCENARIO 3: Percentage Split =====");
var percentSplits = new List<Split> {
            new PercentageSplit("u1", 50),
            new PercentageSplit("u2", 25),
            new PercentageSplit("u3", 25)
        };
service.AddExpense("e3", 400.00, "Activities", "u3",
                  SplitType.Percentage, percentSplits, "g1");

Console.WriteLine("\nBalances after activities:");
Console.WriteLine($"  Alice owes Charlie: ${service.GetBalance("u1", "u3"):F2}");
Console.WriteLine($"  Bob owes Charlie: ${service.GetBalance("u2", "u3"):F2}");

// ===== SCENARIO 4: Settlement =====
Console.WriteLine("\n===== SCENARIO 4: Settlement =====");
Console.WriteLine("Bob settles $50 with Alice...");
service.SettleUp("u2", "u1", 50.00);
Console.WriteLine($"  Bob owes Alice after settlement: ${service.GetBalance("u2", "u1"):F2}");

// ===== FINAL BALANCES =====
Console.WriteLine("\n===== FINAL BALANCES =====");
string[] userIds = { "u1", "u2", "u3" };
string[] names = { "Alice", "Bob", "Charlie" };

for (int idx = 0; idx < userIds.Length; idx++)
{
    var balances = service.GetBalancesForUser(userIds[idx]);
    Console.WriteLine($"{names[idx]}'s balances:");
    foreach (var entry in balances)
    {
        if (Math.Abs(entry.Value) > 0.01)
        {
            var otherName = entry.Key == "u1" ? "Alice" :
                               entry.Key == "u2" ? "Bob" : "Charlie";
            if (entry.Value > 0)
            {
                Console.WriteLine($"  Owes {otherName}: ${entry.Value:F2}");
            }
            else
            {
                Console.WriteLine($"  Owed by {otherName}: ${-entry.Value:F2}");
            }
        }
    }
}

