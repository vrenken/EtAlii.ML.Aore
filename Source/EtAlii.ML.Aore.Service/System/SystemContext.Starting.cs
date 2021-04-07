namespace EtAlii.ML.Aore.Service
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public partial class SystemContext
    {
        private string[] _commandLineArguments;

        protected override Task OnStartingEntered()
        {
            _host = new HostBuilder().Build(_commandLineArguments);
            _logger = ((ILoggerFactory)_host.Services.GetService(typeof(ILoggerFactory))).CreateLogger(typeof(SystemContext));
            _logger.Log(LogLevel.Information,"Starting");

            return Task.CompletedTask;
        }

        protected override void OnStartingExited()
        {
            _logger.Log(LogLevel.Information,"Started");
        }

        protected override async Task OnStartingEnteredFromStartTrigger(string[] commandLineArguments)
        {
            _commandLineArguments = commandLineArguments;

            await ContinueAsync().ConfigureAwait(false);
        }

        protected override async Task OnStartingDatabaseEntered()
        {
            _logger.Log(LogLevel.Information,"Database starting");

            await ContinueAsync().ConfigureAwait(false);
        }

        protected override async Task OnStartingDatabaseExited()
        {

            _logger.Log(LogLevel.Information,"Database started");

            await ContinueAsync().ConfigureAwait(false);
        }

        protected override async Task OnWaitingForGrpcServicesEntered()
        {
            _logger.Log(LogLevel.Information,"Waiting for Grpc services");

            await ContinueAsync().ConfigureAwait(false);
        }

        protected override Task OnWaitingForGrpcServicesExited() => Task.CompletedTask;

        protected override async Task OnWaitingForWorkerServicesEntered()
        {
            _logger.Log(LogLevel.Information,"Waiting for worker services");

            await ContinueAsync().ConfigureAwait(false);
        }

        protected override Task OnWaitingForWorkerServicesExited() => Task.CompletedTask;

        protected override async Task OnStartingHostingEntered()
        {
            _logger.Log(LogLevel.Information,"Hosting starting");
            await _host
                .StartAsync()
                .ConfigureAwait(false);

            await ContinueAsync().ConfigureAwait(false);
        }

        protected override Task OnStartingHostingExited()
        {
            _logger.Log(LogLevel.Information,"Hosting started");
            return Task.CompletedTask;
        }
    }
}
