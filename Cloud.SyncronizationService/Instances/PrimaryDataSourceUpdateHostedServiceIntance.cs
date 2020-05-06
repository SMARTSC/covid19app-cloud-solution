using Microsoft.Extensions.Logging;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Instances
{
    internal class PrimaryDataSourceUpdateHostedServiceIntance : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly ILogger<PrimaryDataSourceUpdateHostedServiceIntance> logger;
        private readonly Microsoft.Extensions.Options.IOptions<Options.PerformanceOptions> performanceOptions;
        private readonly Workers.Facade.IAsyncWorker worker;

        public PrimaryDataSourceUpdateHostedServiceIntance(Workers.Facade.IAsyncWorker worker, ILogger<PrimaryDataSourceUpdateHostedServiceIntance> logger, Microsoft.Extensions.Options.IOptions<Options.PerformanceOptions> performanceOptions)
        {
            this.logger = logger;
            this.performanceOptions = performanceOptions;
            this.worker = worker;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(30));

            while (!cancellationToken.IsCancellationRequested)
            {
                var startedAt = System.DateTime.Now;

                logger.LogDebug("Request handling iteration started at {0}", startedAt);

                try
                {
                    await worker.DoWorkAsync(cancellationToken);
                }
                catch (System.Exception exception)
                {
                    logger.LogError("Worker unhandled exception", exception);
                }

                var endedAt = System.DateTime.Now;

                var elpaseTime = endedAt - startedAt;

                logger.LogDebug("Request handling iteration ended at {0}", endedAt);

                var delayTime = performanceOptions.Value.WorkerRunUpTimeDelay - elpaseTime;

                if (delayTime < System.TimeSpan.Zero || cancellationToken.IsCancellationRequested) continue;

                logger.LogDebug("Request handling iteration weiting {0}", delayTime);

                await System.Threading.Tasks.Task.Delay(delayTime);
            }
        }
    }
}
