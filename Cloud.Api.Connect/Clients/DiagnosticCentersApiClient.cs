namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Connect.Clients
{
    public class DiagnosticCentersApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.DiagnosticCenter, string, Common.Models.DiagnosticCenterInputModel, Common.Models.DiagnosticCenterDisplayModel>
    {
        public DiagnosticCentersApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/diagnosticcenters";
    }
}
