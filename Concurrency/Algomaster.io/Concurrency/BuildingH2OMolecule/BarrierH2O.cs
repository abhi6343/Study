namespace BuildingH2OMolecule
{
    internal class BarrierH2O
    {
        readonly SemaphoreSlim _hydrogenSemSlim = new(2);  // Allow 2 H
        readonly SemaphoreSlim _oxygenSemSlim = new(1);    // Allow 1 O

        // Barrier for 3 threads; action runs when all arrive
        private readonly Barrier _barrier;

        public BarrierH2O()
        {
            _barrier = new Barrier(3, (b) =>
            {
                // Release permits for next molecule
                _hydrogenSemSlim.Release(2);
                _oxygenSemSlim.Release();
            });
        }

        public void Hydrogen()
        {
            _hydrogenSemSlim.Wait();  // Limit to 2 H per molecule
            Console.Write("H");
            _barrier.SignalAndWait();  // Wait for 2H + 1O
        }

        public void Oxygen()
        {
            _oxygenSemSlim.Wait();    // Limit to 1 O per molecule
            Console.Write("O");
            _barrier.SignalAndWait();  // Wait for 2H + 1O
        }
    }
}
