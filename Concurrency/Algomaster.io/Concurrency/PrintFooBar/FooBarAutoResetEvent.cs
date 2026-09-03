namespace PrintFooBar
{
    internal class FooBarAutoResetEvent(int n)
    {
        readonly AutoResetEvent fooAutoResetEvent = new(true); // Start with foo allowed to print
        readonly AutoResetEvent barAutoResetEvent = new(false); // Start with bar blocked

        public void Foo()
        {
            for (int i = 0; i < n; i++)
            {
                if (fooAutoResetEvent.WaitOne()) // Wait for foo's turn
                {
                    Console.Write("foo"); // Print "foo"
                    barAutoResetEvent.Set(); // Signal bar's turn
                }
            }
        }

        public void Bar()
        {
            for (int i = 0; i < n; i++)
            {
                if (barAutoResetEvent.WaitOne()) // Wait for bar's turn
                {
                    Console.Write("bar"); // Print "bar"
                    fooAutoResetEvent.Set(); // Signal foo's turn
                }
            }
        }
    }
}
