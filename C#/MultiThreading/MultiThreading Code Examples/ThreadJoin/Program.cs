namespace ThreadJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            //Main Thread creating three child threads
            var thread1 = new Thread(Method1);
            var thread2 = new Thread(Method2);
            var thread3 = new Thread(Method3);
            thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //thread1.Join(); //Block Main Thread until thread1 completes its execution
            //thread2.Join(); //Block Main Thread until thread2 completes its execution
            //Now, Main Thread will not wait for thread3 to complete its execution

            //thread3.Join(); //Block Main Thread until thread3 completes its execution

            //Now, Main Thread will block for 3 seconds and wait for thread2 to complete its execution
            //if (thread2.Join(TimeSpan.FromSeconds(3)))
            //{
            //    Console.WriteLine("Thread2 Execution Completed in 3 seconds");
            //}
            //else
            //{
            //    Console.WriteLine("Thread2 Execution Not Completed in 3 seconds");
            //}
            ////Now, Main Thread will block for 3 seconds and wait for thread3 to complete its execution
            //if (thread3.Join(3000))
            //{
            //    Console.WriteLine("Thread3 Execution Completed in 3 seconds");
            //}
            //else
            //{
            //    Console.WriteLine("Thread3 Execution Not Completed in 3 seconds");
            //}

            #region IsAlive
            if (thread1.IsAlive)
            {
                Console.WriteLine("Thread1 Method1 is still Executing");
            }
            else
            {
                Console.WriteLine("Thread1 Method1 Completed its work");
            }
            
            //Wait till thread1 completes its execution
            thread1.Join();

            if (thread1.IsAlive)
            {
                Console.WriteLine("Thread1 Method1 is still Executing");
            }
            else
            {
                Console.WriteLine("Thread1 Method1 Completed its work");
            }
            #endregion

            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }
        static void Method1()
        {
            Console.WriteLine("Method1 - Thread1 Started");
            //Making thread to sleep for 2 seconds
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //Thread.Sleep(3000);
            Console.WriteLine("Method1 - Thread 1 Ended");
        }
        static void Method2()
        {
            Console.WriteLine("Method2 - Thread2 Started");
            Thread.Sleep(2000);
            Console.WriteLine("Method2 - Thread2 Ended");
        }
        static void Method3()
        {
            Console.WriteLine("Method3 - Thread3 Started");
            Thread.Sleep(5000);
            Console.WriteLine("Method3 - Thread3 Ended");
        }
    }
}
