namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class IsolationCenterDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.IsolationCenter, string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int PushDay { get; set; }

        public ProvinceDisplayModel Province { get; set; }

        public decimal GeoPointLatitude { get; set; }

        public decimal GeoPointLongitude { get; set; }

        public void Import(Persistence.Entities.IsolationCenter entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            PushDay = entity.PushDay;
            GeoPointLatitude = entity.GeoPointLatitude;
            GeoPointLongitude = entity.GeoPointLongitude;

            if (entity.Province != null)
            {
                Province = new ProvinceDisplayModel();

                Province.Import(entity.Province);
            }
        }
    }
}
