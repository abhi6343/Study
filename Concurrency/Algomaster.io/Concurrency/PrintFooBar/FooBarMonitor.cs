namespace PrintFooBar
{
    internal class FooBarMonitor(int n)
    {
        readonly Lock lockObj = new();

        public void Foo()
        {
            try
            {
                for (int i = 0; i < n; i++)
                {
                    if (Monitor.TryEnter(lockObj)) // Wait for foo's turn
                    {
                        Console.Write("foo"); // Print "foo"
                        Monitor.Pulse(lockObj); // Signal bar to check if it's its turn                        
                        if (i < n) // Avoid waiting after the last print
                        {
                            Monitor.Wait(lockObj); // Signal bar's turn
                        }
                    }
                }
            }
            finally
            {
                Monitor.Exit(lockObj); // Signal bar's turn
            }
        }

        public void Bar()
        {
            try
            {
                for (int i = 0; i < n; i++)
                {
                    if (Monitor.TryEnter(lockObj)) // Wait for bar's turn
                    {
                        Console.Write("bar"); // Print "bar"
                        Monitor.Pulse(lockObj); // Signal foo to check if it's its turn
                        if (i < n)
                        {
                            Monitor.Wait(lockObj); // Signal foo's turn
                        }
                    }
                }
            }
            finally
            {
                Monitor.Exit(lockObj); // Signal foo's turn
            }
        }
    }
}
