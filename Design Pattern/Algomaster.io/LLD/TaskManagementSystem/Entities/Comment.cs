using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Entities
{
    internal class Comment(User author, string content)
    {
        readonly DateTime timestamp = DateTime.Now;
        readonly string id = Guid.NewGuid().ToString();
        public string Id { get { return id; } }
        public User Author { get; } = author;
        public string Content { get; } = content;
    }
}
