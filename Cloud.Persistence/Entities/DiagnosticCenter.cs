namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class DiagnosticCenter : SAPRESSC.Core.Persistence.Entities.IEntity<string>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int PushDay { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Province")]
        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public decimal GeoPointLatitude { get; set; }

        public decimal GeoPointLongitude { get; set; }
    }
}
