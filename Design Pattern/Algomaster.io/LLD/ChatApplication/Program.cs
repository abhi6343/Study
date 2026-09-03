// 1. Initialize the Mediator (ChatService)
using ChatApplication.Entities;
using ChatApplication.Mediator;

var chatService = new ChatService();

// 2. Create and register users
var alice = chatService.CreateUser("Alice");
var bob = chatService.CreateUser("Bob");
var charlie = chatService.CreateUser("Charlie");

Console.WriteLine("--- Users registered in the system ---");
Console.WriteLine();

// 3. Scenario 1: One-on-one chat between Alice and Bob
Console.WriteLine("--- Starting one-on-one chat between Alice and Bob ---");
var aliceBobChat = chatService.CreateOneToOneChat(alice.Id, bob.Id);

// Alice sends a message to Bob
Console.WriteLine("Alice sends a message...");
chatService.SendMessage(alice.Id, aliceBobChat.Id, "Hi Bob, how are you?");

// Bob sends a reply
Console.WriteLine("\nBob sends a reply...");
chatService.SendMessage(bob.Id, aliceBobChat.Id, "I'm good, Alice! Thanks for asking.");
Console.WriteLine();

// 4. Scenario 2: Group chat
Console.WriteLine("--- Starting a group chat for a 'Project Team' ---");
var projectMembers = new List<string> { alice.Id, bob.Id, charlie.Id };
Chat projectGroup = chatService.CreateGroupChat("Project Team", projectMembers);

// Charlie sends a message to the group
Console.WriteLine("Charlie sends a message to the group...");
chatService.SendMessage(charlie.Id, projectGroup.Id, "Hey team, when is our deadline?");

// Alice replies to the group
Console.WriteLine("\nAlice replies to the group...");
chatService.SendMessage(alice.Id, projectGroup.Id, "It's next Friday. Let's sync up tomorrow.");
Console.WriteLine();

// 5. Demonstrate fetching chat history
Console.WriteLine("--- Fetching Chat Histories ---");

// History of Alice and Bob's chat
Console.WriteLine($"\nHistory for chat '{aliceBobChat.GetName(alice)}':");
var oneToOneHistory = chatService.PrintChatHistory(aliceBobChat.Id);
foreach (Message message in oneToOneHistory)
{
    Console.WriteLine(message.ToString());
}

// History of the project group chat
Console.WriteLine($"\nHistory for chat '{projectGroup.GetName(charlie)}':");
var groupHistory = chatService.PrintChatHistory(projectGroup.Id);
foreach (Message message in groupHistory)
{
    Console.WriteLine(message.ToString());
}

// 6. Demonstrate finding all of a user's chats
Console.WriteLine("\n--- Fetching all of Alice's chats ---");
var aliceChats = chatService.GetUserChats(alice.Id);
foreach (var chat in aliceChats)
{
    Console.WriteLine($"Chat: {chat.GetName(alice)} (ID: {chat.Id})");
}