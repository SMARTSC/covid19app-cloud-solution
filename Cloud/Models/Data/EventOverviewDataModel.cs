using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class EventOverviewDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "code_municipality")]
        public string MunicipalityCode { get; set; }

        [JsonProperty(PropertyName = "name_municipality")]
        public string MunicipalityName { get; set; }

        [JsonProperty(PropertyName = "code_province")]
        public int ProvinceCode { get; set; }

        [JsonProperty(PropertyName = "name_province")]
        public string ProvinceName { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public decimal CenterGeoPointLongitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public decimal CenterGeoPointLatitude { get; set; }

        [JsonProperty(PropertyName = "open")]
        public bool Open { get; set; }
    }
}
