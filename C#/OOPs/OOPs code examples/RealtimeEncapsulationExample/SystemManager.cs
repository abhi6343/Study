namespace RealtimeEncapsulationExample
{
    internal class SystemManager
    {
        public void AccessResource(User user, PermissionType permission)
        {
            if (user.HasPermission(permission))
            {
                Console.WriteLine($"{user.Name} has {permission} permission and can access the resource.");
            }
            else
            {
                Console.WriteLine($"{user.Name} does not have {permission} permission and cannot access the resource.");
            }
        }
    }
}
