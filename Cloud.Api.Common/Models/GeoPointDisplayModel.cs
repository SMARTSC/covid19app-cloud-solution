namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class GeoPointDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.GeoPoint, System.Guid>
    {
        public System.Guid Id { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public void Import(Persistence.Entities.GeoPoint entity)
        {
            Id = entity.Id;
            Longitude = entity.Longitude;
            Latitude = entity.Latitude;
        }
    }
}
