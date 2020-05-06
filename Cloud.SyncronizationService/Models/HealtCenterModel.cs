using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Models
{
    internal class HealtCenterModel
    {
        [JsonProperty(PropertyName = "id")]
        internal string Id { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        internal string Name { get; set; }

        [JsonProperty(PropertyName = "dpacode_provincia")]
        internal string ProvinceCode { get; set; }

        [JsonProperty(PropertyName = "provincia")]
        internal string ProvinceName { get; set; }
    }
}
