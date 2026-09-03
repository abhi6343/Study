namespace SingletonDesignPattern
{
    public class SingletonObject
    {
        // Create an object of SingletonObject
        private static SingletonObject instance = new SingletonObject();
        // Make the constructor private so that this class can not be instantiated
        private SingletonObject() { }
        // Get the only object available
        public static SingletonObject getInstance()
        {
            return instance;
        }
        public void ShowMessage()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
