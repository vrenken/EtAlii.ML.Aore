namespace EtAlii.ML.Aore.Service
{
    using System;
    using System.Threading.Tasks;
    using Grpc.Core;
    using Microsoft.Extensions.Logging;

    public class ConceptsGrpcService : ConceptsService.ConceptsServiceBase
    {
        private readonly ILogger<ConceptsGrpcService> _logger;

        public ConceptsGrpcService(ILogger<ConceptsGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply2> SayHello(HelloRequest2 request, ServerCallContext context)
        {
            _logger.LogInformation("Message received at: {Time}", DateTimeOffset.Now);

            return Task.FromResult(new HelloReply2 {Message = "Hello " + request.Name});
        }
    }
}
