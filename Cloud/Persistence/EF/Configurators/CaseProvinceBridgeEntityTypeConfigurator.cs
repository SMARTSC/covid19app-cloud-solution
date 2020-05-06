namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Configurators
{
    public class CaseProvinceBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.CaseProvinceBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.CaseProvinceBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(b => new { b.CaseId, b.ProvinceId });

            entityTypeBuilder.HasOne(b => b.Case).WithMany(e => e.ContactProvinceBridges).HasForeignKey(b => b.CaseId);
            entityTypeBuilder.HasOne(b => b.Province).WithMany().HasForeignKey(b => b.ProvinceId);
        }
    }
}
