namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class IsolationCenterInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.IsolationCenter, string>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public GeoPointInputModel GeoPoint { get; set; }

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
            ProvinceId = entity.ProvinceId;
            GeoPoint = new GeoPointInputModel();

            GeoPoint.Import(entity.GeoPoint);
        }

        public void Mergue(Persistence.Entities.IsolationCenter entity)
        {
            entity.Name = Name;
            entity.ProvinceId = ProvinceId;

            if (GeoPoint == null) return;

            entity.GeoPoint = new Persistence.Entities.GeoPoint
            {
                Latitude = GeoPoint.Latitude,
                Longitude = GeoPoint.Longitude
            };
        }
    }
}