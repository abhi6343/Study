namespace SemaphoreSlimExample
{
    internal class Program
    {
        //only 3 threads can access resource simulteniously
        //static readonly SemaphoreSlim semaphoreSlim = new(initialCount: 3);
        //static void Main(string[] args)
        //{
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        var count = i;
        //        var t = new Thread(() => SemaphoreSlimFunction("Thread " + count, 1000 * count));
        //        t.Start();
        //    }
        //    Console.ReadLine();
        //}
        //static void SemaphoreSlimFunction(string name, int seconds)
        //{
        //    Console.WriteLine($"{name} Waits to access resource");
        //    semaphoreSlim.Wait();
        //    Console.WriteLine($"{name} was granted access to resource");
        //    Thread.Sleep(seconds);
        //    Console.WriteLine($"{name} is completed");
        //    semaphoreSlim.Release();
        //}

        // Create the semaphore.
        private readonly static SemaphoreSlim semaphoreSlim = new(0, 3);
        // A padding interval to make the output more orderly.
        private static int padding;
        public static void Main()
        {
            Console.WriteLine($"{semaphoreSlim.CurrentCount} tasks can enter the semaphore");
            var tasks = new Task[5];
            // Create and start five numbered tasks.
            for (int i = 0; i <= 4; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Each task begins by requesting the semaphore.
                    Console.WriteLine($"Task {Task.CurrentId} begins and waits for the semaphore");
                    int semaphoreCount;
                    semaphoreSlim.Wait();
                    try
                    {
                        Interlocked.Add(ref padding, 100);
                        Console.WriteLine($"Task {Task.CurrentId} enters the semaphore");
                        // The task just sleeps for 1+ seconds.
                        Thread.Sleep(1000 + padding);
                    }
                    finally
                    {
                        //throw new Exception("This is a test exception to demonstrate the finally block.");
                        semaphoreCount = semaphoreSlim.Release();
                    }
                    Console.WriteLine($"Task {Task.CurrentId} releases the semaphore; previous count: {semaphoreCount}");
                });
            }
            // Wait for one second, to allow all the tasks to start and block.
            Thread.Sleep(1000);
            // Restore the semaphore count to its maximum value.
            Console.Write("Main thread calls Release(3) --> ");
            semaphoreSlim.Release(3);
            Console.WriteLine($"{semaphoreSlim.CurrentCount} tasks can enter the semaphore");
            // Main thread waits for the tasks to complete.
            Task.WaitAll(tasks);
            Console.WriteLine("Main thread Exits");
            Console.ReadKey();
        }

        //static SemaphoreSlim sem = new(1);

        //static async Task Main()
        //{
        //    await sem.WaitAsync();  // Thread A acquires

        //    await Task.Run(() =>
        //    {
        //        Console.WriteLine("Another thread releasing");
        //        sem.Release();      // Thread B releases
        //    });
        //}
    }
}
