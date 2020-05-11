using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class SummaryDataModel
    {
        [JsonProperty(PropertyName = "confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty(PropertyName = "active")]
        public int Active { get; set; }

        [JsonProperty(PropertyName = "observation")]
        public int Observation { get; set; }

        [JsonProperty(PropertyName = "recoveries")]
        public int Recoveries { get; set; }

        [JsonProperty(PropertyName = "died")]
        public int Died { get; set; }

        [JsonProperty(PropertyName = "evacuated")]
        public int Evacuated { get; set; }

        [JsonProperty(PropertyName = "test")]
        public int Test { get; set; }
    }
}
