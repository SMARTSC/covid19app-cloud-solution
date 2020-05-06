namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class CountryInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Country, string>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; }

        public Persistence.Entities.Country Export()
        {
            var entity = new Persistence.Entities.Country
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Country entity)
        {
            Id = entity.Id;
        }

        public void Mergue(Persistence.Entities.Country entity)
        {
        }
    }
}
