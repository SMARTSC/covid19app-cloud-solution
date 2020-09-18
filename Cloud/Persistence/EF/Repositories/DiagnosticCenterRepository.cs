using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class DiagnosticCenterRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.DiagnosticCenter, string>
    {
        public DiagnosticCenterRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.DiagnosticCenter> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Province);
        }
    }
}
