namespace RealtimeEncapsulationExample
{
    internal class User
    {
        private string name;
        private Role userRole;
        public User(string name, Role role)
        {
            this.name = name;
            this.userRole = role;
        }
        public string Name => name;
        public bool HasPermission(PermissionType permission)
        {
            return userRole.HasPermission(permission);
        }
    }
    internal enum PermissionType
    {
        Read,
        Write,
        Delete
    }
}
