using UnisexBathroom;

//var bathroom = new UnisexBathroomNaive();
//var bathroom = new UnisexBathroomCondition(3);
//var bathroom = new UnisexBathroomFair(3);
var bathroom = new UnisexBathroomSemaphoreSlimLightswitch(3);
Random rand = new();

// Create a mix of 10 people (threads)
for (int i = 1; i <= 10; i++)
{
    int personId = i;
    if (rand.Next(2) == 0)
    {
        new Thread(() => SimulateMan(bathroom, personId)).Start();
    }
    else
    {
        new Thread(() => SimulateWoman(bathroom, personId)).Start();
    }
}
        

static void SimulateMan(IUniSexBathroom bathroom, int id)
{
    Console.WriteLine($"Man {id} is waiting...");
    bathroom.ManEnter();

    Console.WriteLine($"[ENTER] Man {id} is in the bathroom.");
    Thread.Sleep(1000); // Simulate time spent inside

    bathroom.ManLeave();
    Console.WriteLine($"[EXIT]  Man {id} has left.");
}

static void SimulateWoman(IUniSexBathroom bathroom, int id)
{
    Console.WriteLine($"Woman {id} is waiting...");
    bathroom.WomanEnter();

    Console.WriteLine($"[ENTER] Woman {id} is in the bathroom.");
    Thread.Sleep(1000); // Simulate time spent inside

    bathroom.WomanLeave();
    Console.WriteLine($"[EXIT]  Woman {id} has left.");
}