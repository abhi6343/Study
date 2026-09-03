namespace PrintFooBar
{
    internal class FooBarBarrier(int n)
    {
        readonly Barrier barrier = new(3);
        volatile int phase = 0;

        public void Foo()
        {
            for (int i = 0; i < n; i++)
            {
                while (phase % 3 != 0)
                {
                    Thread.Yield();
                }
                Console.Write("foo");
                Interlocked.Increment(ref phase); // Signal bar's turn
                barrier.SignalAndWait(); // Sync with bar
            }
        }

        public void Bar()
        {
            for (int i = 0; i < n; i++)
            {
                while (phase % 3 != 1)
                {
                    Thread.Yield();
                }
                Console.Write("bar");
                Interlocked.Increment(ref phase); // Signal baz's turn
                barrier.SignalAndWait(); // Sync with baz
            }
        }

        public void Baz()
        {
            for (int i = 0; i < n; i++)
            {
                while (phase % 3 != 2)
                {
                    Thread.Yield();
                }
                Console.Write("baz");
                Interlocked.Increment(ref phase); // Signal foo's turn
                barrier.SignalAndWait(); // Sync with foo
            }
        }
    }
}
