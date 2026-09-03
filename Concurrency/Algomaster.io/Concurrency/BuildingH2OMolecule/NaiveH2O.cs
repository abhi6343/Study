namespace BuildingH2OMolecule
{
    internal class NaiveH2O
    {
        int hCount = 0, oCount = 0;
        readonly object lockObj = new();

        public void Hydrogen()
        {
            lock (lockObj)
            {
                // Wait if 2 hydrogens are already waiting
                while (hCount == 2)
                {
                    Monitor.Wait(lockObj);
                }
                hCount++;

                Console.Write("H");

                // When 2 H and 1 O are present, release them
                if (hCount == 2 && oCount == 1)
                {
                    hCount = 0;
                    oCount = 0;
                }
                Monitor.PulseAll(lockObj);
            }
        }

        public void Oxygen()
        {
            lock (lockObj)
            {
                // Wait if an oxygen is already waiting
                while (oCount == 1)
                {
                    Monitor.Wait(lockObj);
                }
                oCount++;

                Console.Write("O");
                // When 2 H and 1 O are present, release them
                if (hCount == 2 && oCount == 1)
                {
                    hCount = 0;
                    oCount = 0;
                }
                Monitor.PulseAll(lockObj);
            }
        }
    }
}
