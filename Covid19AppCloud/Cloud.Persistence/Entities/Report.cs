namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class Report : SAPRESSC.Core.Persistence.Entities.IEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public System.DateTime At { get; set; }

        public int RiskyContactCount { get; set; }

        public System.Collections.Generic.List<Case> Cases { get; set; }
    }
}
