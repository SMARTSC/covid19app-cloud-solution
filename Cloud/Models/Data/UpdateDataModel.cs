using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class UpdateDataModel
    {
        [JsonProperty(PropertyName = "update-id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "update-date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "main-board")]
        public SummaryOverviewDataModel SummaryOverview { get; set; }

        [JsonProperty(PropertyName = "done-test")]
        public TestOverviewDataModel TestOverview { get; set; }

        [JsonProperty(PropertyName = "daily-done-test")]
        public DailyTestOverviewDataModel[] DailyTestAccumulateOverview { get; set; }

        [JsonProperty(PropertyName = "daily-cases-progress")]
        public DailyTestOverviewDataModel[] DailyTestProgressOverview { get; set; }
    }
}
