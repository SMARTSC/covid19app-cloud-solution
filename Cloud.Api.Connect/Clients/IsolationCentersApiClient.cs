namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Connect.Clients
{
    public class IsolationCentersApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.IsolationCenter, string, Common.Models.IsolationCenterInputModel, Common.Models.IsolationCenterDisplayModel>
    {
        public IsolationCentersApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/isolationcenters";
    }
}
