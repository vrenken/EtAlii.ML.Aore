namespace EtAlii.ML.Aore.Service
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Grpc.Health.V1;
    using Grpc.HealthCheck;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class AspectsTrainingWorker : BackgroundService
    {
        private readonly ILogger<AspectsTrainingWorker> _logger;
        private readonly HealthServiceImpl _healthService;
        private readonly HealthCheckService _healthCheckService;

        public AspectsTrainingWorker(
            ILogger<AspectsTrainingWorker> logger,
            HealthServiceImpl healthService,
            HealthCheckService healthCheckService)
        {
            _logger = logger;
            _healthService = healthService;
            _healthCheckService = healthCheckService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var health = await _healthCheckService
                    .CheckHealthAsync(stoppingToken)
                    .ConfigureAwait(false);

                var healthStatus = health.Status == HealthStatus.Healthy ? HealthCheckResponse.Types.ServingStatus.Serving : HealthCheckResponse.Types.ServingStatus.NotServing;
                _healthService.SetStatus(nameof(AspectsTrainingWorker), healthStatus);

                _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
            }
        }
    }
}
