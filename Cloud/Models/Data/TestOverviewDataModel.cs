namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class TestOverviewDataModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "all")]
        public int All { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "confirmed")]
        public int Confirmed { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "negative")]
        public int Negative { get; set; }
    }
}
