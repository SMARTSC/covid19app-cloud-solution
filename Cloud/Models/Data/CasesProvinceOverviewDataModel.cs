using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class CasesProvinceOverviewDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public int ProvinceId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string ProvinceName { get; set; }

        [JsonProperty(PropertyName = "cases")]
        public int Cases { get; set; }

        [JsonProperty(PropertyName = "percent")]
        public float Percent { get; set; }
    }
}
