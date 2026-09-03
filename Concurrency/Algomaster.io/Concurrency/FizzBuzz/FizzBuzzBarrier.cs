namespace PrintFizzBuzz
{
    internal class FizzBuzzBarrier
    {
        readonly Barrier barrier;
        volatile int phase = -1; // 0=number, 1=fizz, 2=buzz, 3=fizzbuzz
        int current = 1;    
        readonly int n;

        public FizzBuzzBarrier(int n)
        {
            this.n = n;
            barrier = new Barrier(4, AdvanceAndDispatch);
        }

        private void AdvanceAndDispatch(Barrier barrier) 
        {
            if (current % 15 == 0) phase = 3;
            else if (current % 3 == 0) phase = 1;
            else if (current % 5 == 0) phase = 2;
            else phase = 0;
            Interlocked.Increment(ref current);
        }
        // Each thread waits at barrier, checks phase, prints if matched

        public void Fizz() 
        { 
            for (int i = 1; i <= n; i++)
            {
                barrier.SignalAndWait();
                if (phase == 1)
                {
                    Console.Write("fizz");
                }
            }
        }
        public void Buzz()
        {
            for (int i = 1; i <= n; i++)
            {
                barrier.SignalAndWait();
                if (phase == 2)
                {
                    Console.Write("buzz");
                }
            }
        }
        public void FizzBuzz()
        {
            for (int i = 1; i <= n; i++)
            {
                barrier.SignalAndWait();
                if (phase == 3)
                {
                    Console.Write("fizzbuzz");
                }
            }
        }
        public void Number()
        {
            for (int i = 1; i <= n; i++)
            {
                barrier.SignalAndWait();
                if (phase == 0)
                {
                    Console.Write(i);
                }
            }
        }
    }
}
