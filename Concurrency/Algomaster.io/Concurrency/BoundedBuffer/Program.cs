// Small capacity to force threads to wait/block frequently
using BoundedBuffer;

// Allow choosing example via command line: "lockfree" runs the LockFreeRingBuffer SPSC demo
var mode = args.Length > 0 ? args[0] : string.Empty;
if (mode.Equals("lockfree", StringComparison.OrdinalIgnoreCase))
{
    // Single-producer single-consumer demo using LockFreeRingBuffer
    const int itemCount = 100;
    var buffer = new LockFreeRingBuffer<int>(16);

    var producer = Task.Run(() =>
    {
        for (int i = 1; i <= itemCount; i++)
        {
            // spin until there's space (SPSC)
            while (!buffer.TryProduce(i))
            {
                Thread.Yield();
            }
            Console.WriteLine($"P produced: {i}");
            Thread.Sleep(5);
        }
    });

    var consumer = Task.Run(() =>
    {
        int consumed = 0;
        while (consumed < itemCount)
        {
            if (!buffer.TryConsume(out var item))
            {
                Thread.Yield();
                continue;
            }
            // TryConsume returns default(T) when empty; producer emits values 1..itemCount so 0 == empty
            if (EqualityComparer<int>.Default.Equals(item, default))
            {
                Thread.Yield();
                continue;
            }
            Console.WriteLine($"C consumed: {item}");
            consumed++;
        }
    });

    Task.WaitAll(producer, consumer);
    Console.WriteLine("LockFree demo complete.");
}
else
{
    var buffer = new SemaphoreBoundedBuffer<int>(5);
    var cts = new CancellationTokenSource();

    int producerCount = 3;
    int consumerCount = 2;

    Console.WriteLine($"Starting {producerCount} Producers and {consumerCount} Consumers...");

    // 1. Launch Multiple Producers
    for (int i = 1; i <= producerCount; i++)
    {
        int producerId = i;
        _ = Task.Run(() =>
        {
            int item = 0;
            while(true)//while (!cts.Token.IsCancellationRequested)
            {
                // Unique item ID for tracking
                int val = (producerId * 1000) + item++;
                buffer.Produce(val);

                Console.WriteLine($"P{producerId} produced: {val}");
                Thread.Sleep(new Random().Next(100, 500)); // Variable speed
            }
        }, cts.Token);
    }

    // 2. Launch Multiple Consumers
    for (int i = 1; i <= consumerCount; i++)
    {
        int consumerId = i;
        _ = Task.Run(() =>
        {
            while (true)//while (!cts.Token.IsCancellationRequested)
            {
                int val = buffer.Consume();

                Console.WriteLine($"      C{consumerId} consumed: {val}");
                Thread.Sleep(new Random().Next(500, 1500)); // Slower consumers
            }
        }, cts.Token);
    }

    Console.WriteLine("Press any key to terminate simulation...");
    Console.ReadKey();
    cts.Cancel();
}
