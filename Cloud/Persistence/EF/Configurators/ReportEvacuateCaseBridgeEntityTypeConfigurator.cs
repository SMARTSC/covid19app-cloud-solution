namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Configurators
{
    public class ReportEvacuateCaseBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ReportEvacuateCaseBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ReportEvacuateCaseBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ReportId, bridge.CaseId });

            entityTypeBuilder.HasOne(bridge => bridge.Report).WithMany(entity => entity.EvacuateCaseBridges).HasForeignKey(bridge => bridge.ReportId);
            entityTypeBuilder.HasOne(bridge => bridge.Case).WithMany().HasForeignKey(bridge => bridge.CaseId);
        }
    }
}
