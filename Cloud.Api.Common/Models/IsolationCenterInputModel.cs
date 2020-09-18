namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class IsolationCenterInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.IsolationCenter, string>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int PushDay { get; set; }

        public int ProvinceId { get; set; }

        public decimal GeoPointLatitude { get; set; }

        public decimal GeoPointLongitude { get; set; }

        public Persistence.Entities.IsolationCenter Export()
        {
            var entity = new Persistence.Entities.IsolationCenter
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.IsolationCenter entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            PushDay = entity.PushDay;
            ProvinceId = entity.ProvinceId;
            GeoPointLatitude = entity.GeoPointLatitude;
            GeoPointLongitude = entity.GeoPointLongitude;
        }

        public void Mergue(Persistence.Entities.IsolationCenter entity)
        {
            entity.Name = Name;
            entity.PushDay = PushDay;
            entity.ProvinceId = ProvinceId;
            entity.GeoPointLatitude = GeoPointLatitude;
            entity.GeoPointLongitude = GeoPointLongitude;
        }
    }
}