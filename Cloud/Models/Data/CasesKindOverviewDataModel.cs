using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class CasesKindOverviewDataModel
    {
        [JsonProperty(PropertyName = "imported")]
        public int Imported { get; set; }

        [JsonProperty(PropertyName = "introduced")]
        public int Introduced { get; set; }

        [JsonProperty(PropertyName = "local")]
        public int Local { get; set; }
    }
}
