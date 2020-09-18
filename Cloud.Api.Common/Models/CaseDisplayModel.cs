using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class CaseDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Case, long>
    {
        public long Id { get; set; }

        public System.DateTime ArriveAt { get; set; }

        public System.DateTime DetectAt { get; set; }

        public MunicipalityDisplayModel DetectionMunicipality { get; set; }

        public int ContactCount { get; set; }

        public ProvinceDisplayModel[] ContactProvinces { get; set; }

        public CountryDisplayModel Country { get; set; }

        public int Age { get; set; }

        public Persistence.Enumerations.Sex Sex { get; set; }

        public Persistence.Enumerations.CaseKind Kind { get; set; }

        public DiagnosticCenterDisplayModel DiagnosticCenter { get; set; }

        public IsolationCenterDisplayModel IsolationCenter { get; set; }

        public CountryDisplayModel[] PossibleContagionCountries { get; set; }

        public string About { get; set; }

        public void Import(Persistence.Entities.Case entity)
        {
            Id = entity.Id;
            ArriveAt = entity.ArriveAt;
            DetectAt = entity.DetectAt;
            DetectionMunicipality = new MunicipalityDisplayModel();
            ContactCount = entity.ContactCount;
            ContactProvinces = entity.ContactProvinceBridges.Select((Persistence.Entities.CaseProvinceBridge bridge) =>
            {
                var model = new ProvinceDisplayModel();

                model.Import(bridge.Province);

                return model;
            }).ToArray();
            Country = new CountryDisplayModel();
            Age = entity.Age;
            Sex = entity.Sex;
            Kind = entity.Kind;
            DiagnosticCenter = entity.DiagnosticCenterId == null ? null : new DiagnosticCenterDisplayModel();
            IsolationCenter = entity.IsolationCenterId == null ? null : new IsolationCenterDisplayModel();
            PossibleContagionCountries = entity.PossibleContagionCountryBridges.Select((Persistence.Entities.CaseCountryBridge bridge) =>
            {
                var model = new CountryDisplayModel();

                model.Import(bridge.Country);

                return model;
            }).ToArray();
            About = entity.About;

            DetectionMunicipality.Import(entity.DetectionMunicipality);
            Country.Import(entity.Country);
            DiagnosticCenter?.Import(entity.DiagnosticCenter);
            IsolationCenter?.Import(entity.IsolationCenter);
        }
    }
}
