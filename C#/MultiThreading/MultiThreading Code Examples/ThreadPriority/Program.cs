namespace ThreadPriority
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(SomeMethod)
            {
                Name = "Thread 1",
                Priority = System.Threading.ThreadPriority.Normal
            };
            var thread2 = new Thread(SomeMethod)
            {
                Name = "Thread 2",
                Priority = System.Threading.ThreadPriority.Lowest
            };
            var thread3 = new Thread(SomeMethod)
            {
                Name = "Thread 3",
                Priority = System.Threading.ThreadPriority.Highest
            };

            //Getting the thread Prioroty
            Console.WriteLine($"Thread 1 Priority: {thread1.Priority}");
            Console.WriteLine($"Thread 2 Priority: {thread2.Priority}");
            Console.WriteLine($"Thread 3 Priority: {thread3.Priority}");

            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();
        }
        public static void SomeMethod()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name} Printing {i}");
            }
        }
    }
}
