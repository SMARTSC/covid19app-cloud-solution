namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Connect.Clients
{
    public class EventsApiClient : SAPRESSC.Core.Api.Connect.Clients.AbstractEntityApiManagementClient<Persistence.Entities.Event, string, Common.Models.EventInputModel, Common.Models.EventDisplayModel>
    {
        public EventsApiClient(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "backend/events";
    }
}
