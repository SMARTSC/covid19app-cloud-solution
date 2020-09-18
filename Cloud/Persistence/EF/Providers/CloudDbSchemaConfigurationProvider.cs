using SmartSolucionesCuba.SAPRESSC.Core.Persistence.EF.Configurators;
using System.Collections.Generic;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Providers
{
    public class CloudDbSchemaConfigurationProvider : SAPRESSC.Core.Persistence.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public string DefaultPersistenceSchema => null;

        public ICollection<IEntityTypeConfigurator> EntityTypeConfigurators => new List<IEntityTypeConfigurator>
        {
            new Configurators.CaseCountryBridgeEntityTypeConfigurator(),
            new Configurators.CaseProvinceBridgeEntityTypeConfigurator(),
            new Configurators.ReportDeadCaseBridgeEntityTypeConfigurator(),
            new Configurators.ReportEvacuateCaseBridgeEntityTypeConfigurator(),
            new Configurators.ReportGraveCaseBridgeEntityTypeConfigurator(),
            new Configurators.ReportCriticCaseBridgeEntityTypeConfigurator(),
            new Configurators.ReportRecoveredCaseBridgeEntityTypeConfigurator()
        };
    }
}
