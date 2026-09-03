using System.Diagnostics;

namespace ThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ThreadPool
            //for (int i = 0; i < 10; i++)
            //{
            //    System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
            //}
            #endregion

            #region Threads
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread thread = new Thread(MyMethod)
            //    {
            //        Name = "Thread" + i
            //    };
            //    thread.Start();
            //}
            #endregion

            #region Performance compare
            //The for loop within the Main method is for warm-up. This is because when we run the code for the first time,
            //compilation happens and compilation takes some time and we don’t want to measure that.

            //Warmup Code start
            for (int i = 0; i < 10; i++)
            {
                MethodWithThread();
                MethodWithThreadPool();
            }
            //Warmup Code stop

            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Execution using Thread");
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThread is : " + stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();
            Console.WriteLine("Execution using Thread Pool");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThreadPool is : " + stopwatch.ElapsedTicks.ToString());
            #endregion

            Console.Read();
        }
        public static void MyMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
        }
        public static void MethodWithThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Test);
                thread.Start();
            }
        }
        public static void MethodWithThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(Test));
            }
        }
        public static void Test(object obj)
        {
        }
    }
}
