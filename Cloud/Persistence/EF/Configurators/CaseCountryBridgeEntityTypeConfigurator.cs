namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Configurators
{
    public class CaseCountryBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.CaseCountryBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.CaseCountryBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(b => new { b.CaseId, b.CountryId });

            entityTypeBuilder.HasOne(b => b.Case).WithMany(e => e.PossibleContagionCountryBridges).HasForeignKey(b => b.CaseId);
            entityTypeBuilder.HasOne(b => b.Country).WithMany().HasForeignKey(b => b.CountryId);
        }
    }
}
