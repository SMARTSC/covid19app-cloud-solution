namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class IsolationCenterRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.IsolationCenter, string>
    {
        public IsolationCenterRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
