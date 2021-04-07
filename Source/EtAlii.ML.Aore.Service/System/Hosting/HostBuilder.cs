namespace EtAlii.ML.Aore.Service
{
    using FileContextCore;
    using FileContextCore.FileManager;
    using FileContextCore.Serializer;
    using Grpc.HealthCheck;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class HostBuilder
    {

        public IHost Build(string[] commandLineArguments)
        {
            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
            return Host
                .CreateDefaultBuilder(commandLineArguments)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    services.AddSingleton<HealthServiceImpl>();

                    services.AddDbContext<DataContext>(options => options.UseFileContextDatabase<JSONSerializer, DefaultFileManager>());
                    services.AddHostedService<AspectsTrainingWorker>();
                    services.AddHostedService<ConceptsTrainingWorker>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<WebHostStartup>();
                })
                .Build();
        }
    }
}
