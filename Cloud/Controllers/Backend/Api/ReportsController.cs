using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models;
using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;
using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Controllers.Backend.Api
{
    [Route("api/[area]/[controller]")]
    [Area("backend")]
    public class ReportsController : SAPRESSC.Core.Web.Api.Controllers.AbstractEntityApiManagementController<Report, int, ReportInputModel, ReportDisplayModel>
    {
        private readonly IEntityRepository<AppUpdateAdvise, int> appUpdateAdviseRepository;
        private readonly IEntityRepository<VendorAdvise, int> vendorAdviseRepository;

        public ReportsController(IEntityRepository<VendorAdvise, int> vendorAdviseRepository, IEntityRepository<AppUpdateAdvise, int> appUpdateAdviseRepository, IEntityRepository<Report, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<ReportsController> localizer, ILogger<ReportsController> logger) : base(repository, localizer, logger)
        {
            this.appUpdateAdviseRepository = appUpdateAdviseRepository;
            this.vendorAdviseRepository = vendorAdviseRepository;
        }

        public override IActionResult Delete(int key)
        {
            return NotFound();
        }

        protected override void PostCreate(Report entity, ReportInputModel inputModel)
        {
            base.PostCreate(entity, inputModel);

            var unqueueAppUpdateAdvises = appUpdateAdviseRepository.FindBy(e => e.PushDay <= 0).ToArray();

            var unqueueAppUpdateAdvisesRemaind = unqueueAppUpdateAdvises.Length;

            if (unqueueAppUpdateAdvisesRemaind > 0)
            {
                foreach (var item in unqueueAppUpdateAdvises)
                {
                    unqueueAppUpdateAdvisesRemaind--;

                    item.PushDay = entity.Id;

                    appUpdateAdviseRepository.Update(item, "system", unqueueAppUpdateAdvisesRemaind == 0);
                }
            }

            var unqueueVenderAdvises = vendorAdviseRepository.FindBy(e => e.PushDay <= 0).ToArray();

            var unqueueVenderAdvisesRemaind = unqueueVenderAdvises.Length;

            if (unqueueVenderAdvisesRemaind > 0)
            {
                foreach (var item in unqueueVenderAdvises)
                {
                    unqueueVenderAdvisesRemaind--;

                    item.PushDay = entity.Id;

                    vendorAdviseRepository.Update(item, "system", unqueueVenderAdvisesRemaind == 0);
                }
            }
        }
    }
}
