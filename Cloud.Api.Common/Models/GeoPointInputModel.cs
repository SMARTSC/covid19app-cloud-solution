namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class GeoPointInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.GeoPoint, System.Guid>
    {
        public System.Guid Id { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public Persistence.Entities.GeoPoint Export()
        {
            var entity = new Persistence.Entities.GeoPoint();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.GeoPoint entity)
        {
            Id = entity.Id;
            Longitude = entity.Longitude;
            Latitude = entity.Latitude;
        }

        public void Mergue(Persistence.Entities.GeoPoint entity)
        {
            entity.Longitude = Longitude;
            entity.Latitude = Latitude;
        }
    }
}
