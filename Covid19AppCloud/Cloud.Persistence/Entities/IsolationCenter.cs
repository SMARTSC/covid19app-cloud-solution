namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class IsolationCenter : SAPRESSC.Core.Persistence.Entities.IEntity<string>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Province")]
        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("GeoPoint")]
        public System.Guid GeoPointId { get; set; }

        public GeoPoint GeoPoint { get; set; }
    }
}