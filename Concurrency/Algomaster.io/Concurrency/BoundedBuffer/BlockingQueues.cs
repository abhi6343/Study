using System.Threading.Channels;

namespace BoundedBuffer
{
    internal class BlockingQueues
    {
        //var buffer = Channel.CreateBounded<string>(100);
        //await buffer.Writer.WriteAsync("item");  // Blocks if full
        //var item = await buffer.Reader.ReadAsync();  // Blocks if empty
    }
}
