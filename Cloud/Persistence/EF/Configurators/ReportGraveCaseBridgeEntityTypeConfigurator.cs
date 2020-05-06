namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Configurators
{
    public class ReportGraveCaseBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ReportGraveCaseBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ReportGraveCaseBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ReportId, bridge.CaseId });

            entityTypeBuilder.HasOne(bridge => bridge.Report).WithMany(entity => entity.GraveCaseBridges).HasForeignKey(bridge => bridge.ReportId);
            entityTypeBuilder.HasOne(bridge => bridge.Case).WithMany().HasForeignKey(bridge => bridge.CaseId);
        }
    }
}
