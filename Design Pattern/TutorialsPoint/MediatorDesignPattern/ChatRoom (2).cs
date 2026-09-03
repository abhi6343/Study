namespace MediatorDesignPattern
{
    public class ChatRoom
    {
        public static void showMessages(User user, string message)
        {
            Console.WriteLine( DateTime.Now.ToString() + " [" + user.getName() + "] : " + message );
        }
    }
}
