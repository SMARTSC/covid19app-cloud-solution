namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class GeoPoint : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public GeoPoint()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
