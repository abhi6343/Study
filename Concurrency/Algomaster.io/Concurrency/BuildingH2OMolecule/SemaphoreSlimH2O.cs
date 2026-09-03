namespace BuildingH2OMolecule
{
    internal class SemaphoreSlimH2O
    {
        readonly SemaphoreSlim _hydrogenQueue = new(0);  // H waits here
        readonly SemaphoreSlim _oxygenQueue = new(0);    // O waits here
        readonly Lock _lock = new();
        int _hydrogenCount = 0, _oxygenCount = 0;

        public void Hydrogen()
        {
            lock (_lock)
            {
                _hydrogenCount++;

                if (_hydrogenCount == 2 && _oxygenCount == 1)
                {
                    // We have enough to form a molecule
                    _hydrogenQueue.Release(2);  // Release 2 H
                    _hydrogenCount -= 2;
                    _oxygenQueue.Release();     // Release 1 O
                    _oxygenCount -= 1;
                }
            }

            while (_hydrogenCount == 2)
            {
                _hydrogenQueue.Wait();  // Wait for molecule formation
            }

            Console.Write("H");
        }

        public void Oxygen()
        {
            lock (_lock)
            {
                _oxygenCount++;

                if (_hydrogenCount == 2 && _oxygenCount == 1)
                {
                    // We have enough to form a molecule
                    _hydrogenQueue.Release(2); // Release 2 H
                    _hydrogenCount -= 2;
                    _oxygenQueue.Release();    // Release 1 O
                    _oxygenCount -= 1;
                }
            }

            while (_oxygenCount == 1)
            {
                _oxygenQueue.Wait();
            }

            Console.Write("O");
        }
    }
}
