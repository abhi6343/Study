namespace ThreadConstructor
{
    // First, Create the callback delegate with the same signature of the callback method
    public delegate void ResultCallbackDelegate(int Results);

    //Creating the Helper class
    internal class NumberHelperReturn
    {
        //Creating two private variables to hold the Number and ResultCallback
        private readonly int _Number;
        private readonly ResultCallbackDelegate _resultCallbackDelegate;
        //Initializing the private variables through constructor
        //So while creating the instance you need to pass the value for Number and callback delegate
        public NumberHelperReturn(int Number, ResultCallbackDelegate resultCallbackDelagate)
        {
            _Number = Number;
            _resultCallbackDelegate = resultCallbackDelagate;
        }
        //This is the Thread function which will calculate the sum of the numbers from 1 to the given number and then call the callback method to return the result
        public void CalculateSum()
        {
            int Result = 0;
            for (int i = 1; i <= _Number; i++)
            {
                Result += i;
            }
            //Before the end of the thread function call the callback method
            if (_resultCallbackDelegate != null)
            {
                _resultCallbackDelegate(Result);
            }
        }
    }
}
