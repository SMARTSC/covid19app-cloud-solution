using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Models
{
    internal class EventModel
    {
        [JsonProperty(PropertyName = "id")]
        internal string Id { get; set; }

        [JsonProperty(PropertyName = "identificador")]
        internal string Label { get; set; }

        [JsonProperty(PropertyName = "dpacode_municipio")]
        internal string MunicipalityCode { get; set; }

        [JsonProperty(PropertyName = "municipio")]
        internal string MunicipalityName { get; set; }

        [JsonProperty(PropertyName = "dpacode_provincia")]
        internal string ProvinceCode { get; set; }

        [JsonProperty(PropertyName = "provincia")]
        internal string ProvinceName { get; set; }

        [JsonProperty(PropertyName = "lon")]
        internal decimal CenterGeoPointLongitude { get; set; }

        [JsonProperty(PropertyName = "lat")]
        internal decimal CenterGeoPointLatitude { get; set; }

        [JsonProperty(PropertyName = "abierto")]
        internal bool Opened { get; set; }

        [JsonProperty(PropertyName = "chequeado")]
        internal bool Checked { get; set; }

        public bool Equals(Api.Common.Models.EventDisplayModel model)
        {
            return Label == model.Label && Opened == model.Opened && CenterGeoPointLatitude == model.CenterGeoPointLatitude && CenterGeoPointLongitude == model.CenterGeoPointLongitude;
        }
    }
}
