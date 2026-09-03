namespace RealtimeInterfaceExample
{
    //Step 2: Implement the interface for different authentication methods.
    // PasswordAuthenticator.cs
    internal class PasswordAuthenticator : IAuthenticator
    {
        public bool Authenticate()
        {
            // Logic for password authentication
            Console.WriteLine("Authenticating using password...");
            return true;  // For simplicity, assume authentication always succeeds
        }
    }
}
