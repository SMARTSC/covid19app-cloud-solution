namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class ReportGraveCaseBridge
    {
        public long CaseId { get; set; }

        public Case Case { get; set; }

        public int ReportId { get; set; }

        public Report Report { get; set; }
    }
}
