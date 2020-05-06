using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Models
{
    internal class CaseModel
    {
        [JsonProperty(PropertyName = "id")]
        internal string Id { get; set; }

        [JsonProperty(PropertyName = "arribo_a_cuba_foco")]
        [JsonConverter(typeof(Converters.Serialization.CompatibleDateTimeSerializationConverter), "yyyy/MM/dd")]
        internal System.DateTime ArriveAt { get; set; }

        [JsonProperty(PropertyName = "consulta_medico")]
        [JsonConverter(typeof(Converters.Serialization.CompatibleDateTimeSerializationConverter), "yyyy/MM/dd")]
        internal System.DateTime DetectAt { get; set; }

        [JsonProperty(PropertyName = "dpacode_municipio_deteccion")]
        internal string MunicipalityCode { get; set; }

        [JsonProperty(PropertyName = "municipio_detección")]
        internal string MunicipalityName { get; set; }

        [JsonProperty(PropertyName = "dpacode_provincia_deteccion")]
        internal string ProvinceCode { get; set; }

        [JsonProperty(PropertyName = "provincia_detección")]
        internal string ProvinceName { get; set; }

        [JsonProperty(PropertyName = "contacto_focal")]
        internal int ContactCount { get; set; }

        [JsonProperty(PropertyName = "dpacode_provincias_visitadas")]
        internal string[] ContactProvinceCodes { get; set; }

        [JsonProperty(PropertyName = "provincias_visitadas")]
        internal string[] ContactProvinceNames { get; set; }

        [JsonProperty(PropertyName = "pais")]
        internal string CountryCode { get; set; }

        [JsonProperty(PropertyName = "edad")]
        internal int Age { get; set; }

        [JsonProperty(PropertyName = "sexo")]
        internal string Sex { get; set; }

        [JsonProperty(PropertyName = "contagio")]
        internal string Kind { get; set; }

        [JsonProperty(PropertyName = "centro_diagnostico")]
        internal string DiagnosticCenterId { get; set; }

        [JsonProperty(PropertyName = "centro_aislamiento")]
        internal string IsolationCenterId { get; set; }

        [JsonProperty(PropertyName = "posible_procedencia_contagio")]
        internal string[] PossibleContagionCountryCodes { get; set; }

        [JsonProperty(PropertyName = "info")]
        internal string About { get; set; }
    }
}
