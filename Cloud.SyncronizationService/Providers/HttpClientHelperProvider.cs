namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Providers
{
    public sealed class HttpClientHelperProvider : SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private const string API_KEY_HEADER_PROPERTY = "X-Api-Key";

        private readonly Microsoft.Extensions.Options.IOptions<Options.CloudOptions> cloudOptions;

        public HttpClientHelperProvider(Microsoft.Extensions.Options.IOptions<Options.CloudOptions> cloudOptions)
        {
            this.cloudOptions = cloudOptions;
        }

        public SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper HttpClientHelper => new SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper(cloudOptions.Value.BaseUrl, null, GetExtraHeaders);

        private System.Collections.Generic.KeyValuePair<string, string>[] GetExtraHeaders()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>[]
            {
                new System.Collections.Generic.KeyValuePair<string, string>(API_KEY_HEADER_PROPERTY, cloudOptions.Value.Secret)
            };
        }
    }
}
