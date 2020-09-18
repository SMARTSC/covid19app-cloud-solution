using SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Workers
{
    internal class PrimaryDataSourceUpdateAsyncWorker : Facade.IAsyncWorker
    {
        private const string RAW_MODEL_SEX_MALE = "hombre";

        private readonly Microsoft.Extensions.Options.IOptions<Options.DataSourceUpstreamOptions> dataSourceUpstreamOptions;
        private readonly SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;

        public PrimaryDataSourceUpdateAsyncWorker(SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Microsoft.Extensions.Options.IOptions<Options.DataSourceUpstreamOptions> dataSourceUpstreamOptions)
        {
            this.dataSourceUpstreamOptions = dataSourceUpstreamOptions;
            this.httpClientHelperProvider = httpClientHelperProvider;
        }

        public async System.Threading.Tasks.Task DoWorkAsync(System.Threading.CancellationToken cancellationToken)
        {
            Models.Covid19CubaDataModel model = null;

            using (var httpClient = new System.Net.Http.HttpClient { Timeout = System.TimeSpan.FromSeconds(10) })
            {
                var json = await httpClient.GetStringAsync(dataSourceUpstreamOptions.Value.Uri);

                model = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Covid19CubaDataModel>(json, new Newtonsoft.Json.JsonSerializerSettings
                {
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                });
            }

            var lastReportId = 0;

            var reportsApiClient = new Api.Connect.Clients.ReportsApiClient(httpClientHelperProvider);

            var currentReports = await reportsApiClient.GetAsync();

            var unsyncronizedReports = new System.Collections.Generic.List<Models.Report>();

            var localReportDictionaries = model.ReportDictionary.Values.ElementAt(0);

            if (currentReports.Length == 0)
            {
                unsyncronizedReports.AddRange(localReportDictionaries.Select(item =>
                {
                    lastReportId = int.Parse(item.Key);

                    var report = item.Value;

                    report.Id = lastReportId;

                    return report;
                }));
            }
            else
            {
                foreach (var item in localReportDictionaries)
                {
                    var rawReportId = int.Parse(item.Key);

                    if (!currentReports.Any(current => current.Id == rawReportId))
                    {
                        lastReportId = rawReportId;

                        var report = item.Value;

                        report.Id = lastReportId;

                        unsyncronizedReports.Add(report);
                    }
                }
            }

            if (unsyncronizedReports.Count <= 0)
            {
                throw new Exceptions.NotUpdatedDataSourceException();
            }

            await model.SyncronizeCountriesAsync(unsyncronizedReports, httpClientHelperProvider);

            await model.SyncronizeProvincesAsync(unsyncronizedReports, httpClientHelperProvider);

            await model.SyncronizeMunicipalitiesAsync(unsyncronizedReports, httpClientHelperProvider);

            var isolationCenters = await model.SyncronizeIsolationCentersAsync(lastReportId, httpClientHelperProvider);

            var diagnosticCenters = await model.SyncronizeDiagnosticCentersAsync(lastReportId, httpClientHelperProvider);

            await model.SyncronizeEventsAsync(lastReportId, httpClientHelperProvider);

            foreach (var report in unsyncronizedReports)
            {
                var input = new Api.Common.Models.ReportInputModel
                {
                    Id = report.Id,
                    At = report.At,
                    RiskyContactCount = report.RiskyContactCount,
                    TestCount = report.TestCount,
                    CriticCaseCount = 0, // TODO Fix line default value assignation,
                    DeadCaseCount = report.DeadCaseCount,
                    EvacuateCaseCount = report.EvacuateCaseCount,
                    GraveCaseCount = report.GraveCaseCount,
                    RecoveredCaseCount = report.RecoveredCaseCount,
                    Notes = report.Notes
                };

                if (report.Cases != null)
                {
                    input.Cases = report.Cases.Select(raw => new Api.Common.Models.CaseInputModel
                    {
                        CountryId = raw.CountryCode,
                        Age = raw.Age,
                        Sex = raw.Sex == RAW_MODEL_SEX_MALE ? Persistence.Enumerations.Sex.Male : Persistence.Enumerations.Sex.Female,
                        Kind = GetCaseKind(raw),
                        ArriveAt = raw.ArriveAt,
                        DetectAt = raw.DetectAt,
                        ContactCount = raw.ContactCount,
                        DetectionMunicipalityId = raw.MunicipalityCode,
                        DiagnosticCenterId = diagnosticCenters.Any(m => m.Id == raw.DiagnosticCenterId) ? raw.DiagnosticCenterId : null,
                        IsolationCenterId = isolationCenters.Any(m => m.Id == raw.IsolationCenterId) ? raw.IsolationCenterId : null,
                        ContactProvinces = GetCaseContactProvinces(raw),
                        PossibleContagionCountries = GetCasePossibleContagionCountries(raw),
                        About = raw.About
                    }).ToList();
                }

                await reportsApiClient.CreateAsync(input);
            }
        }

        private Persistence.Enumerations.CaseKind GetCaseKind(Models.CaseModel @case)
        {
            switch (@case.Kind)
            {
                case "importado":
                    return Persistence.Enumerations.CaseKind.Imported;

                case "introducido":
                    return Persistence.Enumerations.CaseKind.Inserted;

                default:
                    return Persistence.Enumerations.CaseKind.Local;
            }
        }

        private Api.Common.Models.ProvinceDisplayModel[] GetCaseContactProvinces(Models.CaseModel @case)
        {
            if (@case.ContactProvinceCodes == null) return null;

            var result = new System.Collections.Generic.List<Api.Common.Models.ProvinceDisplayModel>();

            foreach (var key in @case.ContactProvinceCodes)
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)) continue;

                result.Add(new Api.Common.Models.ProvinceDisplayModel
                {
                    Id = key.ToProvinceId()
                });
            }  

            return result.ToArray();
        }

        private Api.Common.Models.CountryDisplayModel[] GetCasePossibleContagionCountries(Models.CaseModel @case)
        {
            if (@case.PossibleContagionCountryCodes == null) return null;

            var result = new System.Collections.Generic.List<Api.Common.Models.CountryDisplayModel>();

            foreach (var key in @case.PossibleContagionCountryCodes)
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)) continue;

                result.Add(new Api.Common.Models.CountryDisplayModel
                {
                    Id = key
                });
            }

            return result.ToArray();
        }
    }
}
