namespace PrintZeroEvenOdd
{
    internal class ZeroEvenOddMultiCondition (int n)
    {
        readonly AutoResetEvent zeroEvent = new(true);  // start with zero
        readonly AutoResetEvent oddEvent = new(false);  // for odd prints
        readonly AutoResetEvent evenEvent = new(false); // for even prints

        public void Zero()
        {
            //for (int i = 1; i <= n; i++)
            //foreach (var i in Enumerable.Range(1, n))
            foreach (var i in n.GetNumbers())
            {
                //new List<int> { 1,2,3}.EmptyIfNull().ForEach(i => Console.Write(i));
                zeroEvent.WaitOne();
                Console.Write("0");
                if ((i & 1) == 1)
                    oddEvent.Set();
                else
                    evenEvent.Set();
            }
        }

        public void Odd()
        {
            for (int i = 1; i <= n; i += 2)
            {
                oddEvent.WaitOne();
                Console.Write(i);
                zeroEvent.Set();
            }
        }

        public void Even()
        {            
            for (int i = 2; i <= n; i += 2)
            {
                evenEvent.WaitOne();
                Console.Write(i);
                zeroEvent.Set();
            }
        }
    }
}
