namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class CountryDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Country, string>
    {
        public string Id { get; set; }

        public void Import(Persistence.Entities.Country entity)
        {
            Id = entity.Id;
        }
    }
}
