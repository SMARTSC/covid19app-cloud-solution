using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class AppUpdateAdviseDataModel
    {
        [JsonProperty(PropertyName = "update-version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "update-date")]
        public System.DateTime ReleasedAt { get; set; }

        [JsonProperty(PropertyName = "update-download-link")]
        public string AccessLink { get; set; }

        [JsonProperty(PropertyName = "update-features")]
        public string[] Features { get; set; }
    }
}
