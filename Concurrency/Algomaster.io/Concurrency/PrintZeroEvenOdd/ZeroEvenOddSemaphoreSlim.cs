namespace PrintZeroEvenOdd
{
    internal class ZeroEvenOddSemaphoreSlim(int n)
    {
        readonly SemaphoreSlim zeroSemaphoreSlim = new(1); // Start with zero's turn
        readonly SemaphoreSlim oddSemaphoreSlim = new(0); // Start with odd's turn blocked
        readonly SemaphoreSlim evenSemaphoreSlim = new(0); // Start with even's turn blocked
        public void Zero()
        {
            for (int i = 1; i < n + 1; i++)
            {
                zeroSemaphoreSlim.Wait(); // Wait for zero's turn
                Console.Write("0");
                // Release the appropriate semaphore based on which number comes next
                if (i % 2 == 1)
                {
                    oddSemaphoreSlim.Release(); // Next is odd (1, 3, 5, ...)
                }
                else
                {
                    evenSemaphoreSlim.Release(); // Next is even (2, 4, 6, ...)
                }
            }
        }
        public void Odd()
        {
            for (int i = 1; i < n + 1; i += 2)
            {
                oddSemaphoreSlim.Wait(); // Wait for odd's turn
                Console.Write(i);
                zeroSemaphoreSlim.Release(); // Transition to zero's turn
            }
        }
        public void Even()
        {
            for (int i = 2; i < n; i += 2)
            {
                evenSemaphoreSlim.Wait(); // Wait for even's turn
                Console.Write(i);
                zeroSemaphoreSlim.Release(); // Transition to zero's turn
            }
        }
    }
}
