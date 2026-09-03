using Grpc.Core;
using PrimeDecomposition;
using static PrimeDecomposition.primeDecompositionService;

namespace Server.ServieImpl
{
    internal class PrimeDecompositionServiceImpl : primeDecompositionServiceBase
    {
        public override async Task GetPrimeDecomposition(primeDecompositionRequest request, IServerStreamWriter<primeDecompositionResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"The server received the request: {request.GetType()} {request}");

            int divisor = 2, number = request.Number;
            while (number > 1)
            {
                if (number % divisor == 0)
                {
                    await responseStream.WriteAsync(new primeDecompositionResponse() { PrimeFactor = divisor });
                    number /= divisor;
                }
                else
                {
                    divisor++;
                }
            }
        }
    }
}
