namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Province : SAPRESSC.Core.Persistence.Entities.IEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
    }
}
