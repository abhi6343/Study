namespace PrintFizzBuzz
{
    internal class FizzBuzzCondition (int n)
    {
        volatile int current = 1;
        readonly object lockObj = new();
        public void Fizz()
        {            
            lock (lockObj)
            {
                while (current <= n)
                {
                    // Wait while not fizz's turn
                    while (current <= n && !(current % 5 != 0 && current % 3 == 0))
                    {
                        Monitor.Wait(lockObj);
                    }
                    if (current > n) break;
                    Console.Write("fizz");
                    current++;
                    Monitor.PulseAll(lockObj);
                }
            }
        }
        public void Buzz()
        {
            lock (lockObj)
            {
                while (current <= n)
                {
                    // Wait while not buzz's turn
                    while (current <= n && !(current % 3 != 0 && current % 5 == 0))
                    {
                        Monitor.Wait(lockObj);
                    }
                    if (current > n) break;
                    Console.Write("buzz");
                    current++;
                    Monitor.PulseAll(lockObj);
                }
            }
        }
        public void FizzBuzz()
        {
            lock (lockObj)
            {
                while (current <= n)
                {
                    // Wait while not fizzbuzz's turn
                    while (current <= n && !(current % 3 == 0 && current % 5 == 0))
                    {
                        Monitor.Wait(lockObj);
                    }
                    if (current > n) break;
                    Console.Write("fizzbuzz");
                    current++;
                    Monitor.PulseAll(lockObj);
                }
            }
        }

        public void Number()
        {
            lock (lockObj)
            {
                while (current <= n)
                {
                    // Wait while not number's turn
                    while (current <= n && !(current % 5 != 0 && current % 3 != 0))
                    {
                        Monitor.Wait(lockObj);
                    }
                    if (current > n) break;
                    Console.Write(current);
                    current++;
                    Monitor.PulseAll(lockObj);
                }
            }
        }
    }
}
