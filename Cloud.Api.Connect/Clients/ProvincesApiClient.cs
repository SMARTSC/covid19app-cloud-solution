using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Connect.Clients
{
    public class ProvincesApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Province, int, ProvinceInputModel, ProvinceDisplayModel>
    {
        public ProvincesApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/provinces";
    }
}
