using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class AppUpdateAdviseRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.AppUpdateAdvise, int>
    {
        public AppUpdateAdviseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.AppUpdateAdvise> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Features);
        }
    }
}
