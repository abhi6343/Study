namespace RealtimeEncapsulationExample
{
    internal class Role
    {
        private string roleName;
        private List<PermissionType> permissions = new List<PermissionType>();
        public Role(string roleName, List<PermissionType> permissions)
        {
            this.roleName = roleName;
            this.permissions = permissions;
        }
        public bool HasPermission(PermissionType permission)
        {
            return permissions.Contains(permission);
        }
    }
}
