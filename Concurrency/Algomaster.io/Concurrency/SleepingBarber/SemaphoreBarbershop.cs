namespace SleepingBarber
{
    internal class SemaphoreBarbershop (int _numChairs)
    {
        int _waiting = 0;

        // Customers waiting to be served (barber blocks on this)
        readonly SemaphoreSlim _customers = new(0);
        // Barber ready to serve (customer blocks on this)
        readonly SemaphoreSlim _barberReady = new(0);
        // Lock for accessing waiting count
        readonly SemaphoreSlim _waitCountSemaphoreSlim = new(1, 1);

        public void Barber()
        {
            while (true)
            {
                // Wait for a customer
                _customers.Wait();

                // Get customer from waiting room
                _waitCountSemaphoreSlim.Wait();
                _waiting--;
                // Signal that barber is ready
                _barberReady.Release();
                _waitCountSemaphoreSlim.Release();

                // Cut hair (outside critical section)
                CutHair();
            }
        }

        public bool Customer()
        {
            _waitCountSemaphoreSlim.Wait();

            if (_waiting < _numChairs)
            {
                // There's a free chair
                _waiting++;
                // Signal the barber that a customer is waiting
                _customers.Release();
                _waitCountSemaphoreSlim.Release();

                // Wait for barber to be ready
                _barberReady.Wait();

                // Get haircut (happens after barber signals)
                GetHaircut();
                return true;
            }
            else
            {
                // No free chairs, leave
                _waitCountSemaphoreSlim.Release();
                return false;
            }
        }

        static void CutHair()
        {
            Console.WriteLine("Barber is cutting hair");
            Thread.Sleep(100);
        }

        static void GetHaircut()
        {
            Console.WriteLine("Customer is getting haircut");
        }
    }
}
