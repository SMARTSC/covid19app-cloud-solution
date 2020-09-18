using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Case : SAPRESSC.Core.Persistence.Entities.IEntity<long>
    {
        public Case()
        {
            ContactProvinceBridges = new System.Collections.Generic.List<CaseProvinceBridge>();
            PossibleContagionCountryBridges = new System.Collections.Generic.List<CaseCountryBridge>();
        }

        [Key]
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Report")]
        public int ReportId { get; set; }

        public Report Report { get; set; }

        public System.DateTime ArriveAt { get; set; }

        public System.DateTime DetectAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("DetectionMunicipality")]
        public string DetectionMunicipalityId { get; set; }

        public Municipality DetectionMunicipality { get; set; }

        public int ContactCount { get; set; }

        public System.Collections.Generic.List<CaseProvinceBridge> ContactProvinceBridges { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Country")]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public int Age { get; set; }

        public Enumerations.Sex Sex { get; set; }

        public Enumerations.CaseKind Kind { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("DiagnosticCenter")]
        public string DiagnosticCenterId { get; set; }

        public DiagnosticCenter DiagnosticCenter { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IsolationCenter")]
        public string IsolationCenterId { get; set; }

        public IsolationCenter IsolationCenter { get; set; }

        public System.Collections.Generic.List<CaseCountryBridge> PossibleContagionCountryBridges { get; set; }

        public string About { get; set; }
    }
}
