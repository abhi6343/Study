using Greet;
using Grpc.Core;
using Sum;
using System;
using System.Collections.Generic;
using System.Text;
using static Sum.SumService;

namespace Server.ServieImpl
{
    internal class SumServiceImpl : SumServiceBase
    {
        public override Task<SumResponse> Summing(SumRequest request, ServerCallContext context)
        {
            int result = request.Sum.FirstVal + request.Sum.SecondVal;
            return Task.FromResult(new SumResponse() { Result = result });
        }
    }
}
