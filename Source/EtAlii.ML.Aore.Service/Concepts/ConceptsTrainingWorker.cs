namespace EtAlii.ML.Aore.Service
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class ConceptsTrainingWorker : BackgroundService
    {
        private readonly ILogger<ConceptsTrainingWorker> _logger;

        public ConceptsTrainingWorker(ILogger<ConceptsTrainingWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
            }
        }
    }
}
