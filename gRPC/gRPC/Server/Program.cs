using Greet;
using Grpc.Core;
using PrimeDecomposition;
using Server.ServieImpl;
using Sum;

const int Port = 50051;
Grpc.Core.Server server = null;
try
{
	server = new()
	{
		Services = { GreetingService.BindService(new GreetingServiceImpl()), SumService.BindService(new SumServiceImpl()), primeDecompositionService.BindService(new PrimeDecompositionServiceImpl()) },
		Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
	};

	server.Start();
    Console.WriteLine("The server is listening on the port: " + Port);
	Console.ReadKey();
}
catch (IOException ex)
{
    Console.WriteLine("The server failed to start: " + ex);
	throw;
}
finally
{
    server?.ShutdownAsync().Wait();
}
