namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class DiagnosticCenterInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.DiagnosticCenter, string>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public GeoPointInputModel GeoPoint { get; set; }

        public Persistence.Entities.DiagnosticCenter Export()
        {
            var entity = new Persistence.Entities.DiagnosticCenter
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.DiagnosticCenter entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ProvinceId = entity.ProvinceId;
            GeoPoint = new GeoPointInputModel();

            GeoPoint.Import(entity.GeoPoint);
        }

        public void Mergue(Persistence.Entities.DiagnosticCenter entity)
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
