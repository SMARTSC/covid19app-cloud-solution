using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class NationalityOverviewDataModel
    {
        [JsonProperty(PropertyName = "cuba")]
        public int National { get; set; }

        [JsonProperty(PropertyName = "world")]
        public int International { get; set; }

        [JsonProperty(PropertyName = "unknown")]
        public int Unknown { get; set; }
    }
}
