namespace EtAlii.ML.Aore.Service
{
    using Grpc.HealthCheck;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class WebHostStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                if (env.IsDevelopment())
                {
                    endpoints.MapHealthChecks("/health");
                    endpoints.MapGrpcService<HealthServiceImpl>();
                }

                endpoints.MapGrpcService<AspectsGrpcService>();
                endpoints.MapGrpcService<ConceptsGrpcService>();

                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response
                            .WriteAsync("Communication with gRPC endpoints must be made through a gRPC client.")
                            .ConfigureAwait(false);
                    });
            });
        }
    }
}
