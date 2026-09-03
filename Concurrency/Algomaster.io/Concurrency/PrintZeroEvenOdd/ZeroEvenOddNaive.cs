namespace PrintZeroEvenOdd
{
    internal class ZeroEvenOddNaive (int n)
    {
        // States: 0 = zero before odd, 1 = odd, 2 = zero before even, 3 = even
        int state = 0;
        public void Zero()
        {
            for(int i = 0; i < n; i++)
            {
                // Wait for state 0 (before odd) or 2 (before even)
                while (Volatile.Read(ref state) % 2 != 0) ; // Busy waiting - wastes CPU!
                Console.Write("0"); // Print "0"
                // Transition: 0->1 (to odd) or 2->3 (to even)
                Interlocked.Increment(ref state);
            }
        }
        public void Odd()
        {
            for (int i = 1; i < n + 1; i += 2)
            {
                // Wait for state 1 (odd's turn)
                while (Volatile.Read(ref state) != 1) ; // Busy waiting
                Console.Write(i); // Print odd number
                Volatile.Write(ref state, 2);  // Transition to "zero before even"
            }
        }
        public void Even()
        {
            for (int i = 2; i < n; i += 2)
            {
                // Wait for state 3 (even's turn)
                while (Volatile.Read(ref state) != 3) ; // Busy waiting
                Console.Write(i); // Print even number
                Volatile.Write(ref state, 0);  // Transition to "zero before odd"
            }
        }        
    }
}
