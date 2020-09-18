namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class MunicipalityDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Municipality, string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProvinceDisplayModel Province { get; set; }

        public void Import(Persistence.Entities.Municipality entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Province = new ProvinceDisplayModel();

            Province.Import(entity.Province);
        }
    }
}
