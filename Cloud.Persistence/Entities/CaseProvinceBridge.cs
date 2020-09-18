namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class CaseProvinceBridge
    {
        public long CaseId { get; set; }

        public Case Case { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; }
    }
}
