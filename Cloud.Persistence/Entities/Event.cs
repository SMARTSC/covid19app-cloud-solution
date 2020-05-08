using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Event : SAPRESSC.Core.Persistence.Entities.IEntity<string>
    {
        public Event()
        {
            AreaGeoPointBridges = new System.Collections.Generic.List<EventGeoPointBridge>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Label { get; set; }

        public bool Opened { get; set; }

        public bool Checked { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Municipality")]
        public int MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CenterGeoPoint")]
        public System.Guid CenterGeoPointId { get; set; }

        public GeoPoint CenterGeoPoint { get; set; }

        // TODO Replace by GEOJSON string representative property
        public System.Collections.Generic.List<EventGeoPointBridge> AreaGeoPointBridges { get; set; }
    }
}
