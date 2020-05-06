namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class GeoPointRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.GeoPoint, System.Guid>
    {
        public GeoPointRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
