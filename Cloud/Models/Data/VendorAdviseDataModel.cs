using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class VendorAdviseDataModel
    {
        [JsonProperty(PropertyName = "ads-title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "ads-description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "ads-link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "ads-image-link")]
        public string ThumbnailImageLink { get; set; }

        [JsonProperty(PropertyName = "ads-features")]
        public string[] Features { get; set; }
    }
}
