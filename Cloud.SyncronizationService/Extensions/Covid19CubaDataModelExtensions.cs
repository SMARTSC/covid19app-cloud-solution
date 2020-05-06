using SmartSolucionesCuba.SAPRESSC.Core.Api.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Extensions
{
    internal static class Covid19CubaDataModelExtensions
    {
        internal static async System.Threading.Tasks.Task SyncronizeCountriesAsync(this Models.Covid19CubaDataModel source, List<Models.Report> unsyncronizedReports, IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            var countriesApiClient = new Api.Connect.Clients.CountriesApiClient(httpClientHelperProvider);
            
            var currentCountries = await countriesApiClient.GetAsync();

            var newCountries = new List<Api.Common.Models.CountryInputModel>();

            foreach (var report in unsyncronizedReports)
            {
                if (report.Cases == null) continue;

                foreach (var @case in report.Cases)
                {

                    if (!currentCountries.Any(i => i.Id == @case.CountryCode) && !newCountries.Any(i => i.Id == @case.CountryCode))
                    {
                        newCountries.Add(new Api.Common.Models.CountryInputModel
                        {
                            Id = @case.CountryCode
                        });
                    }

                    if (@case.PossibleContagionCountryCodes == null) continue;

                    foreach (var key in @case.PossibleContagionCountryCodes)
                    {
                        if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key) && !currentCountries.Any(i => i.Id == key) && !newCountries.Any(i => i.Id == key))
                        {
                            newCountries.Add(new Api.Common.Models.CountryInputModel
                            {
                                Id = key
                            });
                        }
                    }
                }
            }

            foreach (var model in newCountries)
            {
                await countriesApiClient.CreateAsync(model);
            }
        }

        internal static async System.Threading.Tasks.Task SyncronizeProvincesAsync(this Models.Covid19CubaDataModel source, List<Models.Report> unsyncronizedReports, IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            var provincesApiClient = new Api.Connect.Clients.ProvincesApiClient(httpClientHelperProvider);

            var currentProvinces = await provincesApiClient.GetAsync();
                
            var newProvinces = new List<Api.Common.Models.ProvinceInputModel>();

            foreach (var item in source.Events.Values)
            {
                var provinceId = item.ProvinceCode.ToProvinceId();

                if (!currentProvinces.Any(i => i.Id == provinceId) && !newProvinces.Any(i => i.Id == provinceId))
                {
                    newProvinces.Add(new Api.Common.Models.ProvinceInputModel
                    {
                        Id = provinceId,
                        Name = item.ProvinceName
                    });
                }
            }

            foreach (var item in source.DiagnosticCenters.Values)
            {
                var provinceId = item.ProvinceCode.ToProvinceId();

                if (!currentProvinces.Any(i => i.Id == provinceId) && !newProvinces.Any(i => i.Id == provinceId))
                {
                    newProvinces.Add(new Api.Common.Models.ProvinceInputModel
                    {
                        Id = provinceId,
                        Name = item.ProvinceName
                    });
                }
            }

            foreach (var item in source.IsolationCenters.Values)
            {
                var provinceId = item.ProvinceCode.ToProvinceId();

                if (!currentProvinces.Any(i => i.Id == provinceId) && !newProvinces.Any(i => i.Id == provinceId))
                {
                    newProvinces.Add(new Api.Common.Models.ProvinceInputModel
                    {
                        Id = provinceId,
                        Name = item.ProvinceName
                    });
                }
            }

            foreach (var report in unsyncronizedReports)
            {
                if (report.Cases == null) continue;

                foreach (var @case in report.Cases)
                {
                    if (string.IsNullOrEmpty(@case.ProvinceCode)) continue;

                    var provinceId = @case.ProvinceCode.ToProvinceId();

                    if (!currentProvinces.Any(i => i.Id == provinceId) && !newProvinces.Any(i => i.Id == provinceId))
                    {
                        newProvinces.Add(new Api.Common.Models.ProvinceInputModel
                        {
                            Id = provinceId,
                            Name = @case.ProvinceCode
                        });
                    }
                }
            }

            foreach (var model in newProvinces)
            {
                await provincesApiClient.CreateAsync(model);
            }
        }

        internal static async System.Threading.Tasks.Task SyncronizeMunicipalitiesAsync(this Models.Covid19CubaDataModel source, List<Models.Report> unsyncronizedReports, IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            var municipalitiesApiClient = new Api.Connect.Clients.MunicipalitiesApiClient(httpClientHelperProvider);

            var currentMunicipalities = await municipalitiesApiClient.GetAsync();

            var newMunicipalities = new List<Api.Common.Models.MunicipalityInputModel>();

            foreach (var item in source.Events.Values)
            {
                var municipalityCodeParts = item.MunicipalityCode.Split(".");

                var municipalityId = int.Parse(municipalityCodeParts[1]);

                if (!currentMunicipalities.Any(i => i.Id == municipalityId) && !newMunicipalities.Any(i => i.Id == municipalityId))
                {
                    newMunicipalities.Add(new Api.Common.Models.MunicipalityInputModel
                    {
                        Id = municipalityId,
                        Name = item.MunicipalityName,
                        ProvinceId = int.Parse(municipalityCodeParts[0])
                    });
                }
            }

            foreach (var report in unsyncronizedReports)
            {
                if (report.Cases == null) continue;

                foreach (var @case in report.Cases)
                {
                    if (string.IsNullOrEmpty(@case.MunicipalityCode)) continue;

                    var municipalityCodeParts = @case.MunicipalityCode.Split(".");

                    var municipalityId = int.Parse(municipalityCodeParts[1]);

                    if (!currentMunicipalities.Any(i => i.Id == municipalityId) && !newMunicipalities.Any(i => i.Id == municipalityId))
                    {
                        newMunicipalities.Add(new Api.Common.Models.MunicipalityInputModel
                        {
                            Id = municipalityId,
                            Name = @case.MunicipalityName,
                            ProvinceId = int.Parse(municipalityCodeParts[0])
                        });
                    }
                }
            }

            foreach (var model in newMunicipalities)
            {
                await municipalitiesApiClient.CreateAsync(model);
            }
        }

        internal static async System.Threading.Tasks.Task SyncronizeIsolationCentersAsync(this Models.Covid19CubaDataModel source, IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            var isolationCentersApiClient = new Api.Connect.Clients.IsolationCentersApiClient(httpClientHelperProvider);

            var currentCenters = await isolationCentersApiClient.GetAsync();

            var newCenters = new List<Api.Common.Models.IsolationCenterInputModel>();

            foreach (var item in source.IsolationCenters.Values)
            {
                if (!currentCenters.Any(i => i.Id == item.Id) && !newCenters.Any(i => i.Id == item.Id))
                {
                    var provinceId = item.ProvinceCode.ToProvinceId();

                    newCenters.Add(new Api.Common.Models.IsolationCenterInputModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ProvinceId = provinceId
                    });
                }
            }

            foreach (var model in newCenters)
            {
                await isolationCentersApiClient.CreateAsync(model);
            }
        }

        internal static async System.Threading.Tasks.Task SyncronizeDiagnosticCentersAsync(this Models.Covid19CubaDataModel source, IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            var diagnosticCentersApiClient = new Api.Connect.Clients.DiagnosticCentersApiClient(httpClientHelperProvider);

            var currentCenters = await diagnosticCentersApiClient.GetAsync();

            var newCenters = new List<Api.Common.Models.DiagnosticCenterInputModel>();

            foreach (var item in source.DiagnosticCenters.Values)
            {
                if (!currentCenters.Any(i => i.Id == item.Id) && !newCenters.Any(i => i.Id == item.Id))
                {
                    var provinceId = item.ProvinceCode.ToProvinceId();

                    newCenters.Add(new Api.Common.Models.DiagnosticCenterInputModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ProvinceId = provinceId
                    });
                }
            }

            foreach (var model in newCenters)
            {
                await diagnosticCentersApiClient.CreateAsync(model);
            }
        }

        internal static async System.Threading.Tasks.Task SyncronizeEventsAsync(this Models.Covid19CubaDataModel source, IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            var eventsApiClient = new Api.Connect.Clients.EventsApiClient(httpClientHelperProvider);

            var currentEvents = await eventsApiClient.GetAsync();

            var newEvents = new List<Api.Common.Models.EventInputModel>();

            foreach (var item in source.Events.Values)
            {
                if (!currentEvents.Any(i => i.Id == item.Id) && !newEvents.Any(i => i.Id == item.Id))
                {
                    var municipalityCodeParts = item.MunicipalityCode.Split(".");

                    newEvents.Add(new Api.Common.Models.EventInputModel
                    {
                        Id = item.Id,
                        Label = item.Label,
                        Opened = item.Opened,
                        Checked = item.Checked,
                        MunicipalityId = int.Parse(municipalityCodeParts[1]),
                        CenterGeoPoint = new Api.Common.Models.GeoPointInputModel
                        {
                            Latitude = item.CenterGeoPointLatitude,
                            Longitude = item.CenterGeoPointLongitude
                        }
                    });
                }
            }

            foreach (var model in newEvents)
            {
                await eventsApiClient.CreateAsync(model);
            }
        }        
    }
}
