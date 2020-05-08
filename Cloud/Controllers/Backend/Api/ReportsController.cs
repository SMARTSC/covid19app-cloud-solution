using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class ReportsController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Report, int, ReportInputModel, ReportDisplayModel>
    {
        public ReportsController(IEntityRepository<Report, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<ReportsController> localizer, ILogger<ReportsController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}
