// BROKEN: Race conditions everywhere
namespace SleepingBarber
{
    internal class NaiveBarbershop (int _numChairs)
    {
        int _waitingCustomers = 0;
        bool _barberSleeping = false;

        public void Barber()
        {
            while (true)
            {
                // RACE: Check and sleep not atomic
                if (_waitingCustomers == 0)
                {
                    _barberSleeping = true;
                    // Sleep somehow... but how to wake up?
                }
                // Cut hair
                _waitingCustomers--;
                CutHair();
            }
        }

        public void Customer()
        {
            // RACE: Check and sit not atomic
            if (_waitingCustomers < _numChairs)
            {
                _waitingCustomers++;
                if (_barberSleeping)
                {
                    // Wake barber... but signal might be lost
                }
                // Wait for haircut...
            }
            else
            {
                // Leave
            }
        }

        private void CutHair() { /* ... */ }
    }
}
