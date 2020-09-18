using System.ComponentModel.DataAnnotations;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Persistence.Entities
{
    public class VendorAdvise : SAPRESSC.Core.Persistence.Entities.IEntity<int>
    {
        public VendorAdvise()
        {
            Features = new System.Collections.Generic.List<VendorAdviseFeature>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string AccessLink { get; set; }

        public string ThumbnailImageLink { get; set; }

        public int PushDay { get; set; }

        public System.Collections.Generic.List<VendorAdviseFeature> Features { get; set; }
    }
}
