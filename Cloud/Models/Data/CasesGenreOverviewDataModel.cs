using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class CasesGenreOverviewDataModel
    {
        [JsonProperty(PropertyName = "male")]
        public int Male { get; set; }

        [JsonProperty(PropertyName = "famale")]
        public int Famale { get; set; }
    }
}
