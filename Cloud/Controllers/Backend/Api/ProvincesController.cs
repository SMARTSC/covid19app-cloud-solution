using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class ProvincesController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Province, int, Cloud.Api.Common.Models.ProvinceInputModel, Cloud.Api.Common.Models.ProvinceDisplayModel>
    {
        public ProvincesController(IEntityRepository<Province, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProvincesController> localizer, ILogger<ProvincesController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(int key)
        {
            return NotFound();
        }
    }
}
