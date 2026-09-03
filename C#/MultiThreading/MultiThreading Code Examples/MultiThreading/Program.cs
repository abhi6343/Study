namespace MultiThreading
{
    internal class Program
    {
        
//        static void Main(string[] args)
//        {
//#if ex1
//            Console.WriteLine("Welcome to Dotnet world!");
//#endif
//#if ex2
//            Thread t = Thread.CurrentThread;
//            //By Default, the Thread does not have any name if you want then you can provide the name explicitly
//            t.Name = "Main Thread";
//            Console.WriteLine("Current Executing Thread Name :" + t.Name);
//            Console.WriteLine("Current Executing Thread Name :" + Thread.CurrentThread.Name);
//#endif
//#if ex3
//            Method1();
//            Method2();
//            Method3();
//#endif
//            Console.ReadKey();
//        }
//        static void Method1()
//        {
//            for (int i = 1; i <= 5; i++)
//            {
//                Console.WriteLine("Method1 :" + i);
//            }
//        }
//        static void Method2()
//        {
//            for (int i = 1; i <= 5; i++)
//            {
//                Console.WriteLine("Method2 :" + i);
//#if ex4
//                 if (i == 3)
//                {
//                    Console.WriteLine("Performing the Database Operation Started");
//                    //Sleep for 10 seconds
//                    Thread.Sleep(10000);
//                    Console.WriteLine("Performing the Database Operation Completed");
//                }
//#endif
//            }
//        }
//        static void Method3()
//        {
//            for (int i = 1; i <= 5; i++)
//            {
//                Console.WriteLine("Method3 :" + i);
//            }
//        }
//    }
#if ex5
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };
            Thread t3 = new Thread(Method3)
            {
                Name = "Thread3"
            };
            //Executing the methods
            t1.Start();
            t2.Start();
            t3.Start();
            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }
        static void Method1()
        {
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
            Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);
        }
        static void Method2()
        {
            Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method2 :" + i);
                if (i == 3)
                {
                    Console.WriteLine("Performing the Database Operation Started");
                    //Sleep for 10 seconds
                    Thread.Sleep(10000);
                    Console.WriteLine("Performing the Database Operation Completed");
                }
            }
            Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.Name);
        }
        static void Method3()
        {
            Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
            Console.WriteLine("Method3 Ended using " + Thread.CurrentThread.Name);
        }
    }
    #endif
}
