using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class MunicipalityRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Municipality, int>
    {
        public MunicipalityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Municipality> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(e => e.Province);
        }
    }
}
