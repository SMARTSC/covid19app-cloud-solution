using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Extensions;
using System;
using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService
{
    internal class Program
    {
        internal static async System.Threading.Tasks.Task Main(string[] args)
        {
            var isWindowsService = (!System.Diagnostics.Debugger.IsAttached && args.Contains("--ws"));

            if (isWindowsService)
            {
                var pathToExe = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = System.IO.Path.GetDirectoryName(pathToExe);

                System.IO.Directory.SetCurrentDirectory(pathToContentRoot);
            }

            var hostBuilder = new HostBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(hostContext.HostingEnvironment.ContentRootPath);
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                .ConfigureLogging((hostContext, config) =>
                {
                    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();

                    config.AddSerilog(Log.Logger);

                    if (!isWindowsService)
                    {
                        config.AddConsole();
                        config.AddDebug();
                    }
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<Options.PerformanceOptions>(hostContext.Configuration.GetSection("Performance"));
                    services.Configure<Options.DataSourceUpstreamOptions>(hostContext.Configuration.GetSection("DataSourceUpstream"));
                    services.Configure<Options.CloudOptions>(hostContext.Configuration.GetSection("Cloud"));

                    services.AddLogging();

                    services.AddSingleton<SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade, Providers.HttpClientHelperProvider>();
                    services.AddScoped<Workers.Facade.IAsyncWorker, Workers.PrimaryDataSourceUpdateAsyncWorker>();

                    services.AddHostedService<Instances.PrimaryDataSourceUpdateHostedServiceIntance>();
                });

            if (isWindowsService)
            {
                hostBuilder.UseServiceBaseLifetime();
            }
            else
            {
                hostBuilder.UseConsoleLifetime();
            }

            using (var host = hostBuilder.Build())
            {
                await host.StartAsync();

                await host.WaitForShutdownAsync();
            }
        }
    }
}
