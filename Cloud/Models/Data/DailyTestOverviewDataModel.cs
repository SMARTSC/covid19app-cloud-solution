namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class DailyTestOverviewDataModel : TestOverviewDataModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "day")]
        public int Report { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
    }
}
