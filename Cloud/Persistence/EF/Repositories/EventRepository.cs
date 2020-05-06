using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class EventRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Event, string>
    {
        public EventRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Event> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(e => e.CenterGeoPoint)
                .Include(e => e.Municipality).ThenInclude(e => e.Province);
        }
    }
}
