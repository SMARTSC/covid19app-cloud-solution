using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class AgeRankOverviewDataModel
    {
        [JsonProperty(PropertyName = "age-0-19")]
        public int Children { get; set; }

        [JsonProperty(PropertyName = "age-20-39")]
        public int Joung { get; set; }

        [JsonProperty(PropertyName = "age-40-59")]
        public int Adult { get; set; }

        [JsonProperty(PropertyName = "age-60-79")]
        public int MayorAdult { get; set; }

        [JsonProperty(PropertyName = "age-80+")]
        public int Ancient { get; set; }

        [JsonProperty(PropertyName = "unknown")]
        public int Unknown { get; set; }
    }
}
