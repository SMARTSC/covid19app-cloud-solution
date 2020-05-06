namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class ProvinceRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Province, int>
    {
        public ProvinceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
