namespace PrintFizzBuzz
{
    internal class FizzBuzzSemaphoreSlim (int n)
    {
        volatile int current = 1;
        readonly Lock lockObj = new();
        readonly SemaphoreSlim fizzSemSlim = new(0);
        readonly SemaphoreSlim buzzSemSlim = new(0);
        readonly SemaphoreSlim fizzbuzzSemSlim = new(0);
        readonly SemaphoreSlim numberSemSlim = new(1);

        void SignalNext()
        {
            current++;
            if (current > n)
            {
                // Signal all to terminate
                fizzSemSlim.Release();
                buzzSemSlim.Release();
                fizzbuzzSemSlim.Release();
                numberSemSlim.Release();
            }
            else if (current % 15 == 0)
            {
                fizzbuzzSemSlim.Release();
            }
            else if (current % 3 == 0)
            {
                fizzSemSlim.Release();
            }
            else if (current % 5 == 0)
            {
                buzzSemSlim.Release();
            }
            else
            {
                numberSemSlim.Release();
            }            
        }
        public void Fizz()
        {
            while (true)
            {
                fizzSemSlim.Wait();
                lock (lockObj)
                {
                    if (current > n) break;
                    Console.Write("fizz");
                    SignalNext();
                }
            }
        }
        public void Buzz()
        {
            while (true)
            {
                buzzSemSlim.Wait();
                lock (lockObj)
                {
                    if (current > n) break;
                    Console.Write("buzz");
                    SignalNext();
                }
            }
        }
        public void FizzBuzz()
        {
            while (true)
            {
                fizzbuzzSemSlim.Wait();
                lock (lockObj)
                {
                    if (current > n) break;
                    Console.Write("fizzbuzz");
                    SignalNext();
                }
            }
        }

        public void Number()
        {
            while (true)
            {
                numberSemSlim.Wait();
                lock (lockObj)
                {
                    if (current > n) break;
                    Console.Write(current);
                    SignalNext();
                }
            }
        }
    }
}
