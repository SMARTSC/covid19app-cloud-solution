using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class IsolationCenterRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.IsolationCenter, string>
    {
        public IsolationCenterRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.IsolationCenter> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                //.Include(entity => entity.GeoPoint)
                .Include(entity => entity.Province);
        }
    }
}
