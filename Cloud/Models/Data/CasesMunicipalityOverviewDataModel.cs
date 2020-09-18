using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class CasesMunicipalityOverviewDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string MunicipalityId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string MunicipalityName { get; set; }

        [JsonProperty(PropertyName = "cases")]
        public int Cases { get; set; }

        [JsonProperty(PropertyName = "percent")]
        public float Percent { get; set; }
    }
}
