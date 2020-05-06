namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Models.View
{
    public class ProvinceDisplayViewModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Province, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Import(Persistence.Entities.Province entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}
