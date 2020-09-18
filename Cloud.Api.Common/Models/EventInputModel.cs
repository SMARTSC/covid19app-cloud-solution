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

        public int PushDay { get; set; }

        public string MunicipalityId { get; set; }

        public decimal CenterGeoPointLatitude { get; set; }

        public decimal CenterGeoPointLongitude { get; set; }

        public Persistence.Entities.Event Export()
        {
            var entity = new Persistence.Entities.Event
            {
                Id = Id
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
            PushDay = entity.PushDay;
            MunicipalityId = entity.MunicipalityId;
            CenterGeoPointLatitude = entity.CenterGeoPointLatitude;
            CenterGeoPointLongitude = entity.CenterGeoPointLongitude;
        }

        public void Mergue(Persistence.Entities.Event entity)
        {
            entity.Label = Label;
            entity.Opened = Opened;
            entity.Checked = Checked;
            entity.PushDay = PushDay;
            entity.MunicipalityId = MunicipalityId;
            entity.CenterGeoPointLatitude = CenterGeoPointLatitude;
            entity.CenterGeoPointLongitude = CenterGeoPointLongitude;
        }
    }
}
