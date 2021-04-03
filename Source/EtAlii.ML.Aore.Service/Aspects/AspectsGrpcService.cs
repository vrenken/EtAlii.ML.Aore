namespace EtAlii.ML.Aore.Service
{
    using System;
    using System.Threading.Tasks;
    using Grpc.Core;
    using Microsoft.Extensions.Logging;

    public class AspectsGrpcService : AspectsService.AspectsServiceBase
    {
        private readonly ILogger<AspectsGrpcService> _logger;

        public AspectsGrpcService(ILogger<AspectsGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Message received at: {Time}", DateTimeOffset.Now);

            return Task.FromResult(new HelloReply {Message = "Hello " + request.Name});
        }
    }
}
