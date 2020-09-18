using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class AppUpdateAdvise : SAPRESSC.Core.Persistence.Entities.IEntity<int>
    {
        public AppUpdateAdvise()
        {
            Features = new System.Collections.Generic.List<AppUpdateFeature>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Version { get; set; }

        public System.DateTime ReleasedAt { get; set; }

        [Required]
        public string AccessLink { get; set; }

        public int PushDay { get; set; }

        public System.Collections.Generic.List<AppUpdateFeature> Features { get; set; }
    }
}
