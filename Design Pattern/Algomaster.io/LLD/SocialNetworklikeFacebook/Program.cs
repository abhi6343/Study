using SocialNetworklikeFacebook.Entities;
using SocialNetworklikeFacebook.Facades;

var socialNetwork = new SocialNetworkFacade();

Console.WriteLine("----------- 1. Creating Users -----------");
var alice = socialNetwork.CreateUser("Alice", "alice@example.com");
var bob = socialNetwork.CreateUser("Bob", "bob@example.com");
var charlie = socialNetwork.CreateUser("Charlie", "charlie@example.com");
Console.WriteLine($"Created users: {alice.Name}, {bob.Name}, {charlie.Name}");

Console.WriteLine("\n----------- 2. Building Friendships -----------");
socialNetwork.AddFriend(alice.Id, bob.Id);
socialNetwork.AddFriend(bob.Id, charlie.Id);
Console.WriteLine($"{alice.Name} and {bob.Name} are now friends.");
Console.WriteLine($"{bob.Name} and {charlie.Name} are now friends.");

Console.WriteLine("\n----------- 3. Users Create Posts -----------");
var alicePost = socialNetwork.CreatePost(alice.Id, "Hello from Alice!");
var bobPost = socialNetwork.CreatePost(bob.Id, "It's a beautiful day!");
var charliePost = socialNetwork.CreatePost(charlie.Id, "Thinking about design patterns.");

Console.WriteLine("\n----------- 4. Users Interact with Posts -----------");
socialNetwork.AddComment(bob.Id, alicePost.Id, "Hey Alice, nice to see you here!");
socialNetwork.LikePost(charlie.Id, alicePost.Id);

Console.WriteLine("\n----------- 5. Viewing News Feeds (Strategy Pattern) -----------");

Console.WriteLine("\n--- Alice's News Feed (should see Bob's post) ---");
var alicesFeed = socialNetwork.GetNewsFeed(alice.Id);
PrintFeed(alicesFeed);

Console.WriteLine("\n--- Bob's News Feed (should see Alice's, and Charlie's post) ---");
var bobsFeed = socialNetwork.GetNewsFeed(bob.Id);
PrintFeed(bobsFeed);

Console.WriteLine("\n--- Charlie's News Feed (should see Bob's post) ---");
var charliesFeed = socialNetwork.GetNewsFeed(charlie.Id);
PrintFeed(charliesFeed);


static void PrintFeed(List<Post> feed)
{
    if (feed.Count == 0)
    {
        Console.WriteLine("  No posts in the feed.");
        return;
    }

    foreach (var post in feed)
    {
        Console.WriteLine($"  Post by {post.Author.Name} at {post.Timestamp}");
        Console.WriteLine($"    \"{post.Content}\"");
        Console.WriteLine($"    Likes: {post.Likes.Count}, Comments: {post.Comments.Count}");
    }
}
