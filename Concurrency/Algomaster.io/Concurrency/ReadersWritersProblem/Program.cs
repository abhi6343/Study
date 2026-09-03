namespace ReadersWritersProblem
{
    public class ReadersWritersDemo
    {
        //readonly ReadersPreferenceRW _rwLock = new();
        readonly WritersPreferenceRW _rwLock = new();
        int _sharedData = 0;
        volatile bool _running = true;
        readonly Random _random = new();

        public void Reader(int id)
        {
            while (_running)
            {
                _rwLock.ReaderAcquire();
                Console.WriteLine($"Reader {id} reads: {_sharedData}");
                Thread.Sleep(_random.Next(50));
                _rwLock.ReaderRelease();
                Thread.Sleep(_random.Next(100));
            }
        }

        public void Writer(int id)
        {
            while (_running)
            {
                _rwLock.WriterAcquire();
                _sharedData++;
                Console.WriteLine($"Writer {id} writes: {_sharedData}");
                Thread.Sleep(_random.Next(100));
                _rwLock.WriterRelease();
                Thread.Sleep(_random.Next(200));
            }
        }

        public void Stop() => _running = false;
        public int GetValue() => _sharedData;
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var demo = new ReadersWritersDemo();
            var threads = new Thread[7];

            // Create 5 readers
            for (int i = 0; i < 5; i++)
            {
                int id = i;
                threads[i] = new Thread(() => demo.Reader(id));
            }
            // Create 2 writers
            for (int i = 0; i < 2; i++)
            {
                int id = i;
                threads[5 + i] = new Thread(() => demo.Writer(id));
            }

            foreach (var t in threads) t.Start();

            Thread.Sleep(2000);
            demo.Stop();

            foreach (var t in threads) t.Join();
            Console.WriteLine($"Demo complete. Final value: {demo.GetValue()}");
        }
    }
}