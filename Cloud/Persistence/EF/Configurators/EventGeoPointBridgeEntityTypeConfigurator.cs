namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Configurators
{
    public class EventGeoPointBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.EventGeoPointBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.EventGeoPointBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(b => new { b.EventId, b.GeoPointId });

            entityTypeBuilder.HasOne(b => b.Event).WithMany(e => e.AreaGeoPointBridges).HasForeignKey(b => b.EventId);
            entityTypeBuilder.HasOne(b => b.GeoPoint).WithMany().HasForeignKey(b => b.GeoPointId);
        }
    }
}
