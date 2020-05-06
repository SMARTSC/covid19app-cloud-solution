using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class EventsController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Event, string, Cloud.Api.Common.Models.EventInputModel, Cloud.Api.Common.Models.EventDisplayModel>
    {
        public EventsController(IEntityRepository<Event, string> repository, Microsoft.Extensions.Localization.IStringLocalizer<EventsController> localizer, ILogger<EventsController> logger) : base(repository, localizer, logger)
        {
        }

        public override IActionResult Delete(string key)
        {
            return NotFound();
        }
    }
}
