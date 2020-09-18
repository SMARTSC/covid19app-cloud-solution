using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;
using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Frontend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("frontend")]
    public class UpdateController : SAPRESSC.Core.Web.Common.Controllers.BaseWebController
    {
        private readonly IEntityRepository<Report, int> reportRepository;
        private readonly IEntityRepository<Province, int> provinceRepository;
        private readonly IEntityRepository<Municipality, string> municipalityRepository;
        private readonly IEntityRepository<Event, string> eventReporsitory;
        private readonly IEntityRepository<IsolationCenter, string> isolationCenterRepository;
        private readonly IEntityRepository<DiagnosticCenter, string> diagnosticCenterRepository;
        private readonly IEntityRepository<AppUpdateAdvise, int> appUpdateAdviseRepository;
        private readonly IEntityRepository<VendorAdvise, int> vendorAdviseRepository;

        public UpdateController(IEntityRepository<VendorAdvise, int> vendorAdviseRepository, IEntityRepository<AppUpdateAdvise, int> appUpdateAdviseRepository, IEntityRepository<DiagnosticCenter, string> diagnosticCenterRepository, IEntityRepository<IsolationCenter, string> isolationCenterRepository, IEntityRepository<Event, string> eventReporsitory, IEntityRepository<Municipality, string> municipalityRepository, IEntityRepository<Province, int> provinceRepository, IEntityRepository<Report, int> reportRepository, Microsoft.Extensions.Localization.IStringLocalizer<UpdateController> localizer, ILogger<UpdateController> logger) : base(localizer, logger)
        {
            this.reportRepository = reportRepository;
            this.provinceRepository = provinceRepository;
            this.municipalityRepository = municipalityRepository;
            this.eventReporsitory = eventReporsitory;
            this.isolationCenterRepository = isolationCenterRepository;
            this.diagnosticCenterRepository = diagnosticCenterRepository;
            this.appUpdateAdviseRepository = appUpdateAdviseRepository;
            this.vendorAdviseRepository = vendorAdviseRepository;
        }

        [HttpGet]
        [HttpGet("[action]/{key}")]
        public IActionResult After(int key)
        {
            var allReports = reportRepository.GetAll().ToArray();

            var requiredReports = allReports;

            if (key > 0)
            {
                requiredReports = allReports.Where(entity => entity.Id > key).ToArray();
            }

            if (requiredReports.Length <= 0)
            {
                return NoContent();
            }

            var previewsLastReport = allReports[allReports.Length - 2];
            var lastReport = allReports.Last();

            var todayAccumulate = new Models.Data.SummaryDataModel();
            var ageRankOverview = new Models.Data.AgeRankOverviewDataModel();
            var nationalityOverview = new Models.Data.NationalityOverviewDataModel();
            var casesKindOverview = new Models.Data.CasesKindOverviewDataModel();
            var casesGenreOverview = new Models.Data.CasesGenreOverviewDataModel();
            var casesProvinceOverviews = provinceRepository.GetAll().Select(entity => new Models.Data.CasesProvinceOverviewDataModel
            {
                ProvinceId = entity.Id,
                ProvinceName = entity.Name
            }).ToArray();
            var casesMunicipalityOverviews = municipalityRepository.GetAll().Select(entity => new Models.Data.CasesMunicipalityOverviewDataModel
            {
                MunicipalityId = entity.Id,
                MunicipalityName = entity.Name
            }).ToArray();

            var dailyDeadCountReference = 0;
            var dailyRecoveryCountReference = 0;
            var caseCount = 0;

            var caseFreeDayCount = 0;
            var deadFreeDayCount = 0;

            foreach (var report in allReports)
            {
                todayAccumulate.Confirmed += report.Cases.Count;
                todayAccumulate.Evacuated += report.EvacuateCaseCount;
                todayAccumulate.Recoveries += report.RecoveredCaseCount;
                todayAccumulate.Died += report.DeadCaseCount;

                if (report.Cases.Count > 0)
                {
                    caseFreeDayCount = 0;
                }
                else
                {
                    caseFreeDayCount++;
                }

                if (report.DeadCaseCount > 0)
                {
                    deadFreeDayCount = 0;
                }
                else 
                {
                    deadFreeDayCount++;
                }

                if (report.Id <= key)
                {
                    dailyDeadCountReference += report.DeadCaseCount;
                    dailyRecoveryCountReference += report.RecoveredCaseCount;
                }

                foreach (var @case in report.Cases)
                {
                    caseCount++;

                    var casesMunicipalityOverview = casesMunicipalityOverviews.FirstOrDefault(m => m.MunicipalityId == @case.DetectionMunicipalityId);

                    if (casesMunicipalityOverview != null)
                    {
                        casesMunicipalityOverview.Cases += 1;
                    }

                    var casesProvinceOverview = casesProvinceOverviews.FirstOrDefault(m => m.ProvinceId == @case.DetectionMunicipality.ProvinceId);

                    if (casesProvinceOverview != null)
                    {
                        casesProvinceOverview.Cases += 1;
                    }

                    if (@case.Age <= 0)
                    {
                        ageRankOverview.Unknown += 1;
                    }
                    else if (@case.Age < 20)
                    {
                        ageRankOverview.Children += 1;
                    }
                    else if (@case.Age < 40)
                    {
                        ageRankOverview.Joung += 1;
                    }
                    else if (@case.Age < 60)
                    {
                        ageRankOverview.Adult += 1;
                    }
                    else if (@case.Age < 80)
                    {
                        ageRankOverview.MayorAdult += 1;
                    }
                    else
                    {
                        ageRankOverview.Ancient += 1;
                    }

                    if (string.IsNullOrEmpty(@case.CountryId))
                    {
                        nationalityOverview.Unknown += 1;
                    }
                    else if (@case.CountryId == "cu")
                    {
                        nationalityOverview.National += 1;
                    }
                    else
                    {
                        nationalityOverview.International += 1;
                    }

                    switch (@case.Kind)
                    {
                        case Persistence.Enumerations.CaseKind.Local:
                            casesKindOverview.Local += 1;

                            break;

                        case Persistence.Enumerations.CaseKind.Imported:
                            casesKindOverview.Imported += 1;

                            break;

                        case Persistence.Enumerations.CaseKind.Inserted:
                            casesKindOverview.Introduced += 1;

                            break;
                    }

                    if (@case.Sex == Persistence.Enumerations.Sex.Male)
                    {
                        casesGenreOverview.Male += 1;
                    }
                    else
                    {
                        casesGenreOverview.Famale += 1;
                    }
                }
            }

            todayAccumulate.Test = lastReport.TestCount;
            todayAccumulate.Observation = lastReport.RiskyContactCount;

            todayAccumulate.Active = todayAccumulate.Confirmed - todayAccumulate.Recoveries - todayAccumulate.Evacuated - todayAccumulate.Died;

            var previeusAccumulate = new Models.Data.SummaryDataModel
            {
                Confirmed = todayAccumulate.Confirmed - lastReport.Cases.Count,
                Evacuated = todayAccumulate.Evacuated - lastReport.EvacuateCaseCount,
                Recoveries = todayAccumulate.Recoveries - lastReport.RecoveredCaseCount,
                Died = todayAccumulate.Died - lastReport.DeadCaseCount,
                Observation = previewsLastReport.RiskyContactCount,
                Test = previewsLastReport.TestCount
            };

            previeusAccumulate.Active = previeusAccumulate.Confirmed - previeusAccumulate.Recoveries - previeusAccumulate.Evacuated - previeusAccumulate.Died;

            Report lastClientReport = null;

            if (key > 0)
            {
                try
                {
                    lastClientReport = reportRepository.Get(key);
                }
                catch
                {
                    return BadRequest();
                }
            }

            foreach (var item in casesProvinceOverviews)
            {
                item.Percent = (float)(System.Convert.ToDouble(item.Cases) / caseCount * 100);
            }

            foreach (var item in casesMunicipalityOverviews)
            {
                item.Percent = (float)(System.Convert.ToDouble(item.Cases) / caseCount * 100);
            }

            var model = new Models.Data.UpdateDataModel
            {
                Id = lastReport.Id,
                Date = lastReport.At.ToShortDateString(),
                VendorAdvises = vendorAdviseRepository.FindBy(entity => entity.PushDay > key).Select(entity => new Models.Data.VendorAdviseDataModel
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    Link = entity.AccessLink,
                    ThumbnailImageLink = entity.ThumbnailImageLink,
                    Features = entity.Features.Select(wEntity => wEntity.Description).ToArray()
                }).ToArray(),
                CaseFreeDayCount = caseFreeDayCount,
                DeadFreeDayCount = deadFreeDayCount,
                SummaryOverview = new Models.Data.SummaryOverviewDataModel
                {
                    Journaly = new Models.Data.SummaryDataModel
                    {
                        Confirmed = lastReport.Cases.Count,
                        Evacuated = lastReport.EvacuateCaseCount,
                        Recoveries = lastReport.RecoveredCaseCount,
                        Died = lastReport.DeadCaseCount,
                        Active = todayAccumulate.Active - previeusAccumulate.Active,
                        Observation = todayAccumulate.Observation - previeusAccumulate.Observation,
                        Test = todayAccumulate.Test - previeusAccumulate.Test
                    },
                    Accumulate = todayAccumulate
                },
                TestOverview = new Models.Data.TestOverviewDataModel
                {
                    All = todayAccumulate.Test,
                    Confirmed = todayAccumulate.Confirmed
                },
                AgeRankOverview = ageRankOverview,
                NationalityOverview = nationalityOverview,
                CasesKindOverview = casesKindOverview,
                CasesGenreOverview = casesGenreOverview,
                CasesProvinceOverviews = casesProvinceOverviews,
                CasesMunicipalityOverviews = casesMunicipalityOverviews,
                IsolationCenterOverviews = isolationCenterRepository.FindBy(entity => entity.PushDay > key).Select(entity => new Models.Data.HealtCenterOverviewDataModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ProvinceCode = entity.ProvinceId,
                    ProvinceName = entity.Province.Name,
                    CenterGeoPointLatitude = entity.GeoPointLatitude,
                    CenterGeoPointLongitude = entity.GeoPointLongitude
                }).ToArray(),
                DiagnosticCenterOverviews = diagnosticCenterRepository.FindBy(entity => entity.PushDay > key).Select(entity => new Models.Data.HealtCenterOverviewDataModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ProvinceCode = entity.ProvinceId,
                    ProvinceName = entity.Province.Name,
                    CenterGeoPointLatitude = entity.GeoPointLatitude,
                    CenterGeoPointLongitude = entity.GeoPointLongitude
                }).ToArray()
            };

            var pendingAppUpdateAdvises = appUpdateAdviseRepository.FindBy(entity => entity.PushDay > key).ToArray();

            if (pendingAppUpdateAdvises.Length > 0)
            {
                var relevantAppUpdateAdvise = pendingAppUpdateAdvises.Last();

                model.UpdateAdvise = new Models.Data.AppUpdateAdviseDataModel
                {
                    Version = relevantAppUpdateAdvise.Version,
                    ReleasedAt = relevantAppUpdateAdvise.ReleasedAt,
                    AccessLink = relevantAppUpdateAdvise.AccessLink,
                    Features = relevantAppUpdateAdvise.Features.Select(entity => entity.Description).ToArray()
                };
            }
            
            var events = eventReporsitory.FindBy(entity => entity.PushDay > key).ToArray();

            foreach (var entity in events)
            {
                model.EventOverviews.Add(new Models.Data.EventOverviewDataModel
                {
                    Id = entity.Id,
                    Name = entity.Label,
                    ProvinceCode = entity.Municipality.ProvinceId,
                    ProvinceName = entity.Municipality.Province.Name,
                    MunicipalityCode = entity.MunicipalityId,
                    MunicipalityName = entity.Municipality.Name,
                    CenterGeoPointLatitude = entity.CenterGeoPointLatitude,
                    CenterGeoPointLongitude = entity.CenterGeoPointLongitude,
                    Open = entity.Opened
                });
            }

            var dailyTestCountReference = lastClientReport?.TestCount ?? 0;
            var dailyCaseCountReference = lastClientReport?.Cases.Count ?? 0;

            var responsiveAccumulateTestCounter = 0;
            var responsiveProgressTestCounter = 0;

            foreach (var entity in requiredReports)
            {
                dailyCaseCountReference += entity.Cases.Count;

                var responsiveAccumulateTestCount = entity.TestCount <= entity.Cases.Count ? responsiveAccumulateTestCounter += entity.Cases.Count : entity.TestCount;
                    
                var responsiveProgressTestCount = entity.TestCount <= entity.Cases.Count ? responsiveProgressTestCounter += entity.Cases.Count : entity.TestCount;

                model.DailyTestAccumulateOverviews.Add(new Models.Data.DailyTestOverviewDataModel
                {
                    Report = entity.Id,
                    Date = entity.At.ToShortDateString(),
                    All = responsiveAccumulateTestCount,
                    Confirmed = dailyCaseCountReference,
                    Negative = responsiveAccumulateTestCount - dailyCaseCountReference
                });

                model.DailyTestProgressOverviews.Add(new Models.Data.DailyTestOverviewDataModel
                {
                    Report = entity.Id,
                    Date = entity.At.ToShortDateString(),
                    All = responsiveProgressTestCount - dailyTestCountReference,
                    Confirmed = entity.Cases.Count,
                    Negative = responsiveProgressTestCount - dailyTestCountReference - entity.Cases.Count
                });

                dailyTestCountReference = responsiveProgressTestCount;

                dailyDeadCountReference += entity.DeadCaseCount;

                model.DailyDiedOverviews.Add(new Models.Data.DailyDiedOverviewDataModel
                {
                    Report = entity.Id,
                    Date = entity.At.ToShortDateString(),
                    DiedCount = entity.DeadCaseCount,
                    All = dailyDeadCountReference
                });

                dailyRecoveryCountReference += entity.RecoveredCaseCount;

                model.DailyRecoveryOverviews.Add(new Models.Data.DailyRecoveryOverviewDataModel
                {
                    Report = entity.Id,
                    Date = entity.At.ToShortDateString(),
                    RecoveryCount = entity.RecoveredCaseCount,
                    All = dailyRecoveryCountReference
                });
            }

            model.TestOverview.Negative = model.TestOverview.All - model.TestOverview.Confirmed;

            return Ok(model);
        }
    }
}
