using System.Collections.Generic;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Report : SAPRESSC.Core.Persistence.Entities.IEntity<int>
    {
        public Report()
        {
            Cases = new List<Case>();
            DeadCaseBridges = new List<ReportDeadCaseBridge>();
            EvacuateCaseBridges = new List<ReportEvacuateCaseBridge>();
            GraveCaseBridges = new List<ReportGraveCaseBridge>();
            CriticCaseBridges = new List<ReportCriticCaseBridge>();
            RecoveredCaseBridges = new List<ReportRecoveredCaseBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public System.DateTime At { get; set; }

        public int RiskyContactCount { get; set; }

        public int TestCount { get; set; }

        public List<Case> Cases { get; set; }

        public int DeadCaseCount { get; set; }

        public List<ReportDeadCaseBridge> DeadCaseBridges { get; set; }

        public int EvacuateCaseCount { get; set; }

        public List<ReportEvacuateCaseBridge> EvacuateCaseBridges { get; set; }

        public int GraveCaseCount { get; set; }

        public List<ReportGraveCaseBridge> GraveCaseBridges { get; set; }

        public int CriticCaseCount { get; set; }

        public List<ReportCriticCaseBridge> CriticCaseBridges { get; set; }

        public int RecoveredCaseCount { get; set; }

        public List<ReportRecoveredCaseBridge> RecoveredCaseBridges { get; set; }

        public string Notes { get; set; }
    }
}
