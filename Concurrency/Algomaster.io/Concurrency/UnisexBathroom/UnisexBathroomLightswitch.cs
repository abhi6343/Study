namespace UnisexBathroom
{
    internal class UnisexBathroomSemaphoreSlimLightswitch (int capacity) : IUniSexBathroom
    {
        readonly SemaphoreSlim _bathroomSemlim = new(capacity);  // Controls capacity
        readonly SemaphoreSlim _genderSemSlim = new(1);  // Gender exclusivity

        int _menCount = 0, _womenCount = 0;
        readonly Lock _menLock = new();
        readonly Lock _womenLock = new();

        public void ManEnter()
        {
            lock (_menLock)
            {
                _menCount++;
                if (_menCount == 1)
                {
                    _genderSemSlim.Wait();  // First man locks out women
                }
            }
            _bathroomSemlim.Wait();  // Wait for capacity
        }

        public void ManLeave()
        {
            _bathroomSemlim.Release();
            lock (_menLock)
            {
                _menCount--;
                if (_menCount == 0)
                {
                    _genderSemSlim.Release();  // Last man allows women
                }
            }
        }

        public void WomanEnter()
        {
            lock (_womenLock)
            {
                _womenCount++;
                if (_womenCount == 1)
                {
                    _genderSemSlim.Wait();  // First woman locks out men
                }
            }
            _bathroomSemlim.Wait();  // Wait for capacity
        }

        public void WomanLeave()
        {
            _bathroomSemlim.Release();
            lock (_womenLock)
            {
                _womenCount--;
                if (_womenCount == 0)
                {
                    _genderSemSlim.Release();  // Last woman allows men
                }
            }
        }
    }
}
