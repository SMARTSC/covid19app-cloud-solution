namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class EventDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Event, string>
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public bool Opened { get; set; }

        public bool Checked { get; set; }

        public MunicipalityDisplayModel Municipality { get; set; }

        public GeoPointDisplayModel CenterGeoPoint { get; set; }

        public void Import(Persistence.Entities.Event entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            Opened = entity.Opened;
            Checked = entity.Checked;
            Municipality = new MunicipalityDisplayModel();
            CenterGeoPoint = new GeoPointDisplayModel();

            Municipality.Import(entity.Municipality);
            CenterGeoPoint.Import(entity.CenterGeoPoint);
        }
    }
}
