using Microsoft.EntityFrameworkCore;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Repositories
{
    public class CaseRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<Entities.Case, string>
    {
        public CaseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Case> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(e => e.ContactProvinceBridges)
                .Include(e => e.Country)
                .Include(e => e.DetectionMunicipality)
                .Include(e => e.DiagnosticCenter)
                .Include(e => e.IsolationCenter)
                .Include(e => e.PossibleContagionCountryBridges).ThenInclude(e => e.Country);
        }
    }
}
