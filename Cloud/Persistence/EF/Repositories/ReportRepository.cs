using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class ReportRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Report, int>
    {
        public ReportRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Report> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(e => e.Cases).ThenInclude(e => e.DetectionMunicipality);
        }
    }
}
