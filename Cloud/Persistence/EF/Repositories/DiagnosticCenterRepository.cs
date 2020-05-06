namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class DiagnosticCenterRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.DiagnosticCenter, string>
    {
        public DiagnosticCenterRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
