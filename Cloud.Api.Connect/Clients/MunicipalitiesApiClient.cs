namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Connect.Clients
{
    public class MunicipalitiesApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Municipality, int, Common.Models.MunicipalityInputModel, Common.Models.MunicipalityDisplayModel>
    {
        public MunicipalitiesApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/municipalities";
    }
}
