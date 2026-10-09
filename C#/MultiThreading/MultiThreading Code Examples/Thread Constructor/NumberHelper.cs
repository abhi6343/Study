namespace ThreadConstructor
{
    internal class NumberHelper
    {
        int _Number;
        public NumberHelper(int Number)
        {
            _Number = Number;
        }
        public void DisplayNumbers()
        {
            for (int i = 1; i <= _Number; i++)
            {
                Console.WriteLine("value : " + i);
            }
        }
    }
}
