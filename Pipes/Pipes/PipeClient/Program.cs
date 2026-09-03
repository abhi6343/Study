using System.IO.Pipes;
using System.Text;

using var pipeClient = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut, PipeOptions.Asynchronous);

Console.WriteLine("Connecting...");

await pipeClient.ConnectAsync();

Console.WriteLine("Connected.");
while (true)
{    
    var message = Console.ReadLine();

    // Send the message to the server
    var SendData = Encoding.UTF8.GetBytes(message??string.Empty);

    await pipeClient.WriteAsync(SendData);
    await pipeClient.FlushAsync();

    // Receive from the server
    var receiveBuffer = new byte[4096];
    var bytesRead = await pipeClient.ReadAsync(receiveBuffer);
    if (bytesRead == 0)
    {
        Console.WriteLine("Server disconnected.");
        break;
    }

    message = Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead);
    Console.WriteLine("Received at client: " + message);
}