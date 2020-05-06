using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class IsolationCentersController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<IsolationCenter, string, Cloud.Api.Common.Models.IsolationCenterInputModel, Cloud.Api.Common.Models.IsolationCenterDisplayModel>
    {
        public IsolationCentersController(IEntityRepository<IsolationCenter, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<IsolationCentersController> localizer, ILogger<IsolationCentersController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(string key)
        {
            return NotFound();
        }
    }
}