namespace PrintFizzBuzz
{
    internal class FizzBuzzMultiCondition (int n)
    {
        int current = 1;
        readonly Lock lockObj = new();
        readonly object fizzLock = new();
        readonly object buzzLock = new();
        readonly object fizzbuzzLock = new();
        readonly object numberLock = new();

        private void SignalNext()
        {
            lock (lockObj)
            {
                current++;
                if (current > n)
                {
                    // Wake all for termination
                    lock (fizzLock) Monitor.Pulse(fizzLock);
                    lock (buzzLock) Monitor.Pulse(buzzLock);
                    lock (fizzbuzzLock) Monitor.Pulse(fizzbuzzLock);
                    lock (numberLock) Monitor.Pulse(numberLock);
                }
                else if (current % 15 == 0)
                {
                    lock (fizzbuzzLock) Monitor.Pulse(fizzbuzzLock);
                }
                else if (current % 3 == 0)
                {
                    lock (fizzLock) Monitor.Pulse(fizzLock);
                }
                else if (current % 5 == 0)
                {
                    lock (buzzLock) Monitor.Pulse(buzzLock);
                }
                else
                {
                    lock (numberLock) Monitor.Pulse(numberLock);
                }
            }
        }

        public void Fizz()
        {
            lock (fizzLock)
            {
                while (current <= n)
                {
                    while (current <= n && !(current % 3 == 0 && current % 5 != 0))
                    {
                        Monitor.Wait(fizzLock);
                    }
                    if (current > n) break;
                    Console.Write("fizz");
                    //lock (lockObj)
                    //{
                    //    current++;
                    //    SignalNext();
                    //}
                    SignalNext();
                }
            }
        }
        public void Buzz()
        {
            lock (buzzLock)
            {
                while (current <= n)
                {
                    while (current <= n && !(current % 3 != 0 && current % 5 == 0))
                    {
                        Monitor.Wait(buzzLock);
                    }
                    if (current > n) break;
                    Console.Write("buzz");
                    //lock (lockObj)
                    //{
                    //    current++;
                    //    SignalNext();
                    //}
                    SignalNext();
                }
            }
        }
        public void FizzBuzz()
        {
            lock (fizzbuzzLock)
            {
                while (current <= n)
                {
                    while (current <= n && !(current % 3 == 0 && current % 5 == 0))
                    {
                        Monitor.Wait(fizzbuzzLock);
                    }
                    if (current > n) break;
                    Console.Write("fizzbuzz");
                    //lock (lockObj)
                    //{
                    //    current++;
                    //    SignalNext();
                    //}
                    SignalNext();
                }
            }
        }
        public void Number()
        {
            lock (numberLock)
            {
                while (current <= n)
                {
                    while (current <= n && !(current % 5 != 0 && current % 3 != 0))
                    {
                        Monitor.Wait(numberLock);
                    }
                    if (current > n) break;
                    Console.Write(current);
                    //lock (lockObj)
                    //{
                    //    current++;
                    //    SignalNext();
                    //}
                    SignalNext();
                }
            }
        }
    }
}
