using SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.View
{
    public class ProvinceInputViewModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Province, int>
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
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
