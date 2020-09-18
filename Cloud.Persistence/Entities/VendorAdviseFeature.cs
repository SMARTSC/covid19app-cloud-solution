namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class VendorAdviseFeature : SAPRESSC.Core.Persistence.Entities.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Advise")]
        public int AdviseId { get; set; }

        public VendorAdvise Advise { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
