namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Workers.Facade
{
    interface IAsyncWorker
    {
        System.Threading.Tasks.Task DoWorkAsync(System.Threading.CancellationToken cancellationToken);
    }
}
