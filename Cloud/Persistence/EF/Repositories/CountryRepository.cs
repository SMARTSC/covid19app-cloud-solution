namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class CountryRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Country, string>
    {
        public CountryRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
