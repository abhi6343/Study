using ChatApplication.Entities;
using ChatApplication.Observers;
using System.Collections.Concurrent;

namespace ChatApplication.Mediator
{
    internal class ChatService
    {
        readonly ConcurrentDictionary<string, User> users = [];
        readonly ConcurrentDictionary<string, Chat> chats = [];

        public User CreateUser(string name)
        {
            var user = new User(name);
            if (!users.TryAdd(user.Id, user))
            {
                throw new InvalidOperationException("User with the same ID already exists.");
            }
            return user;
        }

        public Chat CreateOneToOneChat(string userId1, string userId2)
        {
            var user1 = users[userId1];
            var user2 = users[userId2];
            Chat chat = new OneToOneChat(user1, user2);
            if (!chats.TryAdd(chat.Id, chat))
            {
                throw new InvalidOperationException("Chat with the same ID already exists.");
            }
            return chat;
        }

        public Chat CreateGroupChat(string name, IEnumerable<string> memberIds)
        {
            ICollection<User> members = [];
            foreach (var memberId in memberIds)
            {
                members.Add(users[memberId]);
            }
            Chat chat = new GroupChat(name, members);
            if (!chats.TryAdd(chat.Id, chat))
            {
                throw new InvalidOperationException("Chat with the same ID already exists.");
            }
            return chat;
        }

        public void SendMessage(string senderId, string chatId, string messageContent)
        {
            var sender = users[senderId];

            if (!chats.TryGetValue(chatId, out var chat))
            {
                Console.WriteLine($"Error: Chat not found with ID: {chatId}");
                return;
            }

            if (!chat.Members.Contains(sender))
            {
                Console.WriteLine($"Error: Sender {sender.Name} is not a member of this chat.");
                return;
            }

            var message = new Message(sender, messageContent);
            chat.AddMessage(message);

            // Notify all members of the chat (Observer pattern)
            foreach (var member in chat.Members.Except([sender]))
            {
                // Do not send a notification to the sender
                //if (!member.Equals(sender))
                //{
                    member.OnMessageReceived(message, chat);
                //}
            }
        }

        public IEnumerable<Message> PrintChatHistory(string chatId)
        {
            if (chats.TryGetValue(chatId, out var chat))
            {
                return chat.Messages;
            }
            return [];
        }

        public IEnumerable<Chat> GetUserChats(string userId)
        {
            return chats.Values.Where(chat => chat.Members.Contains(users[userId]));                
        }
    }
}
