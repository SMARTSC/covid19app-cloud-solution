namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class EventGeoPointBridge
    {
        public string EventId { get; set; }

        public Event Event { get; set; }

        public System.Guid GeoPointId { get; set; }

        public GeoPoint GeoPoint { get; set; }
    }
}
