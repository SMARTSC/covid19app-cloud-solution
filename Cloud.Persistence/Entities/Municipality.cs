namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Municipality : SAPRESSC.Core.Persistence.Entities.IEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Province")]
        public int ProvinceId { get; set; }

        public Province Province { get; set; }
    }
}
