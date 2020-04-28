namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Country : SAPRESSC.Core.Persistence.Entities.IEntity<string>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }
    }
}
