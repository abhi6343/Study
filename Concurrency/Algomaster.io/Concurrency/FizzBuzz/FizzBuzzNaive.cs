namespace PrintFizzBuzz
{
    internal class FizzBuzzNaive (int n)
    {
        int current = 1;
        readonly Lock lockObj = new();
        public void Fizz()
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (current > n) break;
                    if (current % 3 == 0 && current % 5 != 0)
                    {
                        Console.Write("fizz");
                        current++;
                    }
                }
                // Busy waiting
            }
        }
        public void Buzz()
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (current > n) break;
                    if (current % 5 == 0 && current % 3 != 0)
                    {
                        Console.Write("buzz");
                        current++;
                    }
                }
                // Busy waiting
            }
        }
        public void FizzBuzz()
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (current > n) break;
                    if (current % 15 == 0)
                    {
                        Console.Write("fizzbuzz");
                        current++;
                    }
                }
                // Busy waiting
            }
        }

        public void Number()
        {
            while (true)
            {
                lock (lockObj)
                {
                    if (current > n) break;
                    if (current % 3 != 0 && current % 5 != 0)
                    {
                        Console.Write(current);
                        current++;
                    }
                }
                // Busy waiting
            }
        }
    }
}
