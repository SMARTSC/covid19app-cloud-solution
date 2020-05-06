namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class EventInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Event, string>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Label { get; set; }

        public bool Opened { get; set; }

        public bool Checked { get; set; }

        public int MunicipalityId { get; set; }

        public GeoPointInputModel CenterGeoPoint { get; set; }

        public Persistence.Entities.Event Export()
        {
            var entity = new Persistence.Entities.Event
            {
                Id = Id,
                CenterGeoPoint = new Persistence.Entities.GeoPoint()
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Event entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            Opened = entity.Opened;
            Checked = entity.Checked;
            MunicipalityId = entity.MunicipalityId;
            CenterGeoPoint = new GeoPointInputModel();

            CenterGeoPoint.Import(entity.CenterGeoPoint);
        }

        public void Mergue(Persistence.Entities.Event entity)
        {
            entity.Label = Label;
            entity.Opened = Opened;
            entity.Checked = Checked;
            entity.MunicipalityId = MunicipalityId;
            entity.CenterGeoPoint.Latitude = CenterGeoPoint.Latitude;
            entity.CenterGeoPoint.Longitude = CenterGeoPoint.Longitude;
        }
    }
}
