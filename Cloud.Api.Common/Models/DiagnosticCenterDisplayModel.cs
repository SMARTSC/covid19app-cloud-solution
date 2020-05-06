namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class DiagnosticCenterDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.DiagnosticCenter, string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProvinceDisplayModel Province { get; set; }

        public GeoPointDisplayModel GeoPoint { get; set; }

        public void Import(Persistence.Entities.DiagnosticCenter entity)
        {
            Id = entity.Id;
            Name = entity.Name;

            if (entity.GeoPoint != null)
            {
                GeoPoint = new GeoPointDisplayModel();

                GeoPoint.Import(entity.GeoPoint);
            }

            if (entity.Province != null)
            {
                Province = new ProvinceDisplayModel();

                Province.Import(entity.Province);
            }
        }
    }
}
