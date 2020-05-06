using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Models
{
    internal class Report
    {
        [JsonIgnore]
        internal int Id { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        [JsonConverter(typeof(Converters.Serialization.CompatibleDateTimeSerializationConverter), "yyyy/MM/dd")]
        internal System.DateTime At { get; set; }

        [JsonProperty(PropertyName = "sujetos_riesgo")]
        internal int RiskyContactCount { get; set; }

        [JsonProperty(PropertyName = "tests_total")]
        internal int TestCount { get; set; }

        [JsonProperty(PropertyName = "diagnosticados")]
        internal CaseModel[] Cases { get; set; }

        [JsonProperty(PropertyName = "muertes_numero")]
        internal int DeadCaseCount { get; set; }

        [JsonProperty(PropertyName = "muertes_id")]
        internal string[] DeadCases { get; set; }

        [JsonProperty(PropertyName = "evacuados_numero")]
        internal int EvacuateCaseCount { get; set; }

        [JsonProperty(PropertyName = "evacuados_id")]
        internal string[] EvacuateCases { get; set; }

        [JsonProperty(PropertyName = "graves_numero")]
        internal int GraveCaseCount { get; set; }

        [JsonProperty(PropertyName = "graves_id")]
        internal string[] GraveCases { get; set; }

        //[JsonProperty(PropertyName = "graves_numero")]
        //internal int CriticCaseCount { get; set; }

        //[JsonProperty(PropertyName = "criticos")]
        //internal string[] CriticCases { get; set; }

        [JsonProperty(PropertyName = "recuperados_numero")]
        internal int RecoveredCaseCount { get; set; }

        [JsonProperty(PropertyName = "recuperados_id")]
        internal string[] RecoveredCases { get; set; }

        [JsonProperty(PropertyName = "nota_general")]
        internal string Notes { get; set; }
    }
}
