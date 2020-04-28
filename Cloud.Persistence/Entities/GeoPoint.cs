namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class GeoPoint : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public long Longitude { get; set; }

        public long Latitude { get; set; }
    }
}
