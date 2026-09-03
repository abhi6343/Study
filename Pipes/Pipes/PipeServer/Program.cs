using System.IO.Pipes;
using System.Text;

using var pipeServer = new NamedPipeServerStream("MyPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

Console.WriteLine("Waiting for client...");

await pipeServer.WaitForConnectionAsync();

Console.WriteLine("Client connected.");

while (true)
{
    var buffer = new byte[1024];

    int bytesRead = await pipeServer.ReadAsync(buffer);
    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine("Received at server: " + message);


    var responseMessage = Console.ReadLine();
    await pipeServer.WriteAsync(Encoding.UTF8.GetBytes(responseMessage ?? string.Empty));
    await pipeServer.FlushAsync();
}

//Console.WriteLine("Received: " + message);