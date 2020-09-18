using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Event : SAPRESSC.Core.Persistence.Entities.IEntity<string>
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Label { get; set; }

        public int PushDay { get; set; }

        public bool Opened { get; set; }

        public bool Checked { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Municipality")]
        public string MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }

        public decimal CenterGeoPointLatitude { get; set; }

        public decimal CenterGeoPointLongitude { get; set; }

        public string AreaGeoData { get; set; }
    }
}
