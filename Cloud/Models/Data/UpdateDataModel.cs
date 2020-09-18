using Newtonsoft.Json;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.Data
{
    public class UpdateDataModel
    {
        public UpdateDataModel()
        {
            DailyTestAccumulateOverviews = new System.Collections.Generic.List<DailyTestOverviewDataModel>();
            DailyTestProgressOverviews = new System.Collections.Generic.List<DailyTestOverviewDataModel>();
            DailyDiedOverviews = new System.Collections.Generic.List<DailyDiedOverviewDataModel>();
            DailyRecoveryOverviews = new System.Collections.Generic.List<DailyRecoveryOverviewDataModel>();
            EventOverviews = new System.Collections.Generic.List<EventOverviewDataModel>();
        }

        [JsonProperty(PropertyName = "update-id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "update-date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "app-update")]
        public AppUpdateAdviseDataModel UpdateAdvise { get; set; }

        [JsonProperty(PropertyName = "ads-update")]
        public VendorAdviseDataModel[] VendorAdvises { get; set; }
        
        [JsonProperty(PropertyName = "days-after-last-confirmed")]
        public int CaseFreeDayCount { get; set; }

        [JsonProperty(PropertyName = "days-after-last-died")]
        public int DeadFreeDayCount { get; set; }

        [JsonProperty(PropertyName = "main-board")]
        public SummaryOverviewDataModel SummaryOverview { get; set; }

        [JsonProperty(PropertyName = "done-test")]
        public TestOverviewDataModel TestOverview { get; set; }

        [JsonProperty(PropertyName = "age-rank-cases")]
        public AgeRankOverviewDataModel AgeRankOverview { get; set; }

        [JsonProperty(PropertyName = "cases-by-nationality")]
        public NationalityOverviewDataModel NationalityOverview { get; set; }

        [JsonProperty(PropertyName = "cases-by-contagion-mode")]
        public CasesKindOverviewDataModel CasesKindOverview { get; set; }

        [JsonProperty(PropertyName = "cases-by-gender")]
        public CasesGenreOverviewDataModel CasesGenreOverview { get; set; }

        [JsonProperty(PropertyName = "cases-by-province")]
        public CasesProvinceOverviewDataModel[] CasesProvinceOverviews { get; set; }

        [JsonProperty(PropertyName = "cases-by-municipality")]
        public CasesMunicipalityOverviewDataModel[] CasesMunicipalityOverviews { get; set; }

        [JsonProperty(PropertyName = "daily-done-test")]
        public System.Collections.Generic.List<DailyTestOverviewDataModel> DailyTestAccumulateOverviews { get; set; }

        [JsonProperty(PropertyName = "daily-cases-progress")]
        public System.Collections.Generic.List<DailyTestOverviewDataModel> DailyTestProgressOverviews { get; set; }

        [JsonProperty(PropertyName = "daily-died")]
        public System.Collections.Generic.List<DailyDiedOverviewDataModel> DailyDiedOverviews { get; set; }

        [JsonProperty(PropertyName = "daily-recoveries")]
        public System.Collections.Generic.List<DailyRecoveryOverviewDataModel> DailyRecoveryOverviews { get; set; }

        [JsonProperty(PropertyName = "risk-events")]
        public System.Collections.Generic.List<EventOverviewDataModel> EventOverviews { get; set; }

        [JsonProperty(PropertyName = "isolation-centers")]
        public HealtCenterOverviewDataModel[] IsolationCenterOverviews { get; set; }

        [JsonProperty(PropertyName = "diagnostic-centers")]
        public HealtCenterOverviewDataModel[] DiagnosticCenterOverviews { get; set; }
    }
}
