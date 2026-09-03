namespace PrintFooBar
{
    internal class FooBarSemaphoreSlim(int n)
    {
        readonly SemaphoreSlim fooSemaphoreSlim = new(1, 1); // Start with foo allowed to print
        readonly SemaphoreSlim barSemaphoreSlim = new(0, 1); // Start with bar blocked

        public void Foo()
        {
            for (int i = 0; i < n; i++)
            {
                fooSemaphoreSlim.Wait(); // Wait for foo's turn
                Console.Write("foo"); // Print "foo"
                barSemaphoreSlim.Release(); // Signal bar's turn
            }
        }

        public void Bar() 
        { 
            for (int i = 0; i < n; i++)
            {
                barSemaphoreSlim.Wait(); // Wait for bar's turn
                Console.Write("bar"); // Print "bar"
                fooSemaphoreSlim.Release(); // Signal foo's turn
            }
        }        
    }
}
