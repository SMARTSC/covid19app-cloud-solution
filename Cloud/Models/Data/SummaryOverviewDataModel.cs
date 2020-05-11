namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class SummaryOverviewDataModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "last-board")]
        public SummaryDataModel Journaly { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "total-board")]
        public SummaryDataModel Accumulate { get; set; }
    }
}
