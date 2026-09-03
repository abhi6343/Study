namespace RealtimeInterfaceExample
{
    // FingerprintAuthenticator.cs
    internal class FingerprintAuthenticator : IAuthenticator
    {
        public bool Authenticate()
        {
            // Logic for fingerprint authentication
            Console.WriteLine("Authenticating using fingerprint...");
            return true;
        }
    }
}
