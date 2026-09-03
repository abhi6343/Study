namespace BoundedBuffer
{
    internal class MonitorBarbershop(int _numChairs)
    {
        readonly object _lock = new();

        int _waiting = 0, _nextTicket = 0, _nowServing = -1;
        bool _barberReady = false;
        readonly Queue<int> _customerQueue = new();

        public void Barber()
        {
            while (true)
            {
                lock (_lock)
                {
                    // Wait for a customer
                    while (_waiting == 0)
                    {
                        Console.WriteLine("Barber is sleeping");
                        Monitor.Wait(_lock);
                    }

                    // Get next customer
                    _waiting--;
                    _nowServing = _customerQueue.Dequeue();
                    _barberReady = true;
                    Monitor.PulseAll(_lock);  // Wake the right customer
                }

                // Cut hair outside lock
                CutHair();

                lock (_lock)
                {
                    _barberReady = false;
                }
            }
        }

        public bool Customer(int id)
        {
            lock (_lock)
            {
                if (_waiting >= _numChairs)
                {
                    Console.WriteLine($"Customer {id} leaves (no chairs)");
                    return false;
                }

                // Take a ticket and sit
                int myTicket = _nextTicket++;
                _customerQueue.Enqueue(myTicket);
                _waiting++;
                Console.WriteLine($"Customer {id} sits (ticket {myTicket})");

                // Wake the barber
                Monitor.Pulse(_lock);

                // Wait for our turn
                while (!_barberReady || _nowServing != myTicket)
                {
                    Monitor.Wait(_lock);
                }
            }

            GetHaircut(id);
            return true;
        }

        static void CutHair()
        {
            Console.WriteLine("Barber is cutting hair");
            Thread.Sleep(100);
        }

        static void GetHaircut(int id)
        {
            Console.WriteLine($"Customer {id} is getting haircut");
        }
    }
}
