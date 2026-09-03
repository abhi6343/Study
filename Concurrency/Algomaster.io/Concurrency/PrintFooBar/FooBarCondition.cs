namespace PrintFooBar
{
    internal class FooBarCondition (int n)
    {
        bool fooTurn = true; // Indicates whether it's foo's turn
        readonly object lockObj = new(); // Lock object for synchronization
        public void Foo()
        {
            for (int i = 0; i < n; i++)
            {
                lock (lockObj) // Wait for foo's turn
                {
                    while (!fooTurn)
                    {
                        Monitor.Wait(lockObj); // Wait until it's foo's turn
                    }
                    Console.Write("foo"); // Print "foo"
                    fooTurn = false; // Signal bar's turn
                    Monitor.Pulse(lockObj); // Signal bar to check if it's its turn // Wake bar
                }
            }
        }

        public void Bar()
        {
            for (int i = 0; i < n; i++)
            {
                lock (lockObj) // Wait for bar's turn
                {
                    while (fooTurn)
                    {
                        Monitor.Wait(lockObj); // Wait until it's bar's turn
                    }
                    Console.Write("bar"); // Print "bar"
                    fooTurn = true; // Signal foo's turn
                    Monitor.Pulse(lockObj); // Signal foo to check if it's its turn // Wake foo
                }
            }
        }
    }
}
