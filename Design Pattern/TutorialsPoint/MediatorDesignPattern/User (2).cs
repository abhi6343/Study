namespace MediatorDesignPattern
{
    public class User
    {
        private string name;
        public string getName() { return name; }
        public void setName(string name) { this.name = name;}
        public User(string name)
        {
            this.name = name;
        }
        public void sendMessage(string message)
        {
            ChatRoom.showMessages(this, message);
        }
    }
}
