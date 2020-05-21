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

        public UpdateController(IEntityRepository<Report, int> reportRepository, Microsoft.Extensions.Localization.IStringLocalizer<UpdateController> localizer, ILogger<UpdateController> logger) : base(localizer, logger)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet]
        [HttpGet("[action]/{key}")]
        public IActionResult After(int key = 0)
        {
            var allReports = reportRepository.GetAll().ToArray();

            Report[] requiredReports = allReports;

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

            foreach (var report in allReports)
            {
                todayAccumulate.Confirmed += report.Cases.Count;
                todayAccumulate.Evacuated += report.EvacuateCaseCount;
                todayAccumulate.Recoveries += report.RecoveredCaseCount;
                todayAccumulate.Died += report.DeadCaseCount;
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

            var dailyTestCountReference = lastClientReport?.TestCount ?? 0;
            var dailyCaseCountReference = lastClientReport?.Cases.Count ?? 0;

            var responsiveAccumulateTestCounter = 0;
            var responsiveProgressTestCounter = 0;

            var model = new Models.Data.UpdateDataModel
            {
                Id = lastReport.Id,
                Date = lastReport.At.ToShortDateString(),
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
                DailyTestAccumulateOverview = requiredReports.Select(entity =>
                {
                    dailyCaseCountReference += entity.Cases.Count;

                    var responsiveTestCount = entity.TestCount <= entity.Cases.Count ? responsiveAccumulateTestCounter+= entity.Cases.Count : entity.TestCount;

                    var result = new Models.Data.DailyTestOverviewDataModel
                    {
                        Report = entity.Id,
                        Date = entity.At.ToShortDateString(),
                        All = responsiveTestCount,
                        Confirmed = dailyCaseCountReference,
                        Negative = responsiveTestCount - dailyCaseCountReference
                    };

                    return result;
                }).ToArray(),
                DailyTestProgressOverview = requiredReports.Select(entity =>
                {
                    var responsiveTestCount = entity.TestCount <= entity.Cases.Count ? responsiveProgressTestCounter += entity.Cases.Count : entity.TestCount;

                    var result = new Models.Data.DailyTestOverviewDataModel
                    {
                        Report = entity.Id,
                        Date = entity.At.ToShortDateString(),
                        All = responsiveTestCount - dailyTestCountReference,
                        Confirmed = entity.Cases.Count,
                        Negative = responsiveTestCount - dailyTestCountReference - entity.Cases.Count
                    };

                    dailyTestCountReference = responsiveTestCount;

                    return result;
                }).ToArray()
            };

            model.TestOverview.Negative = model.TestOverview.All - model.TestOverview.Confirmed;

            return Ok(model);
        }
    }
}
