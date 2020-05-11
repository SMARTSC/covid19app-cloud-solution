namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class RequestUpdateDataModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "last-board")]
        public int CurrentReport { get; set; }
    }
}
