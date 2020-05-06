using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class DiagnosticCentersController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<DiagnosticCenter, string, Cloud.Api.Common.Models.DiagnosticCenterInputModel, Cloud.Api.Common.Models.DiagnosticCenterDisplayModel>
    {
        public DiagnosticCentersController(IEntityRepository<DiagnosticCenter, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<DiagnosticCentersController> localizer, ILogger<DiagnosticCentersController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(string key)
        {
            return NotFound();
        }
    }
}
