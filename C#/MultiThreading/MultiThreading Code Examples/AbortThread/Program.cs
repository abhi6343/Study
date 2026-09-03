using System.Threading;
using System;

namespace AbortThread
{
    internal class Program
    {
        //#region Abort()
        //static void Main(string[] args)
        //{
        //    // Creating and initializing threads
        //    Thread thread = new Thread(SomeMethod);
        //    thread.Start();
        //    Console.WriteLine("Thread is Abort");
        //    // Abort thread Using Abort() method
        //    thread.Abort();
        //    Console.ReadKey();
        //}
        //public static void SomeMethod()
        //{
        //    for (int x = 0; x < 3; x++)
        //    {
        //        Console.WriteLine(x);
        //    }
        //}
        //#endregion

        //#region Abort(object stateInfo)
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(SomeMethod)
        //    {
        //        Name = "Thread 1"
        //    };
        //    thread.Start();
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Abort Thread Thread 1");
        //    thread.Abort(100);
        //    // Waiting for the thread to terminate.
        //    thread.Join();
        //    Console.WriteLine("Main thread is terminating");
        //    Console.ReadKey();
        //}
        //public static void SomeMethod()
        //{
        //    try
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} is Starting");
        //        for (int j = 1; j <= 100; j++)
        //        {
        //            Console.Write(j + " ");
        //            if ((j % 10) == 0)
        //            {
        //                Console.WriteLine();
        //                Thread.Sleep(200);
        //            }
        //        }
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Exiting Normally");
        //    }
        //    catch (ThreadAbortException ex)
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} is aborted and the code is {ex.ExceptionState}");
        //    }
        //}
        //#endregion

        //#region Abort running thread
        //static void Main(string[] args)
        //{
        //    //Creating an object Thread class
        //    Thread thread = new Thread(SomeMethod)
        //    {
        //        Name = "My Thread1"
        //    };
        //    thread.Start();
        //    //Making the main Thread sleep for 1 second
        //    //Giving the child thread enough time to start its execution
        //    Thread.Sleep(1000);
        //    //Calling the Abort() on thread object
        //    //This will abort the new thread and throw ThreadAbortException in it
        //    thread.Abort();
        //    Console.ReadKey();
        //}
        //public static void SomeMethod()
        //{
        //    try
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
        //        for (int i = 0; i < 3; i++)
        //        {
        //            Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
        //            //Calling the Sleep() method to make it sleep and 
        //            //suspend for 2 seconds after printing a number
        //            Thread.Sleep(1000);
        //        }
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
        //    }
        //    catch (ThreadAbortException e)
        //    {
        //        Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
        //    }
        //}
        //#endregion

        //#region Abort unstarted thread
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        //Creating an object Thread class
        //        Thread MyThread = new Thread(SomeMethod)
        //        {
        //            Name = "My Thread1"
        //        };
        //        //Calling the Abort() method on MyThread which hasn't started yet
        //        //This will leads to the ThreadStartException
        //        //And calling the Start() method on the same thread later on will abort it and throw ThreadStartException
        //        MyThread.Abort();
        //        //Calling the Start() method will not start the thread
        //        //but throw ThreadStartException and abort it.
        //        //Because the Abort() method was called on it before it could start
        //        MyThread.Start();
        //        Console.WriteLine("Main Thread has terminated");
        //    }
        //    catch (ThreadStartException e)
        //    {
        //        Console.WriteLine($"ThreadStartException Occurred, Message : {e.Message}");
        //    }

        //    Console.ReadKey();
        //}
        //public static void SomeMethod()
        //{
        //    try
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
        //        for (int i = 0; i < 3; i++)
        //        {
        //            Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
        //            //Calling the Sleep() method to make it sleep and 
        //            //suspend for 2 seconds after printing a number
        //            Thread.Sleep(1000);
        //        }
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
        //    }
        //    catch (ThreadAbortException e)
        //    {
        //        Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
        //    }
        //}
        //#endregion

        #region Abort blocked thread
        static void Main(string[] args)
        {
            //Creating an object Thread class
            Thread MyThread = new Thread(SomeMethod)
            {
                Name = "My Thread1"
            };
            MyThread.Start();
            //Making the Main thread sleep for 500 milliseconds
            //Which gives enough time for its child start to start its execution
            Thread.Sleep(500);
            //Main thread calling Abort() on the child Thread which is in a blocked state
            //will throw ThreadAbortException 
            MyThread.Abort();

            //Main thread has called Join() method on the new thread
            //To wait until its execution is complete
            MyThread.Join();

            Console.WriteLine("Main Thread has terminated");
            Console.ReadKey();
        }
        public static void SomeMethod()
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
                    //Calling the Sleep() method on newly created thread
                    //To make it sleep and suspend for 3 seconds after printing a number
                    Thread.Sleep(3000);
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
            }
        }
        #endregion
    }
}
