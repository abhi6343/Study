namespace RealtimeInterfaceExample
{
    //Step 3: Implement the authentication process using the interfaces.
    internal class AuthService
    {
        private IAuthenticator _authenticator;
        public AuthService(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }
        public void AuthenticateUser()
        {
            if (_authenticator.Authenticate())
            {
                Console.WriteLine("Authentication successful!");
            }
            else
            {
                Console.WriteLine("Authentication failed.");
            }
        }
    }
}
