using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class CountriesController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Country, string, Cloud.Api.Common.Models.CountryInputModel, Cloud.Api.Common.Models.CountryDisplayModel>
    {
        public CountriesController(IEntityRepository<Country, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<CountriesController> localizer, ILogger<CountriesController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(string key)
        {
            return NotFound();
        }
    }
}
