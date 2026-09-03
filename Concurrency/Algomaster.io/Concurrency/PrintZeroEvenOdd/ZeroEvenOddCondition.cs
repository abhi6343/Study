namespace PrintZeroEvenOdd
{
    internal class ZeroEvenOddCondition(int n)
    {
        enum State { ZeroBeforeOdd, Odd, ZeroBeforeEven, Even }
        State state = State.ZeroBeforeOdd;
        readonly object lockObj = new();
        public void Zero()
        {
            for (int i = 1; i < n + 1; i++)
            {
                lock (lockObj)
                {
                    // Wait while not in a "before" state
                    while (state != State.ZeroBeforeOdd && state != State.ZeroBeforeEven)
                    {
                        Monitor.Wait(lockObj);
                    }
                    Console.Write("0"); // Print "0"
                    // Transition to Odd or Even based on which state we were in
                    state = (state == State.ZeroBeforeOdd) ? State.Odd : State.Even;
                    Monitor.PulseAll(lockObj);  // Wake waiting threads
                }
            }
        }
        public void Odd()
        {
            for (int i = 1; i < n + 1; i += 2)
            {
                lock (lockObj)
                {
                    while (state != State.Odd)
                    {
                        Monitor.Wait(lockObj);
                    }
                    Console.Write(i);
                    state = State.ZeroBeforeEven;
                    Monitor.PulseAll(lockObj);  // Wake waiting threads
                }
            }
        }

        public void Even()
        {
            for (int i = 2; i < n; i += 2)
            {
                lock (lockObj)
                {
                    while (state != State.Even)
                    {
                        Monitor.Wait(lockObj);
                    }
                    Console.Write(i);
                    state = State.ZeroBeforeOdd;
                    Monitor.PulseAll(lockObj);  // Wake waiting threads
                }
            }
        }
    }
}
