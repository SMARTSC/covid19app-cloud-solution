using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class ProvinceInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Province, int>
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Province Export()
        {
            var entity = new Province
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Province entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public void Mergue(Province entity)
        {
            entity.Name = Name;
        }
    }
}
