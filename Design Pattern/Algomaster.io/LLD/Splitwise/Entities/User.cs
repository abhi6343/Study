namespace Splitwise.Entities
{
    internal class User
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Phone { get; }

        public User(string id, string name, string email, string phone)
        {
            if (id == null || name == null)
            {
                throw new ArgumentException("User id and name cannot be null");
            }
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString() { return Name; }
    }
}
