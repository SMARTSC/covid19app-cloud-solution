namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class AppUpdateFeature : SAPRESSC.Core.Persistence.Entities.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Advise")]
        public int AdviseId { get; set; }

        public AppUpdateAdvise Advise { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
