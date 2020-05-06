namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Connect.Clients
{
    public class ReportsApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Report, int, Common.Models.ReportInputModel, Common.Models.ReportDisplayModel>
    {
        public ReportsApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/reports";
    }
}
