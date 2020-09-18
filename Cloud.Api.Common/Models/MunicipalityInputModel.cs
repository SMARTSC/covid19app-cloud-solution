namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class MunicipalityInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Municipality, string>
    {
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public Persistence.Entities.Municipality Export()
        {
            var entity = new Persistence.Entities.Municipality
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Municipality entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ProvinceId = entity.ProvinceId;
        }

        public void Mergue(Persistence.Entities.Municipality entity)
        {
            entity.Name = Name;
            entity.ProvinceId = ProvinceId;
        }
    }
}
