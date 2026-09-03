using BuildingH2OMolecule;

var p = new NaiveH2O();
//var p = new BarrierH2O();
//var p = new SemaphoreSlimH2O();
string input = "HHHHOOOOOOOOHHHHHHHHHHHHOOHHHH"; // Example sequence

var threads = new List<Thread>();

foreach (var ch in input)
{
    if (ch == 'H')
    {
        threads.Add(new(p.Hydrogen));
    }
    else if (ch == 'O')
    {
        threads.Add(new(p.Oxygen));
    }
}

// Start all threads
foreach (var t in threads) t.Start();
// Wait for all to finish
foreach (var t in threads) t.Join();

Console.WriteLine("\nDone");
