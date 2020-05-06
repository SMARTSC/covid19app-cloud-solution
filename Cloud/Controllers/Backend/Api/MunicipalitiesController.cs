using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class MunicipalitiesController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Municipality, int, Cloud.Api.Common.Models.MunicipalityInputModel, Cloud.Api.Common.Models.MunicipalityDisplayModel>
    {
        public MunicipalitiesController(IEntityRepository<Municipality, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<MunicipalitiesController> localizer, ILogger<MunicipalitiesController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}
