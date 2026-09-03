namespace PrintFooBar
{
    internal class FooBarNaive(int n)
    {
        volatile bool fooTurn = true;
        public void Foo()
        {
            for (int i = 0; i < n; i++)
            {
                // Spin until it's foo's turn
                while (!fooTurn) ; // Busy waiting - wastes CPU!
                Console.Write("foo"); // Print "foo"
                fooTurn = false; // Signal bar's turn
            }
            
        }
        public void Bar()
        {
            for (int i = 0; i < n; i++)
            {
                // Spin until it's bar's turn
                while (fooTurn) ; // Busy waiting - wastes CPU!
                Console.Write("bar"); // Print "bar"
                fooTurn = true; // Signal foo's turn
            }
        }
    }
}
