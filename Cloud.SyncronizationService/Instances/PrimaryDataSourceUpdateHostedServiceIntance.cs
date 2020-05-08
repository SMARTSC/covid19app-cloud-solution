using Microsoft.Extensions.Logging;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Instances
{
    internal class PrimaryDataSourceUpdateHostedServiceIntance : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly ILogger<PrimaryDataSourceUpdateHostedServiceIntance> logger;
        private readonly Microsoft.Extensions.Options.IOptions<Options.BehaviorOptions> behaviorOptions;
        private readonly Workers.Facade.IAsyncWorker worker;

        public PrimaryDataSourceUpdateHostedServiceIntance(Workers.Facade.IAsyncWorker worker, ILogger<PrimaryDataSourceUpdateHostedServiceIntance> logger, Microsoft.Extensions.Options.IOptions<Options.BehaviorOptions> behaviorOptions)
        {
            this.logger = logger;
            this.behaviorOptions = behaviorOptions;
            this.worker = worker;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.Delay(behaviorOptions.Value.StartUpDelayTime);

            while (!cancellationToken.IsCancellationRequested)
            {
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested) break;

                    try
                    {
                        await worker.DoWorkAsync(cancellationToken);

                        if (cancellationToken.IsCancellationRequested) break;

                        var endedAtDateTime = System.DateTime.Now;

                        var endAtDate = endedAtDateTime.Date;

                        var nextDailySyncronizationDate = endAtDate.AddDays(1) + behaviorOptions.Value.DailySyncronizationStartTime;

                        var delayTime = nextDailySyncronizationDate - endedAtDateTime;

                        if (delayTime < System.TimeSpan.Zero)
                        {
                            nextDailySyncronizationDate = nextDailySyncronizationDate.AddDays(1);

                            delayTime = nextDailySyncronizationDate - endedAtDateTime;
                        }

                        await System.Threading.Tasks.Task.Delay(delayTime);
                    }
                    catch (Exceptions.NotUpdatedDataSourceException)
                    {
                        await System.Threading.Tasks.Task.Delay(behaviorOptions.Value.DailySyncronizationRetryDelayTime);
                    }
                    catch (System.Net.Http.HttpRequestException)
                    {
                        await System.Threading.Tasks.Task.Delay(behaviorOptions.Value.DailySyncronizationRetryDelayTime);
                    }
                    catch (System.Exception exception)
                    {
                        logger.LogError("Worker unhandled exception", exception);

                        throw exception;
                    }
                }
            }
        }
    }
}
