using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.EF.Extensions;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Options.ApiKeyOptions>(configuration.GetSection("ApiKey"));

            services.AddDbContext<Persistence.EF.Context.ApplicationDbContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"), mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new System.Version(configuration.GetSection("MySQLSeverVersion").Value), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql);
            }));

            services.AddScoped<DbContext, Persistence.EF.Context.ApplicationDbContext>();

            services.AddScoped<IEntityRepository<Persistence.Entities.Country, string>, Persistence.EF.Repositories.CountryRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Province, int>, Persistence.EF.Repositories.ProvinceRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Municipality, string>, Persistence.EF.Repositories.MunicipalityRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.DiagnosticCenter, string>, Persistence.EF.Repositories.DiagnosticCenterRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.IsolationCenter, string>, Persistence.EF.Repositories.IsolationCenterRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Event, string>, Persistence.EF.Repositories.EventRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Report, int>, Persistence.EF.Repositories.ReportRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Case, long>, Persistence.EF.Repositories.CaseRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.AppUpdateAdvise, int>, Persistence.EF.Repositories.AppUpdateAdviseRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.VendorAdvise, int>, Persistence.EF.Repositories.VendorAdviseRepository>();

            services.AddSingleton<SAPRESSC.Core.Persistence.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.EF.Providers.CloudDbSchemaConfigurationProvider>();

            services.AddLocalization();

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddResponseCaching();
            services.AddMemoryCache();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext)
        {
            loggerFactory.AddSerilog(Log.Logger);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else if (env.IsStaging())
            {
                dbContext.Database.Migrate();

                app.PerformDatabaseInitialization();
            }
            else
            {
                app.UseExceptionHandler("/error");

                app.UseHsts();
            }

            app.UseMiddleware<Middlewares.ApiKeyValidationMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute("defaultLocalizedAreaRoutes",
                    template: "{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/{area:exists}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute(
                    name: "defaultLocalizedRoutes",
                    template: "{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute("defaultAreaRoutes",
                    template: "{area:exists}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute(
                    name: "defaultRoutes",
                    template: "{controller=start}/{action=index}/{id?}");
            });
        }
    }
}
