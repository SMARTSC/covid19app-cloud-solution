using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class VendorAdviseRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.VendorAdvise, int>
    {
        public VendorAdviseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.VendorAdvise> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Features);
        }
    }
}
