using StackOverflow.Entities;
using StackOverflow.Facade;
using StackOverflow.Strategy;

StackOverflowService service = new();

// 1. Create Users
var alice = service.CreateUser("Alice");
var bob = service.CreateUser("Bob");
var charlie = service.CreateUser("Charlie");

// 2. Alice posts a question
Console.WriteLine("--- Alice posts a question ---");
var javaTag = new Tag("java");
var designPatternsTag = new Tag("design-patterns");
var tags = new HashSet<Tag> { javaTag, designPatternsTag };
var question = service.PostQuestion(alice.Id, "How to implement Observer Pattern?", "Details about Observer Pattern...", tags);
PrintReputations(alice, bob, charlie);

// 3. Bob and Charlie post answers
Console.WriteLine("\n--- Bob and Charlie post answers ---");
var bobAnswer = service.PostAnswer(bob.Id, question.Id, "You can use the java.util.Observer interface.");
var charlieAnswer = service.PostAnswer(charlie.Id, question.Id, "A better way is to create your own Observer interface.");
PrintReputations(alice, bob, charlie);

// 4. Voting happens
Console.WriteLine("\n--- Voting Occurs ---");
service.VoteOnPost(alice.Id, question.Id, VoteType.UPVOTE);
service.VoteOnPost(bob.Id, charlieAnswer.Id, VoteType.UPVOTE);
service.VoteOnPost(alice.Id, bobAnswer.Id, VoteType.DOWNVOTE);
PrintReputations(alice, bob, charlie);

// 5. Alice accepts Charlie's answer
Console.WriteLine("\n--- Alice accepts Charlie's answer ---");
service.AcceptAnswer(question.Id, charlieAnswer.Id);
PrintReputations(alice, bob, charlie);

// 6. Search for questions
Console.WriteLine("\n--- (C) Combined Search: Questions by 'Alice' with tag 'java' ---");
var filtersC = new List<ISearchStrategy>
        {
            new UserSearchStrategy(alice),
            new TagSearchStrategy(javaTag)
        };
var searchResults = service.SearchQuestions(filtersC);
foreach (var q in searchResults)
{
    Console.WriteLine($"  - Found: {q.Title}");
}
    

static void PrintReputations(params User[] users)
{
    Console.WriteLine("--- Current Reputations ---");
    foreach (User user in users)
    {
        Console.WriteLine($"{user.Name}: {user.Reputation}");
    }
}