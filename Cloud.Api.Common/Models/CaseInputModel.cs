using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class CaseInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Case, long>
    {
        public long Id { get; set; }

        public System.DateTime ArriveAt { get; set; }

        public System.DateTime DetectAt { get; set; }

        public string DetectionMunicipalityId { get; set; }

        public int ContactCount { get; set; }

        public ProvinceDisplayModel[] ContactProvinces { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string CountryId { get; set; }

        public int Age { get; set; }

        public Persistence.Enumerations.Sex Sex { get; set; }

        public Persistence.Enumerations.CaseKind Kind { get; set; }

        public string DiagnosticCenterId { get; set; }

        public string IsolationCenterId { get; set; }

        public CountryDisplayModel[] PossibleContagionCountries { get; set; }

        public string About { get; set; }

        public Persistence.Entities.Case Export()
        {
            var entity = new Persistence.Entities.Case();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Case entity)
        {
            Id = entity.Id;
            ArriveAt = entity.ArriveAt;
            DetectAt = entity.DetectAt;
            DetectionMunicipalityId = entity.DetectionMunicipalityId;
            ContactCount = entity.ContactCount;
            ContactProvinces = entity.ContactProvinceBridges.Select(bridge =>
            {
                var model = new ProvinceDisplayModel();

                model.Import(bridge.Province);

                return model;
            }).ToArray();
            CountryId = entity.CountryId;
            Age = entity.Age;
            Sex = entity.Sex;
            Kind = entity.Kind;
            DiagnosticCenterId = entity.DiagnosticCenterId;
            IsolationCenterId = entity.IsolationCenterId;
            PossibleContagionCountries = entity.PossibleContagionCountryBridges.Select(bridge =>
            {
                var model = new CountryDisplayModel();

                model.Import(bridge.Country);

                return model;
            }).ToArray();
            About = entity.About;
        }

        public void Mergue(Persistence.Entities.Case entity)
        {
            entity.ArriveAt = ArriveAt;
            entity.DetectAt = DetectAt;
            entity.DetectionMunicipalityId = DetectionMunicipalityId;
            entity.ContactCount = ContactCount;
            
            if (ContactProvinces != null)
            {
                entity.ContactProvinceBridges = ContactProvinces.Select(model => new Persistence.Entities.CaseProvinceBridge
                {
                    CaseId = Id,
                    ProvinceId = model.Id
                }).ToList();
            }

            entity.CountryId = CountryId;
            entity.Age = Age;
            entity.Sex = Sex;
            entity.Kind = Kind;
            entity.DiagnosticCenterId = DiagnosticCenterId;
            entity.IsolationCenterId = IsolationCenterId;
            
            if (PossibleContagionCountries != null)
            {
                entity.PossibleContagionCountryBridges = PossibleContagionCountries.Select(model => new Persistence.Entities.CaseCountryBridge
                {
                    CaseId = Id,
                    CountryId = model.Id
                }).ToList();
            }

            entity.About = About;
        }
    }
}
