using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Entities
{
    internal class User(string name, string email)
    {
        readonly string id = Guid.NewGuid().ToString();
        public string Id { get { return id; } }
        public string Name { get; } = name;
        public string Email { get; } = email;
    }
}
