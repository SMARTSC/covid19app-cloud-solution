namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class DailyRecoveryOverviewDataModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "day")]
        public int Report { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveries")]
        public int RecoveryCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "all")]
        public int All { get; set; }
    }
}
