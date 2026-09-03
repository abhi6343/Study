using Dummy;
using Greet;
using Grpc.Core;
using PrimeDecomposition;
using Sum;

const string target = "127.0.0.1:50051";
Grpc.Core.Channel channel = new(target, ChannelCredentials.Insecure);
await channel.ConnectAsync().ContinueWith((task) =>
{
    if (task.Status == TaskStatus.RanToCompletion)
    {
        Console.WriteLine("The client connected successfully");
    }
});

//var client = new DummyService.DummyServiceClient(channel);

//var client = new GreetingService.GreetingServiceClient(channel);
//var greeting = new Greeting()
//{
//    FirstName = "Abhishek",
//    LastName = "Gupta"
//};

//var request = new GreetingRequest() { Greeting = greeting };
//var response = client.Greet(request);
//Console.WriteLine(response.Result);


//Console.Write("Enter first Number: ");
//var first = Console.ReadLine();
//Console.Write("Enter second Number: ");
//var second = Console.ReadLine();

//var client = new Sum.SumService.SumServiceClient(channel);
//var vals = new Sum.Sum()
//{
//    FirstVal = Convert.ToInt32(first),
//    SecondVal = Convert.ToInt32(second)
//};

//var request = new SumRequest() { Sum = vals };
//var response = client.Summing(request);
//Console.WriteLine($"Sum of {first} and {second} is {response.Result}\r\n\r\n");


//var client = new GreetingService.GreetingServiceClient(channel);
//var greeting = new Greeting()
//{
//    FirstName = "Abhishek",
//    LastName = "Gupta"
//};

//var request = new GreetManyTimesRequest() { Greeting = greeting };
//var response = client.GreetManyTimes(request);

//while (await response.ResponseStream.MoveNext())
//{
//    Console.WriteLine(response.ResponseStream.Current.Result);
//    await Task.Delay(200);
//}


Console.Write("Enter the number you want prime factors for: ");
if (int.TryParse(Console.ReadLine(), out var num))
{
    var client = new primeDecompositionService.primeDecompositionServiceClient(channel);
    var request = new primeDecompositionRequest() { Number = num };
    var response = client.GetPrimeDecomposition(request);

    while (await response.ResponseStream.MoveNext())
    {
        Console.WriteLine(response.ResponseStream.Current.PrimeFactor);
        await Task.Delay(200);
    }
}

channel.ShutdownAsync().Wait();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();