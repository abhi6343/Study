namespace UnisexBathroom
{
    internal class UnisexBathroomCondition (int _capacity) : IUniSexBathroom
    {
        enum Gender { Empty, Men, Women }

        Gender _currentGender = Gender.Empty;
        int _count = 0;
        readonly object _lock = new();

        public void ManEnter()
        {
            lock (_lock)
            {
                // Wait while women inside or at capacity
                while (_currentGender == Gender.Women || _count >= _capacity)
                {
                    Monitor.Wait(_lock);
                }
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
                    Monitor.PulseAll(_lock);  // Wake waiting threads
                }
            }
        }

        public void WomanEnter()
        {
            lock (_lock)
            {
                // Wait while men inside or at capacity
                while (_currentGender == Gender.Men || _count >= _capacity)
                {
                    Monitor.Wait(_lock);
                }
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
                    Monitor.PulseAll(_lock);  // Wake waiting threads
                }
            }
        }
    }
}
