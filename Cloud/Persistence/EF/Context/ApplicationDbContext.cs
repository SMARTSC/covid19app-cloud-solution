using Microsoft.EntityFrameworkCore;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.EF.Providers.Facade;
using System.Collections.Generic;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.EF.Context
{
    public class ApplicationDbContext : SAPRESSC.Core.Persistence.EF.Context.AbstractTraceableDbContext
    {
        public ApplicationDbContext(IEnumerable<IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

        public DbSet<Entities.Province> Provinces { get; set; }
        public DbSet<Entities.Municipality> Municipalities { get; set; }
        public DbSet<Entities.Country> Countries { get; set; }
        public DbSet<Entities.GeoPoint> GeoPoints { get; set; }
        public DbSet<Entities.IsolationCenter> IsolationCenters { get; set; }
        public DbSet<Entities.DiagnosticCenter> DiagnosticCenters { get; set; }
        public DbSet<Entities.Event> Events { get; set; }
        public DbSet<Entities.Case> Cases { get; set; }
        public DbSet<Entities.Report> Reports { get; set; }
        public DbSet<Entities.CaseCountryBridge> CaseCountryBridges { get; set; }
        public DbSet<Entities.CaseProvinceBridge> CaseProvinceBridges { get; set; }
        public DbSet<Entities.EventGeoPointBridge> EventGeoPointBridges { get; set; }
        public DbSet<Entities.ReportDeadCaseBridge> ReportDeadCaseBridges { get; set; }
        public DbSet<Entities.ReportCriticCaseBridge> ReportCriticCaseBridges { get; set; }
        public DbSet<Entities.ReportEvacuateCaseBridge> ReportEvacuateCaseBridges { get; set; }
        public DbSet<Entities.ReportGraveCaseBridge> ReportGraveCaseBridges { get; set; }
        public DbSet<Entities.ReportRecoveredCaseBridge> ReportRecoveredCaseBridges { get; set; }
    }
}
