using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Models
{
    internal class Covid19CubaDataModel
    {
        [JsonProperty(PropertyName = "schema-version")]
        internal int Version { get; set; }

        [JsonProperty(PropertyName = "eventos")]
        internal System.Collections.Generic.Dictionary<string, EventModel> Events { get; set; }

        [JsonProperty(PropertyName = "centros_aislamiento")]
        internal System.Collections.Generic.Dictionary<string, HealtCenterModel> IsolationCenters { get; set; }

        [JsonProperty(PropertyName = "centros_diagnostico")]
        internal System.Collections.Generic.Dictionary<string, HealtCenterModel> DiagnosticCenters { get; set; }

        [JsonProperty(PropertyName = "casos")]
        internal System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, Report>> ReportDictionary { get; set; }
    }
}
