namespace UnisexBathroom
{
    internal class UnisexBathroomFair(int _capacity) : IUniSexBathroom
    {
        private enum Gender { Empty, Men, Women }

        Gender _currentGender = Gender.Empty;
        int _count = 0, _waitingMen = 0, _waitingWomen = 0;

        readonly object _lock = new();
        readonly object _menLock = new();
        readonly object _womenLock = new();

        public void ManEnter()
        {
            lock (_lock)
            {
                _waitingMen++;
                // Wait while:
                // 1. Women inside, OR
                // 2. At capacity, OR
                // 3. Women waiting and bathroom is empty (yield to women)
                while (_currentGender == Gender.Women ||
                       _count >= _capacity ||
                       (_currentGender == Gender.Empty && _waitingWomen > 0))
                {
                    Monitor.Wait(_lock);
                }
                _waitingMen--;
                _currentGender = Gender.Men;
                _count++;
            }
        }

        public void ManLeave()
        {
            lock (_lock)
            {
                _count--;
                if (_count == 0)
                {
                    _currentGender = Gender.Empty;
                }
                // Signal all waiters - condition checks will filter
                Monitor.PulseAll(_lock);
            }
        }

        public void WomanEnter()
        {
            lock (_lock)
            {
                _waitingWomen++;
                // Wait while:
                // 1. Men inside, OR
                // 2. At capacity, OR
                // 3. Men waiting and bathroom is empty (yield to men)
                while (_currentGender == Gender.Men ||
                       _count >= _capacity ||
                       (_currentGender == Gender.Empty && _waitingMen > 0))
                {
                    Monitor.Wait(_lock);
                }
                _waitingWomen--;
                _currentGender = Gender.Women;
                _count++;
            }
        }

        public void WomanLeave()
        {
            lock (_lock)
            {
                _count--;
                if (_count == 0)
                {
                    _currentGender = Gender.Empty;
                }
                // Signal all waiters - condition checks will filter
                Monitor.PulseAll(_lock);
            }
        }
    }
}
