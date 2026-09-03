namespace PrintZeroEvenOdd
{
    internal class ZeroEvenOddLockFree (int n)
    {
        int state = 0; // 0 = zero, 1 = odd, 2 = even
        public void Zero()
        {
            for (int i = 1; i <= n; i++)
            {
                while (Volatile.Read(ref state) != 0)
                {
                    Thread.Yield();
                }
                Console.Write("0");
                Volatile.Write(ref state, (i % 2 == 1) ? 1 : 2); // Set to odd or even based on next number
            }
        }

        public void Odd()
        {
            for (int i = 1; i <= n; i += 2)
            {
                while (Volatile.Read(ref state) != 1)
                {
                    Thread.Yield();
                }
                Console.Write(i);
                Volatile.Write(ref state, 0);
            }
        }

        public void Even()
        {
            for (int i = 2; i <= n; i += 2)
            {
                while (Volatile.Read(ref state) != 2)
                {
                    Thread.Yield();
                }
                Console.Write(i);
                Volatile.Write(ref state, 0);
            }
        }
    }
}
