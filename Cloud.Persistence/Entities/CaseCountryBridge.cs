namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class CaseCountryBridge
    {
        public long CaseId { get; set; }

        public Case Case { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}
