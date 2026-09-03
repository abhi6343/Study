namespace PrintFooBar
{
    internal class FooBarYield (int n)
    {
        volatile bool fooTurn = true;

        public void Foo()
        {
            for(int i = 0; i < n; i++)
            {
                while (!fooTurn)
                {
                    Thread.Yield(); // Give up CPU instead of spinning
                }
                Console.Write("foo");
                fooTurn = false;
            }
        }

        public void Bar()
        {
            for (int i = 0; i < n; i++)
            {
                while (fooTurn)
                {
                    Thread.Yield(); // Give up CPU instead of spinning
                }
                Console.Write("bar");
                fooTurn = true;
            }
        }
    }
}
